using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Helpers
{
    public class StreamHelper
    {
        public static byte[] HttpPostedFileBaseToByte(HttpPostedFileBase File) {
            byte[] Data;
            using (Stream  inputStream = File.InputStream) {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream==null) {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                Data = memoryStream.ToArray();
            }
            return Data;
        }
    }
}
