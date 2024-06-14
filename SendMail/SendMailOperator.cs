using System.Net;
using System.Net.Mail;
namespace VKRWebAPI.SendMail
{
    public class SendMailOperator
    {

        private string SmtpHost = "smtp.server.net";
        private string Login = "Operator";
        private string Pass = "12345";
        private string SubjectName = "Отсутствие сервиса";
        private int Port = 30;

        private string Diagnostic = "DiagnosticService@operator.ru";
        private string OperatorName = "Operator@operator.ru";

        public void SendMessageOperator(string message, string CopyClientMail)
        {
            MailAddress DiagnosticAddressFrom = new MailAddress("DiagnosticService@operator.ru", "Diagnostic");
            MailAddress OperatorAddressTo = new MailAddress("Operator@operator.ru");

            MailMessage Message = new MailMessage(DiagnosticAddressFrom,OperatorAddressTo);
            Message.Subject = SubjectName;
            Message.Body = message;
            MailAddress Copy = new MailAddress(CopyClientMail);
            Message.CC.Add(Copy);
            SmtpClient smtpClient = new SmtpClient(SmtpHost,Port);
            smtpClient.Credentials = new NetworkCredential(Login,Pass); 
            try
            {
                smtpClient.Send(Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
