using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Dashboard.Tools
{
    public class Upload
    {
        public static void Save(string RFC)
        {
            // Get the object used to communicate with the server.  
            try {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://avenzo.mx/Facturas/" + RFC + "_SinTimbrar.jpg");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                // This example assumes the FTP site uses anonymous logon.  
                request.Credentials = new NetworkCredential("AvenzoPagina2", "T#clado01");
                // Copy the contents of the file to the request stream.  
                StreamReader sourceStream = new StreamReader(@"C:\Users\Ivan\Desktop\ife.jpg");
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}