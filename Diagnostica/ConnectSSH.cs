using Renci.SshNet;
using System.Net;
namespace VKRWebAPI.Diagnostic
{
    public class ConnectSSH
    {
        private string _IPaddres;

        private string _VLAN;

        private string ShowVlanCommand = "Show service FDB-MAC | match";

        public string _result {  get; private set; }

        public  ConnectSSH(string IP, string VLAN)
        {
            _IPaddres = IP;
            _VLAN = VLAN;

            using (var SshClient = new SshClient(_IPaddres, "Admin", "12345"))
            {
                if (_IPaddres != "")
                {

                    _result = $"В данном канале связи присутствуют следующие MAC: \n" +
                              $"00:1B:44:11:3A:B7\n" +
                              $"00:1B:44:22:3B:B7\n" +
                              $"В случае недоступности канала связи,\nпросьба обратиться в техническую поддержку";
                    return;
                }
                try
                {
                    SshClient.Connect();

                    if (SshClient.IsConnected)
                    {
                        var cmd = SshClient.CreateCommand($"{ShowVlanCommand} + {_VLAN}");

                        _result = cmd.Execute();
                    }
                    else
                    {
                        _result = "";
                    }


                }
                catch (Exception)
                {

                    _result = "Наблюдается проблема на сети, данные не доступны.\nПросьба обратиться в техническую поддержку для дополнительной информации";
                }
                finally
                {
                    if (SshClient.IsConnected)
                    {
                        SshClient.Dispose();
                    }
                }
            }
        }

    }
        
}
