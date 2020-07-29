using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using iTextSharp.text;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Net;
namespace Avenzo.Models
{
    class CFDI
    {
        private static AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private static int BORDER = 0;
        
        //------------FACTURA-------------------------------
        public static void CrearFactura(string PATH, string Archivo)
        {
            var Datos = LeerCFDI(PATH + Archivo + ".xml");
            Font font = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL);
            Font sellos = new Font(Font.FontFamily.HELVETICA, 5, Font.NORMAL);
            Font textBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(PATH + Archivo + ".pdf", FileMode.Create));

            doc.AddTitle("Factura Electronica");
            doc.AddCreator("Avenzo Proteccion");
            doc.AddAuthor("Cristian Santiago Rosas");

            doc.Open();
            iTextSharp.text.Image avenzo = iTextSharp.text.Image.GetInstance("~/Images/Avenzo_Logo_Header.png");
            iTextSharp.text.pdf.PdfPTable Header = new iTextSharp.text.pdf.PdfPTable(12);
            float[] widths = new float[] { .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f };
            iTextSharp.text.Rectangle page = doc.PageSize;
            Header.WidthPercentage = 80;
            Header.LockedWidth = true;
            Header.SetWidths(widths);
            Header.TotalWidth = page.Width - 90;
            //---------------------------------------------
            //-----------CABEZERA DEL DOCUMENTO------------
            //---------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell();//--Logo
            cell.AddElement(avenzo);
            cell.Colspan = 4;
            cell.Border = BORDER;

            iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell2.AddElement(new iTextSharp.text.Paragraph(Datos["EmisorNombre"] + "\n" + Datos["EmisorRFC"] + "\nDomicilio Fiscal\n" + Datos["DomicilioFiscal"] + "\nTel. 6645266573", new Font(Font.FontFamily.HELVETICA, 5, Font.BOLD)));
            cell2.Colspan = 4;
            cell2.Border = BORDER;
            cell2.HorizontalAlignment = 1;
            Header.AddCell(cell);
            Header.AddCell(cell2);
            iTextSharp.text.pdf.PdfPCell cell51 = new iTextSharp.text.pdf.PdfPCell();
            cell51.Phrase = new Phrase("Factura No: " + Datos["folio"] + "\nFOLIO FISCAL (UUID):\n" + Datos["UUID"] + "\nNO. DE SERIE DEL CERTIFICADO DEL SAT:\n" + Datos["noCertificadoSAT"] + "\nNO. DE SERIE DEL CERTIFICADO DEL EMISOR:\n" + Datos["noCertificado"] + "\nFECHA Y HORA DE CERTIFICACIÓN:\n" + Datos["FechaTimbrado"] + "\nFECHA Y HORA DE EMISIÓN DE CFDI:\n" + Datos["FechaComprobante"], textBold);
            cell51.HorizontalAlignment = Element.ALIGN_CENTER;
            cell51.Colspan = 4;
            Header.AddCell(cell51);
            iTextSharp.text.pdf.PdfPCell salto = new iTextSharp.text.pdf.PdfPCell();
            salto.AddElement(new Chunk("\n"));
            salto.Colspan = 12;
            salto.Border = BORDER;
            Header.AddCell(salto);
            //---------------------------------------------
            //------------DATOS CLIENTE-------------------
            //---------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell4 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell4.Colspan = 1;
            cell4.Border = BORDER;
            cell4.PaddingTop = 0;
            cell4.PaddingBottom = 0;
            cell4.AddElement(new Paragraph("Cliente:", textBold));
            iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell5.Colspan = 2;
            cell5.PaddingTop = 0;
            cell5.PaddingBottom = 0;
            cell5.Border = BORDER;
            cell5.AddElement(new Paragraph(Datos["ReceptorNombre"], font));
            iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell6.Colspan = 2;
            cell6.Border = BORDER;
            cell6.PaddingTop = 0;
            cell6.PaddingBottom = 0;
            cell6.AddElement(new Paragraph("Régimen Fiscal:", textBold));
            iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell7.Colspan = 7;
            cell7.Border = BORDER;
            cell7.PaddingTop = 0;
            cell7.PaddingBottom = 0;
            cell7.AddElement(new Paragraph(Datos["Regimen"], font));
            iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell8.Colspan = 1;
            cell8.Border = BORDER;
            cell8.PaddingTop = 0;
            cell8.PaddingBottom = 0;
            cell8.AddElement(new Paragraph("RFC:", textBold));
            iTextSharp.text.pdf.PdfPCell cell9 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell9.Colspan = 2;
            cell9.Border = BORDER;
            cell9.PaddingTop = 0;
            cell9.PaddingBottom = 0;
            cell9.AddElement(new Paragraph(Datos["ReceptorRFC"], font));
            iTextSharp.text.pdf.PdfPCell cell10 = new iTextSharp.text.pdf.PdfPCell();
            cell10.Colspan = 2;
            cell10.Border = BORDER;
            cell10.PaddingBottom = 0;
            cell10.PaddingTop = 0;
            cell10.AddElement(new Paragraph("Lugar de Expedición:", textBold));
            iTextSharp.text.pdf.PdfPCell cell11 = new iTextSharp.text.pdf.PdfPCell();
            cell11.Colspan = 3;
            cell11.Border = BORDER;
            cell11.PaddingTop = 0;
            cell11.PaddingBottom = 0;
            cell11.AddElement(new Paragraph(Datos["LugarExpedicion"], font));
            iTextSharp.text.pdf.PdfPCell cell12 = new iTextSharp.text.pdf.PdfPCell();
            cell12.AddElement(new Paragraph("Fecha de Expedicion:", textBold));
            cell12.Colspan = 2;
            cell12.Border = BORDER;
            cell12.PaddingBottom = 0;
            cell12.PaddingTop = 0;
            iTextSharp.text.pdf.PdfPCell cell13 = new iTextSharp.text.pdf.PdfPCell();
            cell13.Colspan = 3;
            cell13.Border = BORDER;
            cell13.PaddingTop = 0;
            cell13.PaddingBottom = 0;
            DateTime time = DateTime.Parse(Datos["FechaComprobante"]);
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            cell13.AddElement(new Paragraph(time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " del " + time.ToString("yyyy", ci), font));
            //---
            iTextSharp.text.pdf.PdfPCell cell14 = new iTextSharp.text.pdf.PdfPCell();
            cell14.Colspan = 1;
            cell14.Rowspan = 2;
            cell14.PaddingTop = 0;
            cell14.PaddingBottom = 0;
            cell14.Border = BORDER;
            cell14.AddElement(new Paragraph("Direccion:", textBold));
            iTextSharp.text.pdf.PdfPCell cell15 = new iTextSharp.text.pdf.PdfPCell();
            cell15.Colspan = 2;
            cell15.Rowspan = 2;
            cell15.Border = BORDER;
            cell15.PaddingBottom = 0;
            cell15.PaddingTop = 0;
            cell15.AddElement(new Paragraph(Datos["ReceptorDomicilio"], font));
            iTextSharp.text.pdf.PdfPCell cell16 = new iTextSharp.text.pdf.PdfPCell();
            cell16.Colspan = 2;
            cell16.PaddingTop = 0;
            cell16.PaddingBottom = 0;
            cell16.AddElement(new Paragraph("Forma De Pago:", textBold));
            cell16.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell17 = new iTextSharp.text.pdf.PdfPCell();
            cell17.PaddingBottom = 0;
            cell17.PaddingTop = 0;
            cell17.Colspan = 3;
            cell17.Border = BORDER;
            cell17.AddElement(new Paragraph(Datos["formaDePago"], font));
            iTextSharp.text.pdf.PdfPCell cell18 = new iTextSharp.text.pdf.PdfPCell();
            cell18.AddElement(new Paragraph("Clave Moneda:", textBold));
            cell18.Colspan = 2;
            cell18.Border = BORDER;
            cell18.PaddingTop = 0;
            cell18.PaddingBottom = 0;
            iTextSharp.text.pdf.PdfPCell cell19 = new iTextSharp.text.pdf.PdfPCell();
            cell19.Colspan = 2;
            cell19.Border = BORDER;
            cell19.PaddingBottom = 0;
            cell19.PaddingTop = 0;
            cell19.AddElement(new Paragraph(Datos["Moneda"], font));
            iTextSharp.text.pdf.PdfPCell cell20 = new iTextSharp.text.pdf.PdfPCell();
            cell20.Colspan = 2;
            cell20.Border = BORDER;
            cell20.PaddingTop = 0;
            cell20.PaddingBottom = 0;
            cell20.AddElement(new Paragraph("Método de Pago:", textBold));
            iTextSharp.text.pdf.PdfPCell cell21 = new iTextSharp.text.pdf.PdfPCell();
            cell21.Colspan = 3;
            cell21.Border = BORDER;
            cell21.PaddingTop = 0;
            cell21.PaddingBottom = 0;
            cell21.AddElement(new Paragraph(Datos["metodoDePago"], font));
            iTextSharp.text.pdf.PdfPCell cell22 = new iTextSharp.text.pdf.PdfPCell();
            cell22.Colspan = 2;
            cell22.Border = BORDER;
            cell22.PaddingTop = 0;
            cell22.PaddingBottom = 0;
            cell22.AddElement(new Paragraph("NumCtaPago:", textBold));
            iTextSharp.text.pdf.PdfPCell cell23 = new iTextSharp.text.pdf.PdfPCell();
            cell23.Colspan = 2;
            cell23.Border = BORDER;
            cell23.PaddingTop = 0;
            cell23.PaddingBottom = 0;
            cell23.AddElement(new Paragraph(Datos["NumCtaPago"], font));
            //----------------------------------------------
            //-----------------PRODUCTOS--------------------
            //----------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell24 = new iTextSharp.text.pdf.PdfPCell();
            cell24.Colspan = 1;
            cell24.AddElement(new Paragraph("Cantidad", textBold));
            iTextSharp.text.pdf.PdfPCell cell25 = new iTextSharp.text.pdf.PdfPCell();
            cell25.Colspan = 1;
            cell25.AddElement(new Paragraph("Unidad de Medida", textBold));
            iTextSharp.text.pdf.PdfPCell cell26 = new iTextSharp.text.pdf.PdfPCell();
            cell26.Colspan = 6;
            cell26.HorizontalAlignment = Element.ALIGN_CENTER;
            cell26.VerticalAlignment = Element.ALIGN_CENTER;
            cell26.AddElement(new Paragraph("Descripcion", textBold));
            iTextSharp.text.pdf.PdfPCell cell27 = new iTextSharp.text.pdf.PdfPCell();
            cell27.Colspan = 2;
            cell27.AddElement(new Paragraph("Producto Unitario", textBold));
            iTextSharp.text.pdf.PdfPCell cell28 = new iTextSharp.text.pdf.PdfPCell();
            cell28.Colspan = 2;
            cell28.HorizontalAlignment = Element.ALIGN_CENTER;
            cell28.VerticalAlignment = Element.ALIGN_CENTER;
            cell28.AddElement(new Paragraph("Importe", textBold));
            //-----------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell29 = new iTextSharp.text.pdf.PdfPCell();
            cell29.AddElement(new Paragraph(Datos["cantidad"], font));
            cell29.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell30 = new iTextSharp.text.pdf.PdfPCell();
            cell30.AddElement(new Paragraph(Datos["unidad"], font));
            cell30.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell31 = new iTextSharp.text.pdf.PdfPCell();
            cell31.AddElement(new Paragraph(Datos["descripcion"], font));
            cell31.Colspan = 6;
            iTextSharp.text.pdf.PdfPCell cell32 = new iTextSharp.text.pdf.PdfPCell();
            cell32.AddElement(new Paragraph(Datos["valorUnitario"], font));
            cell32.Colspan = 2;
            iTextSharp.text.pdf.PdfPCell cell33 = new iTextSharp.text.pdf.PdfPCell();
            cell33.AddElement(new Paragraph(Datos["importe"], font));
            cell33.Colspan = 2;
            cell33.FixedHeight = 200f;


