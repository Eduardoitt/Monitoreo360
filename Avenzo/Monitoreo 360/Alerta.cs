using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoreo_360
{
    public class Alerta
    {
        public bool activo { get; set; }
        public string codigoDeAlarma { get; set; }
        public int color { get; set; }
        public string fecha { get; set; }
        public string fechaRecibido { get; set; }
        public int id { get; set; }
        public bool recibido { get; set; }
        public string sensor { get; set; }
        public string usuario { get; set; }
        public string usuarioCreacion { get; set; }
    }
    public class ClienteEventos {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string Ubicacion { get; set; }
        public string ParticionArea { get; set; }
    }
    public static class Util {
        public enum Effect { Roll, Slide,Center,Blend}
        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible)
            {
                flags |= 0x10000; angle += 100;
            }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation Failed");
            ctl.Visible = !ctl.Visible;
        }
        private static int[] dirmap = { 1,5,4,6,2,10,8,9};
        private static int[] effmap = { 0,0x40000,0x10,0x80000};
        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle,int msec,int flags);
    }
}