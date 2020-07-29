﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using RVCFDI33;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net;
using System.IO;
using iTextSharp.text.html.simpleparser;
using Dashboard.Tools;
using System.Globalization;

namespace Dashboard.Controllers
{
    public class NominaController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        // GET: Nomina
        public ActionResult Index()
        {
            NominaView NominaView = new NominaView();
            NominaView.PAC = db.GetPAC(null,0).ToList();
            NominaView.RiesgoPuesto = db.RiesgoPuesto.ToList();
            NominaView.Jornadas = db.Jornadas.ToList();
            NominaView.Contratos = db.Contratos.ToList();
            NominaView.Estados = db.Estados.ToList();
            NominaView.PeriodicidadPago = db.PeriodicidadPago.ToList();
            NominaView.Deducciones = db.Deducciones.ToList();
            NominaView.OtrosPagos = db.OtrosPagos.ToList();
            NominaView.Horas = db.Horas.ToList();

           /* GetPAC_Result PAC = db.GetPAC(Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16"), 1).First();
            var base64 = Convert.ToBase64String(PAC.Logo);
            Tools.NumLetra n = new NumLetra();
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            PDF.CrearNomina(Server.MapPath("~/"), "ABG1512109U1", "AVENZO BUSINESS GROUP S de RL de CV", "", "﴾664﴿ 526‐65‐73",
                "6022641f‐e2bb‐42c4‐ab55‐2e55c682e6b8", "1000001200001456","","","","",
                "","","", imgSrc,"SARC9501HBCN01","10000111000",
                "1","","","",n.Convertir("25.2",true,"MXN"),
                "01","12334","601","25","25","25",
                "25","",new List<NominaPercepciones>(),new List<NominaDeduccion>());*/
            return PartialView(NominaView);
        }
        public ActionResult A()
        {
            Guid IdNominaHistorial = Guid.Parse("a272c363-4fef-4579-bbf7-29834d9c7a9e");
            var base64 = "";
                base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png")));
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            NumLetra NL = new NumLetra();
            List<NominaPercepciones> Percepciones = db.NominaPercepciones.Where(x=>x.IdNominaHistorial==IdNominaHistorial).ToList();
            List<NominaDeduccion> Deducciones = db.NominaDeduccion.Where(x => x.IdNominaHistorial == IdNominaHistorial).ToList();
            byte[] CFDI = System.IO.File.ReadAllBytes(@"C:\Users\Ivan\Desktop\Avenzo\Dashboard\Facturas\CHP050224NF5\Nominas\AELS8511267R1_11_2017914.xml");
            db.InsertCFDI(Guid.Parse("235e282b-3ebf-4d23-a3a9-518f19d52b54"),"Nomina",11,CFDI, @"~\Facturas\CHP050224NF5\Nominas\AELS8511267R1_11_2017914",null,Guid.Parse("71eea78e-8ce4-43fe-9038-24c2c0634a40"),Guid.Parse("F34D8F7B-6007-42E6-AD3B-108DDE81ABC2"),false,DateTime.Now,User.Identity.Name);
            db.InsertCFDIPorOperacion(Guid.NewGuid(),IdNominaHistorial,null,Guid.Parse("235e282b-3ebf-4d23-a3a9-518f19d52b54"));
            PDF.CrearNomina(Server.MapPath("~/"), "AELS8511267R1_11_2017914", "BCN", "CHP050224NF5",
                "COLEGIO HEROES DE LA PAZ SC", "", "", "235e282b-3ebf-4d23-a3a9-518f19d52b54", "00001000000301838595","11",
                "B", "2017-09-12T08:45:37", "Silvia Lopez Aceves", "", "AELS8511267R1",
                "Maestra", imgSrc, "AELS851126MSLCPL05", "71048536305", "15", "2017-09-01",
                "2017-08-16", "2017-08-31", NL.Convertir((3412.56).ToString("f2"),true,"MXN"), "NA","",
                "601", "309.63", "3412.56", "W1blIja4rrIfuxICgTvC1zH1/fjwuSN9ehcM5IBSmEgaYOF5VN/6c2MFekxla1P2MPDqS+e89EKebWLShKaOKVvcnMpcr+bLrR6L7sWtKsRt9wgB8DvRc6pxTgu4YW4wRkSZ2kSxkrjoCq99JRlO7WhK+9xSEy+NCHjvkt5k530=", "g4zsOUQv7H+ORiZr+FB9kBRgk9YLpNUwIv1FDKmPubu0Z4cDM0X0tgwpmcie5AlgKm86yTd6p5A5AeI66ASCNrU4aWXwz/429+JEeXvxGRMCSFh7Oznmd6sGR4o9U50QTknKq9US254JeFcNFIsHZxgZYR63uoajCrgF/q07zpI=", "||3.3|A|11|2017-09-14T09:09:35|99|00001000000301838595|3778.00|365.44|MXN|3412.56|N|PUE|22210|CHP050224NF5|COLEGIO HEROES DE LA PAZ SC|601|AELS8511267R1|Silvia Lopez Aceves|P01|84111505|1|ACT|Pago de nómina|3778.00|3778.00|365.44|1.2|O|2017-09-01|2017-08-16|2017-08-31|15|3778.00|365.44|0|Z3113823101|AELS851126MSLCPL05|71048536305|2017-08-16|P2W|01|No|01|02|12|Maestra|1|04|0|186.05|BCN|3778.00|0|0|3778.00|0.00|001|001|Sueldo|2670.00|0.00|049|049|Bono Asistencia|298.00|0.00|049|049|Bono Puntualidad|298.00|0.00|029|029|Despensa|512.00|0.00|55.81|309.63|002|002|ISR|309.63|001|001|IMSS|55.81||",
                Percepciones,Deducciones);
            return null;
        }
       