            //-------------------------------------------------------
            //----------------------TOTAL----------------------------
            //-------------------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell34 = new iTextSharp.text.pdf.PdfPCell();
            cell34.Colspan = 2;
            cell34.Rowspan = 3;
            cell34.Border = BORDER;
            cell34.PaddingBottom = 0;
            cell34.PaddingTop = 0;
            cell34.AddElement(new Paragraph(""));
            iTextSharp.text.pdf.PdfPCell cell35 = new iTextSharp.text.pdf.PdfPCell();
            cell35.Colspan = 7;
            cell35.Border = BORDER;
            cell35.Rowspan = 3;
            cell35.PaddingTop = 0;
            cell35.PaddingBottom = 0;
            NumLetra nl = new NumLetra();

            cell35.AddElement(new Paragraph("IMPORTE CON LETRA: " + nl.Convertir(Datos["total"], true, false), textBold));
            iTextSharp.text.pdf.PdfPCell cell36 = new iTextSharp.text.pdf.PdfPCell();
            cell36.Colspan = 2;
            cell36.Border = BORDER;
            cell36.PaddingBottom = 0;
            cell36.PaddingTop = 0;
            cell36.Phrase = new Phrase("SubTotal:", textBold);
            cell36.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell36.VerticalAlignment = Element.ALIGN_BOTTOM;
            iTextSharp.text.pdf.PdfPCell cell37 = new iTextSharp.text.pdf.PdfPCell();
            cell37.Colspan = 1;
            cell37.Border = BORDER;
            cell37.PaddingTop = 0;
            cell37.PaddingBottom = 0;
            cell37.AddElement(new Paragraph("$ " + Datos["subTotal"], font));
            //--
            iTextSharp.text.pdf.PdfPCell cell38 = new iTextSharp.text.pdf.PdfPCell();
            cell38.Colspan = 2;
            cell38.PaddingBottom = 0;
            cell38.PaddingTop = 0;
            cell38.Border = BORDER;
            cell38.Phrase = new Phrase("IVA(IVA 16.00%):", textBold);
            cell38.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell38.VerticalAlignment = Element.ALIGN_BOTTOM;
            iTextSharp.text.pdf.PdfPCell cell39 = new iTextSharp.text.pdf.PdfPCell();
            cell39.Colspan = 1;
            cell39.PaddingTop = 0;
            cell39.PaddingBottom = 0;
            cell39.Border = BORDER;
            cell39.AddElement(new Paragraph("$ " + Datos["totalImpuestosTrasladados"], font));
            //---
            iTextSharp.text.pdf.PdfPCell cell40 = new iTextSharp.text.pdf.PdfPCell();
            cell40.Colspan = 2;
            cell40.Border = BORDER;
            cell40.VerticalAlignment = Element.ALIGN_BOTTOM;
            cell40.Phrase = new Phrase("Total:", textBold);
            cell40.PaddingBottom = 0;
            cell40.PaddingTop = 0;
            cell40.HorizontalAlignment = Element.ALIGN_RIGHT;
            iTextSharp.text.pdf.PdfPCell cell41 = new iTextSharp.text.pdf.PdfPCell();
            cell41.Colspan = 1;
            cell41.Border = BORDER;
            cell41.PaddingTop = 0;
            cell41.PaddingBottom = 0;
            cell41.AddElement(new Paragraph("$ " + Datos["total"], font));
            //---------------------------------------------------------
            //-------------------CDFI SELLOS---------------------------
            //---------------------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell42 = new iTextSharp.text.pdf.PdfPCell();
            cell42.Colspan = 10;
            cell42.Border = BORDER;
            cell42.Phrase = new Phrase("SELLO DIGITAL DEL CFDI", textBold);
            iTextSharp.text.pdf.BarcodeQRCode QR = new iTextSharp.text.pdf.BarcodeQRCode(Datos["QR"], 300, 300, null);
            Image img = QR.GetImage();
            img.SetDpi(1400, 1400);
            iTextSharp.text.pdf.PdfPCell cell43 = new iTextSharp.text.pdf.PdfPCell();
            cell43.Colspan = 2;
            cell43.Border = BORDER;
            cell43.Rowspan = 9;
            cell43.VerticalAlignment = Element.ALIGN_TOP;
            cell43.AddElement(img);
            iTextSharp.text.pdf.PdfPCell cell44 = new iTextSharp.text.pdf.PdfPCell();
            cell44.Colspan = 10;
            cell44.Phrase = new Phrase(Datos["selloCFD"], sellos);
            iTextSharp.text.pdf.PdfPCell cell45 = new iTextSharp.text.pdf.PdfPCell();
            cell45.Colspan = 10;
            cell45.Phrase = new Phrase("SELLO DIGITAL DEL SAT", textBold);
            cell45.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell46 = new iTextSharp.text.pdf.PdfPCell();
            cell46.Phrase = new Phrase(Datos["SelloSAT"], sellos);
            cell46.Colspan = 10;
            iTextSharp.text.pdf.PdfPCell cell47 = new iTextSharp.text.pdf.PdfPCell();
            cell47.Phrase = new Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT", textBold);
            cell47.Border = BORDER;
            cell47.Colspan = 10;
            iTextSharp.text.pdf.PdfPCell cell48 = new iTextSharp.text.pdf.PdfPCell();
            cell48.Colspan = 10;
            cell48.Phrase = new Phrase(Datos["CadenaOriginal"], sellos);
            iTextSharp.text.pdf.PdfPCell cell49 = new iTextSharp.text.pdf.PdfPCell();
            cell49.Colspan = 10;
            cell49.Phrase = new Phrase("");
            cell49.Border = BORDER;
            Header.AddCell(cell4);
            Header.AddCell(cell5);
            Header.AddCell(cell6);
            Header.AddCell(cell7);
            Header.AddCell(cell8);
            Header.AddCell(cell9);
            Header.AddCell(cell10);
            Header.AddCell(cell11);
            Header.AddCell(cell12);
            Header.AddCell(cell13);
            Header.AddCell(cell14);
            Header.AddCell(cell15);
            Header.AddCell(cell16);
            Header.AddCell(cell17);
            Header.AddCell(cell18);
            Header.AddCell(cell19);
            Header.AddCell(cell20);
            Header.AddCell(cell21);
            Header.AddCell(cell22);
            Header.AddCell(cell23);
            Header.AddCell(salto);
            Header.AddCell(cell24);
            Header.AddCell(cell25);
            Header.AddCell(cell26);
            Header.AddCell(cell27);
            Header.AddCell(cell28);
            Header.AddCell(cell29);
            Header.AddCell(cell30);
            Header.AddCell(cell31);
            Header.AddCell(cell32);
            Header.AddCell(cell33);
            Header.AddCell(cell34);
            Header.AddCell(cell35);
            Header.AddCell(cell36);
            Header.AddCell(cell37);
            Header.AddCell(cell38);
            Header.AddCell(cell39);
            Header.AddCell(cell40);
            Header.AddCell(cell41);
            Header.AddCell(salto);
            Header.AddCell(cell49);
            Header.AddCell(cell43);
            Header.AddCell(cell42);
            Header.AddCell(cell44);
            Header.AddCell(cell49);
            Header.AddCell(cell45);
            Header.AddCell(cell46);
            Header.AddCell(cell49);
            Header.AddCell(cell47);
            Header.AddCell(cell48);
            doc.Add(Header);
            doc.Close();
            writer.Close();
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
            XmlNodeList Emisor = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Emisor");
            XmlNodeList Receptor = ((XmlElement)cfdi[0]).GetElementsByTagName("cfdi:Receptor");
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
                string fecha = nodo.GetAttribute("fecha");
                Datos["FechaComprobante"] = fecha;
                string noCertificado = nodo.GetAttribute("noCertificado");
                Datos["noCertificado"] = noCertificado;
                string NumCtaPago = nodo.GetAttribute("NumCtaPago");
                Datos["NumCtaPago"] = NumCtaPago;
                string Moneda = nodo.GetAttribute("Moneda");
                Datos["Moneda"] = Moneda;
                string LugarExpedicion = nodo.GetAttribute("LugarExpedicion");
                Datos["LugarExpedicion"] = LugarExpedicion;
                string Folio = nodo.GetAttribute("folio");
                Datos["folio"] = Folio;
                string formaDePago = nodo.GetAttribute("formaDePago");
                Datos["formaDePago"] = formaDePago;
                string metodoDePago = nodo.GetAttribute("metodoDePago");
                Datos["metodoDePago"] = metodoDePago;
                string subTotal = nodo.GetAttribute("subTotal");
                Datos["subTotal"] = subTotal;
                string total = nodo.GetAttribute("total");
                Datos["total"] = total;
                monto = float.Parse(total);
            }
            //-----------------------------------------------------------------------------------------
            foreach (XmlElement nodo in Emisor)
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
            }
            //-------------------------------------------------------------------------------------------
            foreach (XmlElement nodo in Receptor)
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
            }
            //------------------------------------------------------------------------------------
            foreach (XmlElement nodo in Impuestos)
            {
                string totalImpuestosTrasladados = nodo.GetAttribute("totalImpuestosTrasladados");
                Datos["totalImpuestosTrasladados"] = totalImpuestosTrasladados;
            }
            //-------------------------------------------------------------------------------------------
            QR = QR + "&tt=" + monto.ToString(fmt);
            ///------------------------------------------------------------------------------------------
            foreach (XmlElement nodo in Complemento)
            {
                XmlNodeList TimbreFiscalDigital = nodo.GetElementsByTagName("tfd:TimbreFiscalDigital");
                foreach (XmlElement TimbreFiscal in TimbreFiscalDigital)
                {
                    string uuid = TimbreFiscal.GetAttribute("UUID");
                    Datos["UUID"] = uuid;
                    QR = QR + "&id=" + uuid;
                    Datos["QR"] = QR;
                    string noCertificadoSAT = TimbreFiscal.GetAttribute("noCertificadoSAT");
                    Datos["noCertificadoSAT"] = noCertificadoSAT;
                    string FechaTimbrado = TimbreFiscal.GetAttribute("FechaTimbrado");
                    Datos["FechaTimbrado"] = FechaTimbrado;
                    string selloCFD = TimbreFiscal.GetAttribute("selloCFD");
                    Datos["selloCFD"] = selloCFD;
                    string selloSAT = TimbreFiscal.GetAttribute("selloSAT");
                    Datos["SelloSAT"] = selloSAT;
                }
            }
            Datos["CadenaOriginal"] = Datos["CadenaOriginal"] + Datos["UUID"] + "|" + Datos["FechaTimbrado"] + "|" + Datos["selloCFD"] + "|" + Datos["noCertificadoSAT"] + "||";
            //-------------------------------------------------------------------------------------------
            return Datos;
        }
       
        public static byte[] CrearRecibo(string Nombre, string RFC, Dictionary<string, string> conceptos, string direccion, string telefono, float Total, bool leyenda, string Imagen, bool Moneda)
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL);
            Font sellos = new Font(Font.FontFamily.HELVETICA, 5, Font.NORMAL);
            Font textBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
            DateTime now = DateTime.Now;
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);

            MemoryStream memStream = new MemoryStream();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memStream);
            doc.AddTitle("Recibo Electronico");
            doc.AddCreator("Avenzo Proteccion");
            doc.AddAuthor("Cristian Santiago Rosas");
            doc.Open();
            iTextSharp.text.Image avenzo = iTextSharp.text.Image.GetInstance(Imagen);
            iTextSharp.text.pdf.PdfPTable Header = new iTextSharp.text.pdf.PdfPTable(12);
            float[] widths = new float[] { .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f, .8f };
            iTextSharp.text.Rectangle page = doc.PageSize;
            Header.WidthPercentage = 80;
            Header.LockedWidth = true;
            Header.SetWidths(widths);
            Header.TotalWidth = page.Width - 90;
            //---------------------------------------------
            //-----------CABEZERA DEL DOCUMENTO------------
            //---------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell();//--Logo
            cell.AddElement(avenzo);
            cell.Colspan = 4;
            cell.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell2.AddElement(new iTextSharp.text.Paragraph("AVENZO BUSINESS GROUP S de RL de CV" + "\n" + "ABG1512109U1" + "\nDomicilio Fiscal\n" + "AVENIDA GRANDES LAGOS 19702 6\nFRACC. EL LAGO 22210\nTIJUANA, Baja California Mexico" + "\nTel. 6645266573", new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)));
            cell2.Colspan = 4;
            cell2.Border = BORDER;
            cell2.HorizontalAlignment = 1;
            Header.AddCell(cell);
            Header.AddCell(cell2);
            iTextSharp.text.pdf.PdfPCell cell51 = new iTextSharp.text.pdf.PdfPCell();
            cell51.Phrase = new Phrase("", textBold);
            cell51.HorizontalAlignment = Element.ALIGN_CENTER;
            cell51.Colspan = 4;
            cell51.Border = 0;
            Header.AddCell(cell51);
            iTextSharp.text.pdf.PdfPCell salto = new iTextSharp.text.pdf.PdfPCell();
            salto.AddElement(new Chunk("\n"));
            salto.Colspan = 12;
            salto.Border = BORDER;
            Header.AddCell(salto);
            //---------------------------------------------
            //------------DATOS CLIENTE-------------------
            //---------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell4 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell4.Colspan = 1;
            cell4.Border = BORDER;
            cell4.PaddingTop = 0;
            cell4.PaddingBottom = 0;
            cell4.AddElement(new Paragraph("Cliente:", textBold));
            iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell5.Colspan = 2;
            cell5.PaddingTop = 0;
            cell5.PaddingBottom = 0;
            cell5.Border = BORDER;
            cell5.AddElement(new Paragraph(Nombre, font));
            iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell6.Colspan = 2;
            cell6.Border = BORDER;
            cell6.PaddingTop = 0;
            cell6.PaddingBottom = 0;
            cell6.AddElement(new Paragraph("", textBold));
            iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell7.Colspan = 7;
            cell7.Border = BORDER;
            cell7.PaddingTop = 0;
            cell7.PaddingBottom = 0;
            cell7.AddElement(new Paragraph("", font));
            iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell8.Colspan = 1;
            cell8.Border = BORDER;
            cell8.PaddingTop = 0;
            cell8.PaddingBottom = 0;
            cell8.AddElement(new Paragraph("RFC:", textBold));
            iTextSharp.text.pdf.PdfPCell cell9 = new iTextSharp.text.pdf.PdfPCell();//--Domicilio Fiscal
            cell9.Colspan = 2;
            cell9.Border = BORDER;
            cell9.PaddingTop = 0;
            cell9.PaddingBottom = 0;
            cell9.AddElement(new Paragraph(RFC, font));
            iTextSharp.text.pdf.PdfPCell cell10 = new iTextSharp.text.pdf.PdfPCell();
            cell10.Colspan = 2;
            cell10.Border = BORDER;
            cell10.PaddingBottom = 0;
            cell10.PaddingTop = 0;
            cell10.AddElement(new Paragraph("Lugar de Expedición:", textBold));
            iTextSharp.text.pdf.PdfPCell cell11 = new iTextSharp.text.pdf.PdfPCell();
            cell11.Colspan = 3;
            cell11.Border = BORDER;
            cell11.PaddingTop = 0;
            cell11.PaddingBottom = 0;
            cell11.AddElement(new Paragraph("TIJUANA, Baja California", font));
            iTextSharp.text.pdf.PdfPCell cell12 = new iTextSharp.text.pdf.PdfPCell();
            cell12.AddElement(new Paragraph("Fecha de Expedicion:", textBold));
            cell12.Colspan = 2;
            cell12.Border = BORDER;
            cell12.PaddingBottom = 0;
            cell12.PaddingTop = 0;
            iTextSharp.text.pdf.PdfPCell cell13 = new iTextSharp.text.pdf.PdfPCell();
            cell13.Colspan = 3;
            cell13.Border = BORDER;
            cell13.PaddingTop = 0;
            cell13.PaddingBottom = 0;
            DateTime time = DateTime.Now;
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            cell13.AddElement(new Paragraph(time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " del " + time.ToString("yyyy", ci), font));
            //---
            iTextSharp.text.pdf.PdfPCell cell14 = new iTextSharp.text.pdf.PdfPCell();
            cell14.Colspan = 1;
            cell14.Rowspan = 2;
            cell14.PaddingTop = 0;
            cell14.PaddingBottom = 0;
            cell14.Border = BORDER;
            cell14.AddElement(new Paragraph("Direccion:", textBold));
            iTextSharp.text.pdf.PdfPCell cell15 = new iTextSharp.text.pdf.PdfPCell();
            cell15.Colspan = 2;
            cell15.Rowspan = 2;
            cell15.Border = BORDER;
            cell15.PaddingBottom = 0;
            cell15.PaddingTop = 0;
            if (direccion.Split('|').Count() == 1)
                cell15.AddElement(new Paragraph(direccion, font));
            else
                cell15.AddElement(new Paragraph(direccion.Split('|')[0] + direccion.Split('|')[1] + direccion.Split('|')[2], font));
            iTextSharp.text.pdf.PdfPCell cell16 = new iTextSharp.text.pdf.PdfPCell();
            cell16.Colspan = 2;
            cell16.PaddingTop = 0;
            cell16.PaddingBottom = 0;
            cell16.AddElement(new Paragraph("Mes de Pago:", textBold));
            cell16.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell17 = new iTextSharp.text.pdf.PdfPCell();
            cell17.PaddingBottom = 0;
            cell17.PaddingTop = 0;
            cell17.Colspan = 3;
            cell17.Border = BORDER;
            cell17.AddElement(new Paragraph("" + time.ToString("MMMM", ci).ToUpper(), font));
            iTextSharp.text.pdf.PdfPCell cell18 = new iTextSharp.text.pdf.PdfPCell();
            cell18.AddElement(new Paragraph("", textBold));
            cell18.Colspan = 2;
            cell18.Border = BORDER;
            cell18.PaddingTop = 0;
            cell18.PaddingBottom = 0;
            iTextSharp.text.pdf.PdfPCell cell19 = new iTextSharp.text.pdf.PdfPCell();
            cell19.Colspan = 2;
            cell19.Border = BORDER;
            cell19.PaddingBottom = 0;
            cell19.PaddingTop = 0;
            cell19.AddElement(new Paragraph("", font));
            iTextSharp.text.pdf.PdfPCell cell20 = new iTextSharp.text.pdf.PdfPCell();
            cell20.Colspan = 2;
            cell20.Border = BORDER;
            cell20.PaddingTop = 0;
            cell20.PaddingBottom = 0;
            cell20.AddElement(new Paragraph("", textBold));
            iTextSharp.text.pdf.PdfPCell cell21 = new iTextSharp.text.pdf.PdfPCell();
            cell21.Colspan = 3;
            cell21.Border = BORDER;
            cell21.PaddingTop = 0;
            cell21.PaddingBottom = 0;
            cell21.AddElement(new Paragraph("", font));
            iTextSharp.text.pdf.PdfPCell cell22 = new iTextSharp.text.pdf.PdfPCell();
            cell22.Colspan = 2;
            cell22.Border = BORDER;
            cell22.PaddingTop = 0;
            cell22.PaddingBottom = 0;
            cell22.AddElement(new Paragraph("No. Cuenta Pago:", textBold));
            iTextSharp.text.pdf.PdfPCell cell23 = new iTextSharp.text.pdf.PdfPCell();
            cell23.Colspan = 2;
            cell23.Border = BORDER;
            cell23.PaddingTop = 0;
            cell23.PaddingBottom = 0;
            cell23.AddElement(new Paragraph("", font));
            //----------------------------------------------
            //-----------------PRODUCTOS--------------------
            //----------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell24 = new iTextSharp.text.pdf.PdfPCell();
            cell24.Colspan = 1;
            cell24.AddElement(new Paragraph("Cantidad", textBold));
            iTextSharp.text.pdf.PdfPCell cell25 = new iTextSharp.text.pdf.PdfPCell();
            cell25.Colspan = 1;
            cell25.AddElement(new Paragraph("Unidad de Medida", textBold));
            iTextSharp.text.pdf.PdfPCell cell26 = new iTextSharp.text.pdf.PdfPCell();
            cell26.Colspan = 6;
            cell26.HorizontalAlignment = Element.ALIGN_CENTER;
            cell26.VerticalAlignment = Element.ALIGN_CENTER;
            cell26.AddElement(new Paragraph("Descripcion", textBold));
            iTextSharp.text.pdf.PdfPCell cell27 = new iTextSharp.text.pdf.PdfPCell();
            cell27.Colspan = 2;
            cell27.AddElement(new Paragraph("Producto Unitario", textBold));
            iTextSharp.text.pdf.PdfPCell cell28 = new iTextSharp.text.pdf.PdfPCell();
            cell28.Colspan = 2;
            cell28.HorizontalAlignment = Element.ALIGN_CENTER;
            cell28.VerticalAlignment = Element.ALIGN_CENTER;
            cell28.AddElement(new Paragraph("Importe", textBold));
            //-----------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell29 = new iTextSharp.text.pdf.PdfPCell();
            cell29.AddElement(new Paragraph(conceptos["cantidad"], font));
            cell29.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell30 = new iTextSharp.text.pdf.PdfPCell();
            cell30.AddElement(new Paragraph(conceptos["unidad"], font));
            cell30.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell31 = new iTextSharp.text.pdf.PdfPCell();
            cell31.AddElement(new Paragraph(conceptos["descripcion"], font));
            cell31.Colspan = 6;
            iTextSharp.text.pdf.PdfPCell cell32 = new iTextSharp.text.pdf.PdfPCell();
            cell32.AddElement(new Paragraph(conceptos["valorUnitario"], font));
            cell32.Colspan = 2;
            iTextSharp.text.pdf.PdfPCell cell33 = new iTextSharp.text.pdf.PdfPCell();
            cell33.AddElement(new Paragraph(conceptos["importe"], font));
            cell33.Colspan = 2;
            cell33.FixedHeight = 200f;


            //-------------------------------------------------------
            //----------------------TOTAL----------------------------
            //-------------------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell34 = new iTextSharp.text.pdf.PdfPCell();
            cell34.Colspan = 2;
            cell34.Rowspan = 3;
            cell34.Border = BORDER;
            cell34.PaddingBottom = 0;
            cell34.PaddingTop = 0;
            cell34.AddElement(new Paragraph(""));
            iTextSharp.text.pdf.PdfPCell cell35 = new iTextSharp.text.pdf.PdfPCell();
            cell35.Colspan = 7;
            cell35.Border = BORDER;
            cell35.Rowspan = 3;
            cell35.PaddingTop = 0;
            cell35.PaddingBottom = 0;
            NumLetra nl = new NumLetra();

            cell35.AddElement(new Paragraph("IMPORTE CON LETRA: " + nl.Convertir("" + Total, true, Moneda), textBold));
            iTextSharp.text.pdf.PdfPCell cell36 = new iTextSharp.text.pdf.PdfPCell();
            cell36.Colspan = 2;
            cell36.Border = BORDER;
            cell36.PaddingBottom = 0;
            cell36.PaddingTop = 0;
            cell36.Phrase = new Phrase("SubTotal:", textBold);
            cell36.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell36.VerticalAlignment = Element.ALIGN_BOTTOM;
            iTextSharp.text.pdf.PdfPCell cell37 = new iTextSharp.text.pdf.PdfPCell();
            cell37.Colspan = 1;
            cell37.Border = BORDER;
            cell37.PaddingTop = 0;
            cell37.PaddingBottom = 0;
            cell37.AddElement(new Paragraph("$ " + ((Total / 1.16)).ToString("f2"), font));
            //--
            iTextSharp.text.pdf.PdfPCell cell38 = new iTextSharp.text.pdf.PdfPCell();
            cell38.Colspan = 2;
            cell38.PaddingBottom = 0;
            cell38.PaddingTop = 0;
            cell38.Border = BORDER;
            cell38.Phrase = new Phrase("IVA(IVA 16.00%):", textBold);
            cell38.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell38.VerticalAlignment = Element.ALIGN_BOTTOM;
            iTextSharp.text.pdf.PdfPCell cell39 = new iTextSharp.text.pdf.PdfPCell();
            cell39.Colspan = 1;
            cell39.PaddingTop = 0;
            cell39.PaddingBottom = 0;
            cell39.Border = BORDER;
            cell39.AddElement(new Paragraph("$ " + (Total - (Total / 1.16)).ToString("f2"), font));
            //---
            iTextSharp.text.pdf.PdfPCell cell40 = new iTextSharp.text.pdf.PdfPCell();
            cell40.Colspan = 2;
            cell40.Border = BORDER;
            cell40.VerticalAlignment = Element.ALIGN_BOTTOM;
            cell40.Phrase = new Phrase("Total:", textBold);
            cell40.PaddingBottom = 0;
            cell40.PaddingTop = 0;
            cell40.HorizontalAlignment = Element.ALIGN_RIGHT;
            iTextSharp.text.pdf.PdfPCell cell41 = new iTextSharp.text.pdf.PdfPCell();
            cell41.Colspan = 1;
            cell41.Border = BORDER;
            cell41.PaddingTop = 0;
            cell41.PaddingBottom = 0;
            cell41.AddElement(new Paragraph("$ " + Total.ToString("f2"), font));
            //---------------------------------------------------------------------
            iTextSharp.text.pdf.PdfPCell cell42 = new iTextSharp.text.pdf.PdfPCell();
            cell42.Colspan = 12;
            cell42.Border = BORDER;
            cell42.AddElement(new Paragraph("CONDICIONES GENERALES", textBold));
            iTextSharp.text.pdf.PdfPCell cell43 = new iTextSharp.text.pdf.PdfPCell();
            cell43.Colspan = 12;
            cell43.Border = BORDER;
            cell43.Rowspan = 9;
            string condiciones = "1.- Unicamente se atenderán productos comercializados por Avenzo Business Group S.de R.L.de C.V.";
            condiciones = condiciones + "\n2.- Todos los equipos cuentan con 1(un) año de garantía después de su fecha de facturación, excepto que se indique lo contrario en la factura.";
            condiciones = condiciones + "\n3.- Esta garantía es valida solo hasta el " + time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " del " + (time.AddYears(1).ToString("yyyy", ci));
            condiciones = condiciones + "\n4.- Es indispensable indicar la descripción clara del problema.No se aceptará equipo a reparación y / o garantía con descripciones tales como \"NO FUNCIONA\", \"NO SIRVE\", etc.";
            condiciones = condiciones + "\n5.- Se recomienda conservar su factura o recibo de compra como protección adicional ya que puede sustituir a la póliza de garantía en caso de que ésta se extravíe o exista alguna discrepancia para comprobar la vigencia de la póliza.";
            condiciones = condiciones + "\n6.- Avenzo Business Group S.R.L.de C.V.se compromete a cambiar el producto defectuoso o en caso que se haya descontinuado cambiarlo por uno nuevo igual, similar o bien se ofrecerá una nota de crédito por el equipo a valor actual, cuando no sea posible la reparación a consecuencia de un defecto de fabricación previo diagnostico realizado en las oficinas sin ningún cargo para el cliente.";
            condiciones = condiciones + "\n7.- El tiempo de cambio no será mayor de 30(treinta) dias naturales contados a partir de la fecha de recepción del producto.";
            condiciones = condiciones + "\n\nNOTA: Esta garantía incluye los gastos de transportación internos del producto que se deriven en el cumplimiento de la misma.";
            cell43.AddElement(new Paragraph(condiciones, font));
            iTextSharp.text.pdf.PdfPCell cell44 = new iTextSharp.text.pdf.PdfPCell();
            cell44.Colspan = 12;
            cell44.Border = BORDER;
            cell44.AddElement(new Paragraph("EXEPCIONES Y RESTRICCIONES", textBold));
            iTextSharp.text.pdf.PdfPCell cell45 = new iTextSharp.text.pdf.PdfPCell();
            cell45.Colspan = 12;
            cell45.Rowspan = 9;
            cell45.Border = BORDER;
            string casos = "\na. La garantía No cubre desperfectos ocacionados:\n •Por Variaciones de voltaje(equipo quemado).";
            casos = casos + "\n  •Equipo mutilado en cables, accesorios o cualquiera de sus partes.";
            casos = casos + "\n  •Cuando se demuestre que se hizo algun cambio ala instalación original  o se ha hecho mal uso del equipo (de acuerdo a manuales).";
            casos = casos + "\nb. Para servicio posterior al periodo de garantia o por equipo dañada que no aplica la garantia Avenzo ofrecerá";
            casos = casos + "\n  •Reparación en un periodo de 30-90 días previa cotización autorizaada por el distribuidor.";
            casos = casos + "\n  •Remplazar el equipo ofreciendo el máximo descuento.";
            cell45.AddElement(new Paragraph("Avenzo Business Group S.de R.L.de C.V. SE EXIME DE HACER EFECTIVA ESTA PÓLIZA DE GARANTIA EN LOS SIGUINTES CASOS:" + casos, font));
            Header.AddCell(cell4);
            Header.AddCell(cell5);
            Header.AddCell(cell6);
            Header.AddCell(cell7);
            Header.AddCell(cell8);
            Header.AddCell(cell9);
            Header.AddCell(cell10);
            Header.AddCell(cell11);
            Header.AddCell(cell12);
            Header.AddCell(cell13);
            Header.AddCell(cell14);
            Header.AddCell(cell15);
            Header.AddCell(cell16);
            Header.AddCell(cell17);
            Header.AddCell(cell18);
            Header.AddCell(cell19);
            Header.AddCell(cell20);
            Header.AddCell(cell21);
            Header.AddCell(cell22);
            Header.AddCell(cell23);
            Header.AddCell(salto);
            Header.AddCell(cell24);
            Header.AddCell(cell25);
            Header.AddCell(cell26);
            Header.AddCell(cell27);
            Header.AddCell(cell28);
            Header.AddCell(cell29);
            Header.AddCell(cell30);
            Header.AddCell(cell31);
            Header.AddCell(cell32);
            Header.AddCell(cell33);
            Header.AddCell(cell34);
            Header.AddCell(cell35);
            Header.AddCell(cell36);
            Header.AddCell(cell37);
            Header.AddCell(cell38);
            Header.AddCell(cell39);
            Header.AddCell(cell40);
            Header.AddCell(cell41);
            Header.AddCell(salto);
            if (leyenda == true)
            {
                Header.AddCell(cell42);
                Header.AddCell(cell43);
                Header.AddCell(cell44);
                Header.AddCell(cell45);
            }
            doc.Add(Header);
            doc.Close();
            writer.Close();
            return memStream.ToArray();
        }
    }
}
