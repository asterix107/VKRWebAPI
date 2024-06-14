using System.Net;
using System.Net.NetworkInformation;
namespace VKRWebAPI.Diagnostic
{
    public class Diagnostic
    {
        public string result {  get; private set; }

        public Diagnostic(string City,string _IPClient, string VLAN)
        {

            if (VLAN != null)
            {
                ConnectSSH connectSSH = new ConnectSSH(CityConnectIpAddress(City), VLAN);
                result = connectSSH._result;
                return;
            }else if (_IPClient != null)
            {
                using(Ping pingIP = new())
                {
                    try
                    {
                        PingReply reply = pingIP.Send(_IPClient);

                        if(reply.Status == IPStatus.Success)
                        {

                            result = 
                                $"Address: {reply.Address}\n" +
                                $"Оборудование доступно";
                        }
                        else
                        {
                            result = $"Оборудование не доступно {reply.Status}";
                               
                        }
                    }
                    catch (Exception)
                    {

                        result = $"Ping недоступен";
                    }
                }
            }


        }

        private string CityConnectIpAddress(string CityClient)
        {
            switch (CityClient)
            {
                case "Barnaul": return "192.168.88.1"; 
                case "Omsk": return "192.168.1.2";
                case "Perm": return "192.168.1.3";
                case "Novosibirsk": return "192.168.1.4";
                case "Moskva": return "192.168.1.5";
                default: return "192.168.1.6";
            }
        }
    }
}