        public ActionResult Guardar() {
            Guid IdNominaHistorial = Guid.Parse(Request.Params["IdNominaHistorial"]);
            Guid IdProveedor = Guid.Parse(Request.Params["PAC"]);
            string idEmpleado = Request.Params["IdEmpleado"];
            if(idEmpleado==string.Empty || idEmpleado == null)            
                idEmpleado = Guid.NewGuid().ToString();

            Guid IdEmpleado = Guid.Parse(idEmpleado);
            
            db.InsertNominaHistorial(IdNominaHistorial,IdProveedor,IdEmpleado,"","",
                DateTime.Now,DateTime.Now,DateTime.Now,1,
                "","MXN","","",DateTime.Now,User.Identity.Name);
            return Json(new{ error="none"},JsonRequestBehavior.AllowGet);
        }
        public ActionResult Generar(Guid IdNominaHistorial)
        {                       
            NominaHistorial nominaHistorial = db.GetNominaHistorial(1,IdNominaHistorial).First();
            Empleados Empleado = db.GetEmpleados(1, nominaHistorial.IdEmpleado).First();            
            GetPAC_Result PAC = db.GetPAC(nominaHistorial.IdProveedor,1).First();
            List<NominaDeduccion> NominaDeducciones = db.NominaDeduccion.Where(x=>x.IdNominaHistorial==IdNominaHistorial).ToList();
            List<NominaPercepciones> NominaPercepciones = db.NominaPercepciones.Where(x => x.IdNominaHistorial == IdNominaHistorial).ToList();
            List<Model.CFDI> CFDIs = db.GetCFDI(null, 0).Where(x => x.IdProveedor == PAC.Id).ToList();
            
            int FolioFactura = 1;
            if (CFDIs.Count > 0)
                FolioFactura = CFDIs.Max(x => x.Folio).Value+1;
                            
            GeneraCFDI obj = new GeneraCFDI();
            string PATH = "~/Certificados/" + PAC.RFC;
            string CER=Server.MapPath(PATH + "/" + PAC.RFC + ".cer");
            string KEY = Server.MapPath(PATH + "/" + PAC.RFC + ".key");
            obj.agregarCertificado(CER);
            double SubTotal = NominaPercepciones.Sum(x => x.ImporteGravado + x.ImporteExcento).Value;
            double Descuento = NominaDeducciones.Sum(x => x.Importe);
            double OtrosPagos = 0;
            double TotalImpuestosRetenidos = NominaDeducciones.Where(x => x.Tipo.Contains("002")).Sum(x => x.Importe);
            double TotalOtrasDeducciones = NominaDeducciones.Where(x => !x.Tipo.Contains("002")).Sum(x => x.Importe);
            obj.agregarComprobante33("A",""+FolioFactura, System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), "99","", SubTotal, Descuento,"MXN","",SubTotal-Descuento,"N", "PUE","22210","");
            obj.agregarEmisor(PAC.RFC,PAC.Nombre,PAC.RegimenFiscal);
            TimeSpan Time = (nominaHistorial.FechaFinalPago - Empleado.FechaInicioRelLaboral.Value);
            DateTime A = new DateTime();
            A = A + Time;
            
