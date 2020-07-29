using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Monitoreo_360
{
    public partial class HorarioOperacion : MetroFramework.Forms.MetroForm
    {
        Guid IdCliente = new Guid();
        Guid IdUsuario = new Guid();
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public HorarioOperacion(Guid IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        public void setInfo(Guid IdCliente)
        {
            this.IdCliente = IdCliente;
            Model.HorarioOperaciones HO = db.GetHorarioOperaciones(this.IdCliente).FirstOrDefault();
            if (HO!=null) {
                dateTimePicker_LunesInicio.Value = new DateTime(2000,12,1,HO.LunesInicio.Value.Hours, HO.LunesInicio.Value.Minutes, HO.LunesInicio.Value.Seconds);
                dateTimePicker_LunesFinal.Value = new DateTime(2000, 12, 1, HO.LunesFinal.Value.Hours, HO.LunesFinal.Value.Minutes, HO.LunesFinal.Value.Seconds);
                dateTimePicker_MartesInicio.Value = new DateTime(2000, 12, 1, HO.MartesInicio.Value.Hours, HO.MartesInicio.Value.Minutes, HO.MartesInicio.Value.Seconds);
                dateTimePicker_MartesFinal.Value = new DateTime(2000, 12, 1, HO.MartesFinal.Value.Hours, HO.MartesFinal.Value.Minutes, HO.MartesFinal.Value.Seconds);
                dateTimePicker_MiercolesInicio.Value = new DateTime(2000, 12, 1, HO.MiercolesInicio.Value.Hours, HO.MiercolesInicio.Value.Minutes, HO.MiercolesInicio.Value.Seconds);
                dateTimePicker_MiercolesFinal.Value = new DateTime(2000, 12, 1, HO.MiercolesFinal.Value.Hours, HO.MiercolesFinal.Value.Minutes, HO.MiercolesFinal.Value.Seconds);
                dateTimePicker_JuevesInicio.Value = new DateTime(2000, 12, 1, HO.JuevesInicio.Value.Hours, HO.JuevesInicio.Value.Minutes, HO.JuevesInicio.Value.Seconds);
                dateTimePicker_JuevesFinal.Value = new DateTime(2000, 12, 1, HO.JuevesFinal.Value.Hours, HO.JuevesFinal.Value.Minutes, HO.JuevesFinal.Value.Seconds);
                dateTimePicker_ViernesInicio.Value = new DateTime(2000, 12, 1, HO.ViernesInicio.Value.Hours, HO.ViernesInicio.Value.Minutes, HO.ViernesInicio.Value.Seconds);
                dateTimePicker_ViernesFinal.Value = new DateTime(2000, 12, 1, HO.ViernesFinal.Value.Hours, HO.ViernesFinal.Value.Minutes, HO.ViernesFinal.Value.Seconds);
                dateTimePicker_SabadoInicio.Value = new DateTime(2000, 12, 1, HO.SabadoInicio.Value.Hours, HO.SabadoInicio.Value.Minutes, HO.SabadoInicio.Value.Seconds);
                dateTimePicker_SabadoFinal.Value = new DateTime(2000, 12, 1, HO.SabadoFinal.Value.Hours, HO.SabadoFinal.Value.Minutes, HO.SabadoFinal.Value.Seconds);
                dateTimePicker_DomingoInicio.Value = new DateTime(2000, 12, 1, HO.DomingoInicio.Value.Hours, HO.DomingoInicio.Value.Minutes, HO.DomingoInicio.Value.Seconds);
                dateTimePicker_DomingoFinal.Value = new DateTime(2000, 12, 1, HO.DomingoFinal.Value.Hours, HO.DomingoFinal.Value.Minutes, HO.DomingoFinal.Value.Seconds);
            }
        }

        private void Button_Guardar_Click(object sender, EventArgs e)
        {
            try {
                TimeSpan LI, LF, MI, MF, MII, MIF, JI, JF, VI, VF, SI, SF, DI, DF;
                LI = new TimeSpan(dateTimePicker_LunesInicio.Value.Hour, dateTimePicker_LunesInicio.Value.Minute, dateTimePicker_LunesInicio.Value.Second);
                LF = new TimeSpan(dateTimePicker_LunesFinal.Value.Hour, dateTimePicker_LunesFinal.Value.Minute, dateTimePicker_LunesFinal.Value.Second);
                MI = new TimeSpan(dateTimePicker_MartesInicio.Value.Hour, dateTimePicker_MartesInicio.Value.Minute, dateTimePicker_MartesInicio.Value.Second);
                MF = new TimeSpan(dateTimePicker_MartesFinal.Value.Hour, dateTimePicker_MartesFinal.Value.Minute, dateTimePicker_MartesFinal.Value.Second);
                MII = new TimeSpan(dateTimePicker_MiercolesInicio.Value.Hour, dateTimePicker_MiercolesInicio.Value.Minute, dateTimePicker_MiercolesInicio.Value.Second);
                MIF = new TimeSpan(dateTimePicker_MiercolesFinal.Value.Hour, dateTimePicker_MiercolesFinal.Value.Minute, dateTimePicker_MiercolesFinal.Value.Second);
                JI = new TimeSpan(dateTimePicker_JuevesInicio.Value.Hour, dateTimePicker_JuevesInicio.Value.Minute, dateTimePicker_JuevesInicio.Value.Second);
                JF = new TimeSpan(dateTimePicker_JuevesFinal.Value.Hour, dateTimePicker_JuevesFinal.Value.Minute, dateTimePicker_JuevesFinal.Value.Second);
                VI = new TimeSpan(dateTimePicker_ViernesInicio.Value.Hour, dateTimePicker_ViernesInicio.Value.Minute, dateTimePicker_ViernesInicio.Value.Second);
                VF = new TimeSpan(dateTimePicker_ViernesFinal.Value.Hour, dateTimePicker_ViernesFinal.Value.Minute, dateTimePicker_ViernesFinal.Value.Second);
                SI = new TimeSpan(dateTimePicker_SabadoInicio.Value.Hour, dateTimePicker_SabadoInicio.Value.Minute, dateTimePicker_SabadoInicio.Value.Second);
                SF = new TimeSpan(dateTimePicker_SabadoFinal.Value.Hour, dateTimePicker_SabadoFinal.Value.Minute, dateTimePicker_SabadoFinal.Value.Second);
                DI = new TimeSpan(dateTimePicker_DomingoInicio.Value.Hour, dateTimePicker_DomingoInicio.Value.Minute, dateTimePicker_DomingoInicio.Value.Second);
                DF = new TimeSpan(dateTimePicker_DomingoFinal.Value.Hour, dateTimePicker_DomingoFinal.Value.Minute, dateTimePicker_DomingoFinal.Value.Second);
                if (db.HorarioOperaciones.Where(x => x.IdCliente == this.IdCliente).Any())
                {
                    Model.HorarioOperaciones HO = db.GetHorarioOperaciones(this.IdCliente).First();
                    db.UpdateHorarioOperaciones(HO.Id,HO.IdCliente,DI,DF,LI,
                        LF,MI,MF,MII,MIF,
                        JI,JF,VI,VF,SI,
                        SF);
                }
                else {
                    db.InsertHorarioOperaciones(Guid.NewGuid(), this.IdCliente, DI, DF, LI,
                    LF, MI, MF, MII, MIF,
                    JI, JF, VI, VF, SI,
                    SF, true, DateTime.Now, this.IdUsuario);
                }
                MetroFramework.MetroMessageBox.Show(this, "Se ha guardado correctamente el horario!.", "Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {                
                MetroFramework.MetroMessageBox.Show(this,ex.Message+"\n"+ex.InnerException,"Hubo un error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }
    }
}
