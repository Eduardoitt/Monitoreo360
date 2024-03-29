﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Model;
namespace Avenzo.Tools
{
   
    public class Correo
    {
        private static AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public static string BodyHtml(string Nombre,Guid Id,string Contraseña,string Host,string HTML) {
            StringBuilder html = new StringBuilder();
            html.Append(System.IO.File.ReadAllText(HTML));            
            html.Replace("??Nombre??", Nombre);
            html.Replace("??Id??", Id.ToString());
            html.Replace("??Contraseña??", Contraseña);
            html.Replace("??Host??", Host);
            return html.ToString();
        }
        public static void EnviarContraseña(string Correo, Guid Id,string Nombre,string Contraseña,string Host,string HTML)
        {            
            DateTime Time = new DateTime();
            Time = DateTime.Now;
            MailMessage email = new MailMessage();            
            email.To.Add(new MailAddress(Correo));            
            email.From = new MailAddress("no-reply@avenzo.mx");
            email.Subject = "Recuperacion de Contraseña ✓";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 80;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("facturas@avenzo.mx", "T#clado01");            
            email.Body = BodyHtml(Nombre,Id,Contraseña,Host,HTML);            
            smtp.Send(email);
            email.Dispose();         
        }
        public static void EnviarContacto(string Nombres,string ApellidoPaterno,string ApellidoMaterno,string Sexo,
            string Departamento,string Correo,string Telefono,string Mensaje,string HTML)
        {
            DateTime Time = new DateTime();
            Time = DateTime.Now;
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress("cristian.santiago.rosas@gmail.com"));
            email.To.Add(new MailAddress("contacto@avenzo.mx"));
            email.From = new MailAddress("clientesAvenzo@avenzo.mx");
            email.Subject = "Nuevo Contacto ✓";            
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 80;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("facturas@avenzo.mx", "T#clado01");
            email.Body = HtmlContacto(Nombres, ApellidoPaterno, ApellidoMaterno, Sexo, Departamento, Correo, Telefono, Mensaje, HTML);
            smtp.Send(email);
            email.Dispose();
        }
        public static string HtmlContacto(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string Sexo,
            string Departamento, string Correo, string Telefono, string Mensaje,string HTML)
        {
            StringBuilder html = new StringBuilder();
            html.Append(System.IO.File.ReadAllText(HTML));
            html.Replace("??Fecha??",DateTime.Now.ToString());
            html.Replace("??Nombre??", Nombres);
            html.Replace("??ApellidoPaterno??", ApellidoPaterno);
            html.Replace("??ApellidoMaterno??", ApellidoMaterno);
            html.Replace("??Sexo??", Sexo);
            html.Replace("??Departamento??", Departamento);
            html.Replace("??Correo??", Correo);
            html.Replace("??Telefono??", Telefono);
            html.Replace("??Mensaje??", Mensaje);            
            return html.ToString();
        }
    }
}