            int Semanas = Time.Days / 7;
            string Antiguedad = "P" +Semanas+ "W";
            int DiasDeVacaciones = CalcularDiasDeVacaciones(A);          
            string SalarioDiarioIntegrado = ((double)(((365+15+(DiasDeVacaciones*0.25))/365)*Empleado.SalarioDiario)).ToString("f2");
            obj.agregarReceptor(Empleado.RFC,Empleado.Nombre+" "+Empleado.ApellidoPaterno+" "+Empleado.ApellidoMaterno,"","","P01");
            obj.agregarConcepto("84111505", "", 1, "ACT", "", "Pago de nómina", NominaPercepciones.Sum(x => x.ImporteGravado).Value, NominaPercepciones.Sum(x => x.ImporteGravado).Value, NominaDeducciones.Sum(x=>x.Importe));
            //Nomina
            obj.agregarNomina12("1.2","O",nominaHistorial.FechaPago.ToString("yyyy-MM-dd"), nominaHistorial.FechaInicialPago.ToString("yyyy-MM-dd"),
                nominaHistorial.FechaFinalPago.ToString("yyyy-MM-dd"),nominaHistorial.NumeroDiasPagados.ToString(),SubTotal.ToString("f2"),Descuento.ToString("f2"), "0");
            obj.agregarNominaEmisor12(PAC.CURP,PAC.RegistroPatronal,PAC.RfcPatronOrigen);           
            obj.agregarNominaReceptor12(Empleado.CURP, Empleado.NumeroSeguridadSocial, Empleado.FechaInicioRelLaboral.Value.ToString("yyyy-MM-dd"), Antiguedad,
                    Empleado.TipoContrato, "No", Empleado.TipoJornada, "02", Empleado.NoEmpleado.ToString(),
                    Empleado.Departamento, Empleado.Puesto, Empleado.RiesgoPuesto, nominaHistorial.PeriodicidadPago, Empleado.Banco, Empleado.CuentaBancaria,
                    "0", SalarioDiarioIntegrado, Empleado.ClaveEntFed);
            
            double TotalPercepciones = NominaPercepciones.Sum(x => x.ImporteGravado + x.ImporteExcento).Value,TotalPercepcionesTemp=0;
            obj.agregarNominaPercepciones12(NominaPercepciones.Sum(x => x.ImporteGravado+x.ImporteExcento).Value.ToString("f2"), "0", "0", NominaPercepciones.Sum(x=>x.ImporteGravado).Value.ToString("f2"), NominaPercepciones.Sum(x => x.ImporteExcento).Value.ToString("f2"));
            foreach (var item in NominaPercepciones) {
                obj.agregarNominaPercepcionesPercepcion12(item.Tipo,item.Clave, item.Concepto, item.ImporteGravado.Value.ToString("f2"),item.ImporteExcento.Value.ToString("f2"));
                TotalPercepcionesTemp += item.ImporteGravado.Value + item.ImporteExcento.Value;
            }
            
            obj.agregarNominaDeducciones12(TotalOtrasDeducciones.ToString("f2"),TotalImpuestosRetenidos.ToString("f2"));
            foreach (var item in NominaDeducciones ) 
                obj.agregarNominaDeduccionesDeduccion12(item.Tipo,item.Clave, item.Concepto, item.Importe.ToString("f2"));
          
