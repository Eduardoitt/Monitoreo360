using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Dashboard.Tools
{
    public class CFDI
    {
        
        public void CancelarCFDI(Guid Adeudo)
        {

        }
        public static Dictionary<string, string> LeerCFDI(string XML)
        {
            XmlDocument xDoc = new XmlDocument();
            var Datos = new Dictionary<string, string>();
            Datos["CadenaOriginal"] = "||1.0|";
            string QR = "?re=";
            string fmt = "0000000###.##0000";
            double monto = 0;
            xDoc.Load(XML);
            XmlNodeList cfdi = xDoc.GetElementsByTagName("cfdi:Comprobante");
           /* XmlNodeList Emisor = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Emisor");
            X/*mlNodeList Receptor = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Receptor");*/
            XmlNodeList Conceptos = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Conceptos");
            XmlNodeList Impuestos = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Impuestos");
            XmlNodeList Complemento = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Complemento");
            Datos["descripcion"] = "";
            Datos["cantidad"] = "";
            Datos["unidad"] = "";
            Datos["valorUnitario"] = "";
            Datos["importe"] = "";
            foreach (XmlElement nodo in Conceptos)
            {
                XmlNodeList conceptos = nodo.GetElementsByTagName("cfdi:Concepto");
                foreach (XmlElement concepto in conceptos)
                {
                    string descripcion = concepto.GetAttribute("descripcion");
                    Datos["descripcion"] = Datos["descripcion"] + descripcion + "\n";
                    string cantidad = concepto.GetAttribute("cantidad");
                    Datos["cantidad"] = Datos["cantidad"] + cantidad + "\n";
                    string unidad = concepto.GetAttribute("unidad");
                    Datos["unidad"] = Datos["unidad"] + unidad + "\n";
                    string valorUnitario = concepto.GetAttribute("valorUnitario");
                    Datos["valorUnitario"] = Datos["valorUnitario"] + "$ " + valorUnitario + "\n";
                    string importe = concepto.GetAttribute("importe");
                    Datos["importe"] = Datos["importe"] + "$ " + importe + "\n";
                }
            }
            //-----------------------------------------------------------------------------------------
            foreach (XmlElement nodo in cfdi)
            {
                string fecha = nodo.GetAttribute("Fecha");
                Datos["FechaComprobante"] = fecha;
                string noCertificado = nodo.GetAttribute("NoCertificado");
                Datos["noCertificado"] = noCertificado;                
                string Moneda = nodo.GetAttribute("Moneda");
                Datos["Moneda"] = Moneda;
                string LugarExpedicion = nodo.GetAttribute("LugarExpedicion");
                Datos["LugarExpedicion"] = LugarExpedicion;               
                string formaDePago = nodo.GetAttribute("FormaPago");
                Datos["formaDePago"] = formaDePago;
                string metodoDePago = nodo.GetAttribute("MetodoPago");
                Datos["metodoDePago"] = metodoDePago;
                string subTotal = nodo.GetAttribute("SubTotal");
                Datos["subTotal"] = subTotal;
                string total = nodo.GetAttribute("Total");
                Datos["total"] = total;
                monto = float.Parse(total);
            }
            //-----------------------------------------------------------------------------------------
           /* foreach (XmlElement nodo in Emisor)
            {
                string rfc = nodo.GetAttribute("rfc");
                Datos["EmisorRFC"] = rfc;
                QR = QR + rfc;
                string nombre = nodo.GetAttribute("nombre");
                Datos["EmisorNombre"] = nombre;
                XmlNodeList domicilioFiscal = nodo.GetElementsByTagName("cfdi:DomicilioFiscal");
                XmlNodeList RegimeFiscal = nodo.GetElementsByTagName("cfdi:RegimenFiscal");
                foreach (XmlElement domicilio in domicilioFiscal)
                {
                    string calle = domicilio.GetAttribute("calle");
                    string noExterior = domicilio.GetAttribute("noExterior");
                    string noInterior = domicilio.GetAttribute("noInterior");
                    string colonia = domicilio.GetAttribute("colonia");
                    string municipio = domicilio.GetAttribute("municipio");
                    string estado = domicilio.GetAttribute("estado");
                    string pais = domicilio.GetAttribute("pais");
                    string codigoPostal = domicilio.GetAttribute("codigoPostal");
                    Datos["DomicilioFiscal"] = calle + " " + noExterior + " " + noInterior + "\n" + colonia + " " + codigoPostal + "\n" + municipio + ", " + estado + " " + pais;

                }
                foreach (XmlElement Regimen in RegimeFiscal)
                {
                    string regimen = Regimen.GetAttribute("Regimen");
                    Datos["Regimen"] = regimen;
                    Console.WriteLine("Regimen:" + regimen);
                }
            }*/
            //-------------------------------------------------------------------------------------------
            /*foreach (XmlElement nodo in Receptor)
            {
                string RFCRepcetor = nodo.GetAttribute("rfc");
                Datos["ReceptorRFC"] = RFCRepcetor;
                string nombre = nodo.GetAttribute("nombre");
                Datos["ReceptorNombre"] = nombre;
                XmlNodeList domicilioReceptor = nodo.GetElementsByTagName("cfdi:Domicilio");
                foreach (XmlElement domicilio in domicilioReceptor)
                {
                    string calle = domicilio.GetAttribute("calle");
                    string noExterior = domicilio.GetAttribute("noExterior");
                    string colonia = domicilio.GetAttribute("colonia");
                    string municipio = domicilio.GetAttribute("municipio");
                    string estado = domicilio.GetAttribute("estado");
                    string pais = domicilio.GetAttribute("pais");
                    string codigoPostal = domicilio.GetAttribute("codigoPostal");
                    Datos["ReceptorDomicilio"] = calle + " " + noExterior + " " + colonia + " C.P " + codigoPostal + " " + municipio + "," + estado + " " + pais;
                }

                QR = QR + "&rr=" + RFCRepcetor;
            }*/
            //------------------------------------------------------------------------------------
            /*foreach (XmlElement nodo in Impuestos)
            {
                string totalImpuestosTrasladados = nodo.GetAttribute("totalImpuestosTrasladados");
                Datos["totalImpuestosTrasladados"] = totalImpuestosTrasladados;
            }*/
            //-------------------------------------------------------------------------------------------
            QR = QR + "&tt=" + monto.ToString(fmt);
            ///------------------------------------------------------------------------------------------
            foreach (XmlElement nodo in Complemento)
            {
                XmlNodeList TimbreFiscalDigital = nodo.GetElementsByTagName("tfd:TimbreFiscalDigital");
                foreach (XmlElement TimbreFiscal in TimbreFiscalDigital)
                {
                    
                    string noCertificadoSAT = TimbreFiscal.GetAttribute("NoCertificadoSAT");
                    Datos["noCertificadoSAT"] = noCertificadoSAT;
                    string FechaTimbrado = TimbreFiscal.GetAttribute("FechaTimbrado");
                    Datos["FechaTimbrado"] = FechaTimbrado;
                    string selloCFD = TimbreFiscal.GetAttribute("SelloCFD");
                    Datos["selloCFD"] = selloCFD;
                    string selloSAT = TimbreFiscal.GetAttribute("SelloSAT");
                    Datos["SelloSAT"] = selloSAT;
                }
            }
            //Datos["CadenaOriginal"] = Datos["CadenaOriginal"] + Datos["UUID"] + "|" + Datos["FechaTimbrado"] + "|" + Datos["selloCFD"] + "|" + Datos["noCertificadoSAT"] + "||";
            //-------------------------------------------------------------------------------------------
            return Datos;
        }
    }
}