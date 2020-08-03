using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Helpers
{
    public class Correo
    {
     //
        public static MailMessage configMailMessage(string from, string subject) {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(from);
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            return email;
        }
        public static SmtpClient configSmtp() {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 80;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("facturas@avenzo.mx", "T#clado01");
            return smtp;
        }
        public static string BodyHtmlRecuperar(string Nombre, Guid Id, string Contraseña, string Host, string HTML)
        {
            StringBuilder html = new StringBuilder();
            html.Append(System.IO.File.ReadAllText(HTML));
            html.Replace("??Nombre??", Nombre);
            html.Replace("??Id??", Id.ToString());
            html.Replace("??Contraseña??", Contraseña);
            html.Replace("??Host??", Host);
            return html.ToString();
        }
        public static void EnviarContraseña(string Correo, Guid Id, string Nombre, string Contraseña, string Host, string HTML)
        {            
            MailMessage email = configMailMessage("no-reply@avenzo.mx", "Solicitud de cambio de contraseña ✓");
            email.Headers.Add("X-Company", "Avenzo");
            email.Headers.Add("X-Location", "México");
            email.To.Add(new MailAddress(Correo));            
            SmtpClient smtp = configSmtp();            
            email.Body = BodyHtmlRecuperar(Nombre, Id, Contraseña, Host, HTML);
            smtp.Send(email);            
            email.Dispose();
        }
        public static void EnviarFactura(string Correos,string Nombre,string Host,string HTML,string RutaXML , string RutaPDF,Guid Id)
        {
            MailMessage email = configMailMessage("no-reply@avenzo.mx", "Factura ✓");
            email.To.Add(new MailAddress(Correos));            
            email.Attachments.Add(new Attachment(RutaXML + ".xml"));
            email.Attachments.Add(new Attachment(RutaPDF + ".PDF"));
            
            SmtpClient smtp = configSmtp();
            email.Body = BodyHtmlFacturas(HTML,Id,Nombre,Host);
            smtp.Send(email);
            email.Dispose();
        }
        public static string BodyHtmlFacturas(string HTML,Guid Id,string Nombre,string Host) {
            StringBuilder html = new StringBuilder();
            html.Append(System.IO.File.ReadAllText(HTML));
            html.Replace("??Nombre??", Nombre);
            html.Replace("??Id??", Id.ToString());
            html.Replace("??Host??", Host);
            return html.ToString();
        }
    }
}