            obj.GeneraXML(KEY,PAC.ContrasenaLlave);
            string XML = obj.Xml.Replace("Sello=\"\"", "Sello=\"" + obj.SelloEmisor + "\"");
            //obj.UUID;
            //obj.Serie;
            string NombreArchivo = Empleado.RFC + "_" + FolioFactura + "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day+"_SinTimbrar";
            string File = Server.MapPath("~/Facturas/" + PAC.RFC + "/Nominas/" +NombreArchivo  + ".xml");
            Tools.NumLetra NL =new Tools.NumLetra();
            System.IO.File.WriteAllText(File, XML);
            byte[] CFDI;
            obj.TimbrarCfdiArchivo(File, PAC.Usuario, PAC.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx",File.Replace(NombreArchivo+".xml",""), NombreArchivo.Replace("_SinTimbrar",""), true);
            if (obj.MensajeError == "")
            {
                System.IO.File.WriteAllText(File.Replace("_SinTimbrar",""), obj.XmlTimbrado);
                CFDI = System.IO.File.ReadAllBytes(File.Replace("_SinTimbrar", ""));
                db.InsertCFDI(Guid.Parse(obj.UUID), "Nomina", FolioFactura, CFDI,"~\\Facturas\\"+PAC.RFC+"\\Nominas\\"+NombreArchivo.Replace("_SinTimbrar.xml",""),
                    null,Empleado.Id, PAC.Id, false, DateTime.Now, User.Identity.Name);
                var base64 = "";
                if (PAC.Logo != null)
                    base64 = Convert.ToBase64String(PAC.Logo);
                else
                    base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png")));
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                db.InsertCFDIPorOperacion(Guid.NewGuid(),IdNominaHistorial,null,Guid.Parse(obj.UUID));
                CultureInfo CI = CultureInfo.CreateSpecificCulture("es-MX");
                PDF.CrearNomina(Server.MapPath("/"), NombreArchivo, nominaHistorial.LugarExpedicion, PAC.RFC, PAC.Nombre, "", "", obj.UUID,
                    obj.NoCertificadoPac, obj.Folio, obj.Serie, obj.FechaEmision, Empleado.Nombre + " " + Empleado.ApellidoPaterno + " " + Empleado.ApellidoMaterno,
                    Empleado.Departamento, Empleado.RFC, Empleado.Puesto, imgSrc, Empleado.CURP, Empleado.NumeroSeguridadSocial,
                    nominaHistorial.NumeroDiasPagados.ToString(), nominaHistorial.FechaPago.ToString("yyyy-MM-dd"), nominaHistorial.FechaInicialPago.ToString("yyyy-MM-dd"), nominaHistorial.FechaFinalPago.ToString("yyyy-MM-dd"), NL.Convertir((SubTotal - Descuento).ToString("f2"), true, "MXN"),
                    "NA", Empleado.CuentaBancaria, PAC.RegimenFiscal,TotalImpuestosRetenidos.ToString("C2",CI), (SubTotal - Descuento).ToString("C2",CI),obj.SelloEmisor,
                    obj.SelloSat, obj.CadenaOriginal, NominaPercepciones, NominaDeducciones);
                return Json(new { error = "none", Id = obj.UUID }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new {error="Error a Timbrar",Message=obj.MensajeError },JsonRequestBehavior.AllowGet);
            }

        }
        public int CalcularDiasDeVacaciones(DateTime Antiguedad) {
            int Dias =4,A=1,i=0;
            for (i=1; i<=(Antiguedad.Year-1);i++) {
                if ((Antiguedad.Year-1) < 5)
                {
                    Dias +=2;
                }
                else {
                    if (i < 5)
                    {
                        Dias += 2;
                    }
                    else
                    {
                        if (A == 5)
                        {
                            A = 1;
                            Dias += 2;
                        }
                        A++;
                    }
                }
                
            }
            if ((i-1) % 5 == 0)
                Dias += 2;
            return Dias;
        }
    }
}