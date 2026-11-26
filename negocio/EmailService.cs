using System;
using System.Net;
using System.Net.Mail;

namespace negocio
{
    public class EmailService
    {
        public void enviarEmail(string destinatario, string asunto, string mensaje)
        {
            string emailOrigen = Environment.GetEnvironmentVariable("COMERCIO_EMAIL");
            string password = Environment.GetEnvironmentVariable("COMERCIO_EMAIL_PASSWORD");

            if (string.IsNullOrEmpty(emailOrigen) ||
                string.IsNullOrEmpty(password))
            {
                throw new Exception("Faltan configurar las credenciales del correo.");
            }

            using (MailMessage correo = new MailMessage())
            {
                correo.From = new MailAddress(emailOrigen);
                correo.To.Add(destinatario);
                correo.Subject = asunto;
                correo.Body = mensaje;

                using (SmtpClient servidor = new SmtpClient("smtp.gmail.com"))
                {
                    servidor.Port = 587;
                    servidor.Credentials = new NetworkCredential(emailOrigen, password);
                    servidor.EnableSsl = true;

                    servidor.Send(correo);
                }
            }
        }
    }
}