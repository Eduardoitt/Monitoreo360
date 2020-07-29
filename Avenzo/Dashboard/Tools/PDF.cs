using iTextSharp.text;
//using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Globalization;


namespace Dashboard.Tools
{

    public class PDF
    {
        private static int BORDER = 0;
        public static byte[] CrearRecibo(string Nombre, string RFC, Dictionary<string, string> conceptos, string direccion, 
            string telefono, float Total, bool leyenda, byte[] Imagen, string Moneda,string Mes)
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL);
            Font sellos = new Font(Font.FontFamily.HELVETICA, 5, Font.NORMAL);
            Font textBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
            DateTime now = DateTime.Now;
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);

            MemoryStream memStream = new MemoryStream();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memStream);
            doc.AddTitle("Recibo Electronico");
            doc.AddCreator("Cristian Santiago Rosas");
            doc.AddAuthor("Avenzo Seguridad");            
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
            cell13.AddElement(new Paragraph(time.ToString("dd", ci) + " de " + DateTime.Now.ToString("MMMM", ci) + " del " + time.ToString("yyyy", ci), font));
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
            cell17.AddElement(new Paragraph(Mes, font));
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

            //NumCtaPago
            cell22.AddElement(new Paragraph("", textBold));
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
            //condiciones = condiciones + "\n3.- Esta garantía es valida solo hasta el " + time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " del " + (time.AddYears(1).ToString("yyyy", ci));
            condiciones = condiciones + "\n3.- Es indispensable indicar la descripción clara del problema.No se aceptará equipo a reparación y / o garantía con descripciones tales como \"NO FUNCIONA\", \"NO SIRVE\", etc.";
            condiciones = condiciones + "\n4.- Se recomienda conservar su factura o recibo de compra como protección adicional ya que puede sustituir a la póliza de garantía en caso de que ésta se extravíe o exista alguna discrepancia para comprobar la vigencia de la póliza.";
            condiciones = condiciones + "\n5.- Avenzo Business Group S.R.L.de C.V.se compromete a cambiar el producto defectuoso o en caso que se haya descontinuado cambiarlo por uno nuevo igual, similar o bien se ofrecerá una nota de crédito por el equipo a valor actual, cuando no sea posible la reparación a consecuencia de un defecto de fabricación previo diagnostico realizado en las oficinas sin ningún cargo para el cliente.";
            condiciones = condiciones + "\n6.- El tiempo de cambio no será mayor de 30(treinta) dias naturales contados a partir de la fecha de recepción del producto.";
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
            string casos = "\na. La garantía No cubre desperfectos ocacionados:";
            casos = casos + "\n  • Por Variaciones de voltaje(equipo quemado).";
            casos = casos + "\n  • Equipo mutilado en cables, accesorios o cualquiera de sus partes.";
            casos = casos + "\n  • Cuando se demuestre que se hizo algun cambio ala instalación original  o se ha hecho mal uso del equipo (de acuerdo a manuales).";
            casos = casos + "\nb. Para servicio posterior al periodo de garantia o por equipo dañada que no aplica la garantia Avenzo ofrecerá";
            casos = casos + "\n  • Reparación en un periodo de 30-90 días previa cotización autorizaada por el distribuidor.";
            casos = casos + "\n  • Remplazar el equipo ofreciendo el máximo descuento.";
            cell45.AddElement(new Paragraph("Avenzo Business Group S. de R.L.de C.V. SE EXIME DE HACER EFECTIVA ESTA PÓLIZA DE GARANTIA EN LOS SIGUINTES CASOS:" + casos, font));
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
        public static void CrearFactura(string PATH, string Archivo, string Moneda,byte[] Imagen,RVCFDI33.GeneraCFDI ObjCfdi,string EmisorRFC,string EmisorNombre,string RegimenFiscal,
            string ReceptorRFC,string LugarExpedicion,string ReceptorDomicilio,string FormaDePago,string MetodoDePago,string Total,string TotalDeImpuestosTrasladados,string SubTotal,
            string Cantidad,string Descripcion,string ValorUnitario,string Importe,string Unidad)
        {
            var Datos = CFDI.LeerCFDI(PATH + Archivo + ".xml");
            Font font = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL);
            Font sellos = new Font(Font.FontFamily.HELVETICA, 5, Font.NORMAL);
            Font textBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(PATH + Archivo + ".pdf", FileMode.Create));

            doc.AddTitle("Factura Electronica");
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
            cell2.AddElement(new iTextSharp.text.Paragraph(EmisorNombre + "\n" + EmisorRFC +/* "\nDomicilio Fiscal\n" + Datos["DomicilioFiscal"] +*/ "\nTel. 6645266573", new Font(Font.FontFamily.HELVETICA, 5, Font.BOLD)));
            cell2.Colspan = 4;
            cell2.Border = BORDER;
            cell2.HorizontalAlignment = 1;
            Header.AddCell(cell);
            Header.AddCell(cell2);            
            iTextSharp.text.pdf.PdfPCell cell51 = new iTextSharp.text.pdf.PdfPCell();
            cell51.Phrase = new Phrase("Factura No: " + ObjCfdi.Folio + " Serie:"+ObjCfdi.Serie+"\nFOLIO FISCAL (UUID):\n" + ObjCfdi.UUID + "\nNO. DE SERIE DEL CERTIFICADO DEL SAT:\n" + Datos["noCertificadoSAT"] + "\nNO. DE SERIE DEL CERTIFICADO DEL EMISOR:\n" + Datos["noCertificado"] + "\nFECHA Y HORA DE CERTIFICACIÓN:\n" + ObjCfdi.FechaTimbrado + "\nFECHA Y HORA DE EMISIÓN DE CFDI:\n" + ObjCfdi.FechaEmision, textBold);
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
            cell5.AddElement(new Paragraph(ObjCfdi.NombreReceptor, font));
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
            cell7.AddElement(new Paragraph(RegimenFiscal, font));
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
            cell9.AddElement(new Paragraph(ReceptorRFC, font));
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
            cell11.AddElement(new Paragraph(LugarExpedicion, font));
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
            DateTime time = DateTime.Parse(ObjCfdi.FechaEmision);
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            cell13.AddElement(new Paragraph(time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " de " + time.ToString("yyyy", ci), font));
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
            cell15.AddElement(new Paragraph(ReceptorDomicilio, font));
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
            cell17.AddElement(new Paragraph(FormaDePago, font));
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
            cell19.AddElement(new Paragraph(Moneda, font));
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
            cell21.AddElement(new Paragraph(MetodoDePago, font));
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
            //NUmCtAPago
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
            cell29.AddElement(new Paragraph(Cantidad, font));
            cell29.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell30 = new iTextSharp.text.pdf.PdfPCell();
            cell30.AddElement(new Paragraph(Unidad, font));
            cell30.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell31 = new iTextSharp.text.pdf.PdfPCell();
            cell31.AddElement(new Paragraph(Descripcion, font));
            cell31.Colspan = 6;
            iTextSharp.text.pdf.PdfPCell cell32 = new iTextSharp.text.pdf.PdfPCell();
            cell32.AddElement(new Paragraph(ValorUnitario, font));
            cell32.Colspan = 2;
            iTextSharp.text.pdf.PdfPCell cell33 = new iTextSharp.text.pdf.PdfPCell();
            cell33.AddElement(new Paragraph(Importe, font));
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
            cell35.AddElement(new Paragraph("IMPORTE CON LETRA: " + nl.Convertir(Total, true, Moneda) +  ".", textBold));
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
            cell37.AddElement(new Paragraph("$ " + float.Parse(SubTotal).ToString("f2"), font));
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
            cell39.AddElement(new Paragraph("$ " + float.Parse(TotalDeImpuestosTrasladados).ToString("f2"), font));
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
            cell41.AddElement(new Paragraph("$ " + float.Parse(Total).ToString("f2"), font));
            //---------------------------------------------------------
            //-------------------CDFI SELLOS---------------------------
            //---------------------------------------------------------
            
            string QRString = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?";
            QRString += "?&id=" + ObjCfdi.UUID;
            QRString += "&re="+EmisorRFC;
            QRString += "&rr="+ReceptorRFC;
            QRString += "&tt="+Total;
            QRString += "&fe="+ObjCfdi.SelloSat.Substring(ObjCfdi.SelloSat.Length-8);
            iTextSharp.text.pdf.PdfPCell cell42 = new iTextSharp.text.pdf.PdfPCell();
            cell42.Colspan = 10;
            cell42.Border = BORDER;
            cell42.Phrase = new Phrase("SELLO DIGITAL DEL CFDI", textBold);
            iTextSharp.text.pdf.BarcodeQRCode QR = new iTextSharp.text.pdf.BarcodeQRCode(QRString, 300, 300, null);
            iTextSharp.text.Image img = QR.GetImage();
            img.SetDpi(1400, 1400);
            iTextSharp.text.pdf.PdfPCell cell43 = new iTextSharp.text.pdf.PdfPCell();
            cell43.Colspan = 2;
            cell43.Border = BORDER;
            cell43.Rowspan = 9;
            cell43.VerticalAlignment = Element.ALIGN_TOP;
            cell43.AddElement(img);
            iTextSharp.text.pdf.PdfPCell cell44 = new iTextSharp.text.pdf.PdfPCell();
            cell44.Colspan = 10;
            cell44.Phrase = new Phrase(ObjCfdi.SelloEmisor, sellos);
            iTextSharp.text.pdf.PdfPCell cell45 = new iTextSharp.text.pdf.PdfPCell();
            cell45.Colspan = 10;
            cell45.Phrase = new Phrase("SELLO DIGITAL DEL SAT", textBold);
            cell45.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell46 = new iTextSharp.text.pdf.PdfPCell();
            cell46.Phrase = new Phrase(ObjCfdi.SelloSat, sellos);
            cell46.Colspan = 10;
            iTextSharp.text.pdf.PdfPCell cell47 = new iTextSharp.text.pdf.PdfPCell();
            cell47.Phrase = new Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT", textBold);
            cell47.Border = BORDER;
            cell47.Colspan = 10;
            iTextSharp.text.pdf.PdfPCell cell48 = new iTextSharp.text.pdf.PdfPCell();
            cell48.Colspan = 10;
            cell48.Phrase = new Phrase(ObjCfdi.CadenaOriginal, sellos);
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


        public static void ComplementoPago10(string PATH, string Archivo, string Moneda, byte[] Imagen, RVCFDI33.GeneraCFDI ObjCfdi, string EmisorRFC, string EmisorNombre, string RegimenFiscal,
            string ReceptorRFC, string LugarExpedicion, string ReceptorDomicilio,string FechaPago,string FormaDePagoP, string MonedaP ,string TipoCambioP,string Monto,string NumOperacion,string IdDocumento,
            string Serie,string FolioDocumentoRelacionado, string MonedaDR,string MetodoDePagoDR, string NumParcialidad,string ImpSaldoAnt,string ImpPagado, string ImpSaldoInsoluto
            )
        {
            var Datos = CFDI.LeerCFDI(PATH + Archivo + ".xml");
            Font font = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL);
            Font sellos = new Font(Font.FontFamily.HELVETICA, 5, Font.NORMAL);
            Font textBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(PATH + Archivo + ".pdf", FileMode.Create));

            doc.AddTitle("Factura Electronica");
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
            cell2.AddElement(new iTextSharp.text.Paragraph(EmisorNombre + "\n" + EmisorRFC +/* "\nDomicilio Fiscal\n" + Datos["DomicilioFiscal"] +*/ "\nTel. 6645266573", new Font(Font.FontFamily.HELVETICA, 5, Font.BOLD)));
            cell2.Colspan = 4;
            cell2.Border = BORDER;
            cell2.HorizontalAlignment = 1;
            Header.AddCell(cell);
            Header.AddCell(cell2);
            iTextSharp.text.pdf.PdfPCell cell51 = new iTextSharp.text.pdf.PdfPCell();
            cell51.Phrase = new Phrase("Factura No: " + ObjCfdi.Folio + " Serie:" + ObjCfdi.Serie + "\nFOLIO FISCAL (UUID):\n" + ObjCfdi.UUID + "\nNO. DE SERIE DEL CERTIFICADO DEL SAT:\n" + Datos["noCertificadoSAT"] + "\nNO. DE SERIE DEL CERTIFICADO DEL EMISOR:\n" + Datos["noCertificado"] + "\nFECHA Y HORA DE CERTIFICACIÓN:\n" + ObjCfdi.FechaTimbrado + "\nFECHA Y HORA DE EMISIÓN DE CFDI:\n" + ObjCfdi.FechaEmision, textBold);
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
            cell5.AddElement(new Paragraph(ObjCfdi.NombreReceptor, font));
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
            cell7.AddElement(new Paragraph(RegimenFiscal, font));
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
            cell9.AddElement(new Paragraph(ReceptorRFC, font));
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
            cell11.AddElement(new Paragraph(LugarExpedicion, font));
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
            DateTime time = DateTime.Parse(ObjCfdi.FechaEmision);
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            cell13.AddElement(new Paragraph(time.ToString("dd", ci) + " de " + time.ToString("MMMM", ci) + " de " + time.ToString("yyyy", ci), font));
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
            cell15.AddElement(new Paragraph(ReceptorDomicilio, font));
            iTextSharp.text.pdf.PdfPCell cell16 = new iTextSharp.text.pdf.PdfPCell();
            cell16.Colspan = 2;
            cell16.PaddingTop = 0;
            cell16.PaddingBottom = 0;
            cell16.AddElement(new Paragraph("Tipo de Comprobante:", textBold));
            cell16.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell17 = new iTextSharp.text.pdf.PdfPCell();
            cell17.PaddingBottom = 0;
            cell17.PaddingTop = 0;
            cell17.Colspan = 3;
            cell17.Border = BORDER;
            cell17.AddElement(new Paragraph("P", font));
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
            cell19.AddElement(new Paragraph(Moneda, font));
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
            cell22.AddElement(new Paragraph("", textBold));
            iTextSharp.text.pdf.PdfPCell cell23 = new iTextSharp.text.pdf.PdfPCell();
            cell23.Colspan = 2;
            cell23.Border = BORDER;
            cell23.PaddingTop = 0;
            cell23.PaddingBottom = 0;
            //NUmCtAPago
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
            cell29.AddElement(new Paragraph("1.00", font));
            cell29.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell30 = new iTextSharp.text.pdf.PdfPCell();
            cell30.AddElement(new Paragraph("ACT", font));
            cell30.Colspan = 1;
            iTextSharp.text.pdf.PdfPCell cell31 = new iTextSharp.text.pdf.PdfPCell();
            cell31.AddElement(new Paragraph("Pago", font));
            cell31.Colspan = 6;
            iTextSharp.text.pdf.PdfPCell cell32 = new iTextSharp.text.pdf.PdfPCell();
            cell32.AddElement(new Paragraph("0.00", font));
            cell32.Colspan = 2;
            iTextSharp.text.pdf.PdfPCell cell33 = new iTextSharp.text.pdf.PdfPCell();
            cell33.AddElement(new Paragraph("0.00", font));
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
            cell35.AddElement(new Paragraph("IMPORTE CON LETRA: " + nl.Convertir("0", true, Moneda) + ".", textBold));
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
            cell37.AddElement(new Paragraph("$ " + float.Parse("0").ToString("f2"), font));
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
            cell39.AddElement(new Paragraph("$ " + float.Parse("0").ToString("f2"), font));
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
            cell41.AddElement(new Paragraph("$ " + float.Parse("0.0").ToString("f2"), font));


            //-------------------------------------------------------
            //-------------------Complemento-------------------------
            //-------------------------------------------------------
            iTextSharp.text.pdf.PdfPCell cellTitleComplementosPagos = new iTextSharp.text.pdf.PdfPCell();
            cellTitleComplementosPagos.Colspan = 12;
            cellTitleComplementosPagos.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleComplementosPagos.Phrase = new Phrase("Complementos de Pagos",textBold);

            iTextSharp.text.pdf.PdfPCell cellTitlePago = new iTextSharp.text.pdf.PdfPCell();
            cellTitlePago.Colspan = 12;
            cellTitlePago.VerticalAlignment = Element.ALIGN_LEFT;
            cellTitlePago.Phrase = new Phrase("Pagos", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleFechaPago = new iTextSharp.text.pdf.PdfPCell();
            cellTitleFechaPago.Colspan = 2;
            cellTitleFechaPago.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleFechaPago.Phrase = new Phrase("FechaPago", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleFormaPagoP = new iTextSharp.text.pdf.PdfPCell();
            cellTitleFormaPagoP.Colspan = 2;
            cellTitleFormaPagoP.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleFormaPagoP.Phrase = new Phrase("FormaDePagoP", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleMonedaP = new iTextSharp.text.pdf.PdfPCell();
            cellTitleMonedaP.Colspan = 2;
            cellTitleMonedaP.VerticalAlignment = Element.ALIGN_LEFT;
            cellTitleMonedaP.Phrase = new Phrase("MonedaP", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleTipoCambioP = new iTextSharp.text.pdf.PdfPCell();
            cellTitleTipoCambioP.Colspan = 2;
            cellTitleTipoCambioP.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleTipoCambioP.Phrase = new Phrase("TipoCambioP", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleMonto = new iTextSharp.text.pdf.PdfPCell();
            cellTitleMonto.Colspan = 2;
            cellTitleMonto.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleMonto.Phrase = new Phrase("Monto", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleNumeroOperacion = new iTextSharp.text.pdf.PdfPCell();
            cellTitleNumeroOperacion.Colspan = 2;
            cellTitleNumeroOperacion.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleNumeroOperacion.Phrase = new Phrase("NumOperacion", textBold);

            

            iTextSharp.text.pdf.PdfPCell cellValueFechaPago = new iTextSharp.text.pdf.PdfPCell();
            cellValueFechaPago.Colspan = 2;
            cellValueFechaPago.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueFechaPago.Phrase = new Phrase(FechaPago, font);

            iTextSharp.text.pdf.PdfPCell cellValueFormaPagoP = new iTextSharp.text.pdf.PdfPCell();
            cellValueFormaPagoP.Colspan = 2;
            cellValueFormaPagoP.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueFormaPagoP.Phrase = new Phrase(FormaDePagoP, font);

            iTextSharp.text.pdf.PdfPCell cellValueMonedaP = new iTextSharp.text.pdf.PdfPCell();
            cellValueMonedaP.Colspan = 2;
            cellValueMonedaP.VerticalAlignment = Element.ALIGN_LEFT;
            cellValueMonedaP.Phrase = new Phrase(MonedaP, font);

            iTextSharp.text.pdf.PdfPCell cellValueTipoCambioP = new iTextSharp.text.pdf.PdfPCell();
            cellValueTipoCambioP.Colspan = 2;
            cellValueTipoCambioP.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueTipoCambioP.Phrase = new Phrase(TipoCambioP, font);

            iTextSharp.text.pdf.PdfPCell cellValueMonto = new iTextSharp.text.pdf.PdfPCell();
            cellValueMonto.Colspan = 2;
            cellValueMonto.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueMonto.Phrase = new Phrase(Monto, font);

            iTextSharp.text.pdf.PdfPCell cellValueNumeroOperacion = new iTextSharp.text.pdf.PdfPCell();
            cellValueNumeroOperacion.Colspan = 2;
            cellValueNumeroOperacion.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueNumeroOperacion.Phrase = new Phrase("01", font);

            iTextSharp.text.pdf.PdfPCell cellTitleDoctoRelacionado = new iTextSharp.text.pdf.PdfPCell();
            cellTitleDoctoRelacionado.Colspan = 12;
            cellTitleDoctoRelacionado.VerticalAlignment = Element.ALIGN_LEFT;
            cellTitleDoctoRelacionado.Phrase = new Phrase("DoctoRelacionado", textBold);


            iTextSharp.text.pdf.PdfPCell cellTitleIdDocumento= new iTextSharp.text.pdf.PdfPCell();
            cellTitleIdDocumento.Colspan = 2;
            cellTitleIdDocumento.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleIdDocumento.Phrase = new Phrase("IdDocumento", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleSerie = new iTextSharp.text.pdf.PdfPCell();
            cellTitleSerie.Colspan = 1;
            cellTitleSerie.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleSerie.Phrase = new Phrase("Serie", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleFolioDocumentoRelacionado = new iTextSharp.text.pdf.PdfPCell();
            cellTitleFolioDocumentoRelacionado.Colspan = 1;
            cellTitleFolioDocumentoRelacionado.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleFolioDocumentoRelacionado.Phrase = new Phrase("Folio", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleMonedaDR = new iTextSharp.text.pdf.PdfPCell();
            cellTitleMonedaDR.Colspan = 1;
            cellTitleMonedaDR.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleMonedaDR.Phrase = new Phrase("MonedaDR", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleMetodoDePagoDR = new iTextSharp.text.pdf.PdfPCell();
            cellTitleMetodoDePagoDR.Colspan = 2;
            cellTitleMetodoDePagoDR.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleMetodoDePagoDR.Phrase = new Phrase("MetodoDePagoDR", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleNumParcialidad = new iTextSharp.text.pdf.PdfPCell();
            cellTitleNumParcialidad.Colspan = 1;
            cellTitleNumParcialidad.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleNumParcialidad.Phrase = new Phrase("NumParcialidad", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleImpSaldoAnt = new iTextSharp.text.pdf.PdfPCell();
            cellTitleImpSaldoAnt.Colspan = 1;
            cellTitleImpSaldoAnt.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleImpSaldoAnt.Phrase = new Phrase("ImpSaldoAnt", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleImpPagado = new iTextSharp.text.pdf.PdfPCell();
            cellTitleImpPagado.Colspan =1;
            cellTitleImpPagado.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleImpPagado.Phrase = new Phrase("ImpPagado", textBold);

            iTextSharp.text.pdf.PdfPCell cellTitleImpSaldoInsoluto = new iTextSharp.text.pdf.PdfPCell();
            cellTitleImpSaldoInsoluto.Colspan = 2;
            cellTitleImpSaldoInsoluto.VerticalAlignment = Element.ALIGN_CENTER;
            cellTitleImpSaldoInsoluto.Phrase = new Phrase("ImpSaldoInsoluto", textBold);


            iTextSharp.text.pdf.PdfPCell cellValueIdDocumento = new iTextSharp.text.pdf.PdfPCell();
            cellValueIdDocumento.Colspan = 2;
            cellValueIdDocumento.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueIdDocumento.Phrase = new Phrase(IdDocumento.ToString(), font);

            iTextSharp.text.pdf.PdfPCell cellValueSerie = new iTextSharp.text.pdf.PdfPCell();
            cellValueSerie.Colspan = 1;
            cellValueSerie.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueSerie.Phrase = new Phrase(Serie, font);

            iTextSharp.text.pdf.PdfPCell cellValueFolioDocumentoRelacionado = new iTextSharp.text.pdf.PdfPCell();
            cellValueFolioDocumentoRelacionado.Colspan = 1;
            cellValueFolioDocumentoRelacionado.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueFolioDocumentoRelacionado.Phrase = new Phrase(FolioDocumentoRelacionado, font);

            iTextSharp.text.pdf.PdfPCell cellValueMonedaDR = new iTextSharp.text.pdf.PdfPCell();
            cellValueMonedaDR.Colspan = 1;
            cellValueMonedaDR.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueMonedaDR.Phrase = new Phrase(MonedaDR, font);


            iTextSharp.text.pdf.PdfPCell cellValueMetodoDePagoDR = new iTextSharp.text.pdf.PdfPCell();
            cellValueMetodoDePagoDR.Colspan = 2;
            cellValueMetodoDePagoDR.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueMetodoDePagoDR.Phrase = new Phrase(MetodoDePagoDR, font);

            iTextSharp.text.pdf.PdfPCell cellValueNumParcialidad = new iTextSharp.text.pdf.PdfPCell();
            cellValueNumParcialidad.Colspan = 1;
            cellValueNumParcialidad.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueNumParcialidad.Phrase = new Phrase(NumParcialidad, font);

            iTextSharp.text.pdf.PdfPCell cellValueImpSaldoAnt = new iTextSharp.text.pdf.PdfPCell();
            cellValueImpSaldoAnt.Colspan = 1;
            cellValueImpSaldoAnt.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueImpSaldoAnt.Phrase = new Phrase(ImpSaldoAnt, textBold);

            iTextSharp.text.pdf.PdfPCell cellValueImpPagado = new iTextSharp.text.pdf.PdfPCell();
            cellValueImpPagado.Colspan = 1;
            cellValueImpPagado.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueImpPagado.Phrase = new Phrase(ImpPagado, textBold);

            iTextSharp.text.pdf.PdfPCell cellValueImpSaldoInsoluto = new iTextSharp.text.pdf.PdfPCell();
            cellValueImpSaldoInsoluto.Colspan = 2;
            cellValueImpSaldoInsoluto.VerticalAlignment = Element.ALIGN_CENTER;
            cellValueImpSaldoInsoluto.Phrase = new Phrase(ImpSaldoInsoluto, textBold);



            //---------------------------------------------------------
            //-------------------CDFI SELLOS---------------------------
            //---------------------------------------------------------

            /*string QRString = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?";
            QRString += "?&id=" + ObjCfdi.UUID;
            QRString += "&re=" + EmisorRFC;
            QRString += "&rr=" + ReceptorRFC;
            QRString += "&tt=" + Total;
            QRString += "&fe=" + ObjCfdi.SelloSat.Substring(ObjCfdi.SelloSat.Length - 8);*/
            iTextSharp.text.pdf.PdfPCell cell42 = new iTextSharp.text.pdf.PdfPCell();
            cell42.Colspan = 12;
            cell42.Border = BORDER;
            cell42.Phrase = new Phrase("SELLO DIGITAL DEL CFDI", textBold);
            /*iTextSharp.text.pdf.BarcodeQRCode QR = new iTextSharp.text.pdf.BarcodeQRCode(QRString, 300, 300, null);
            iTextSharp.text.Image img = QR.GetImage();
            img.SetDpi(1400, 1400);*/
            /*iTextSharp.text.pdf.PdfPCell cell43 = new iTextSharp.text.pdf.PdfPCell();
            cell43.Colspan = 2;
            cell43.Border = BORDER;
            cell43.Rowspan = 9;
            cell43.VerticalAlignment = Element.ALIGN_TOP;
            cell43.AddElement(img);*/
            iTextSharp.text.pdf.PdfPCell cell44 = new iTextSharp.text.pdf.PdfPCell();
            cell44.Colspan = 12;
            cell44.Phrase = new Phrase(ObjCfdi.SelloEmisor, sellos);
            iTextSharp.text.pdf.PdfPCell cell45 = new iTextSharp.text.pdf.PdfPCell();
            cell45.Colspan = 12;
            cell45.Phrase = new Phrase("SELLO DIGITAL DEL SAT", textBold);
            cell45.Border = BORDER;
            iTextSharp.text.pdf.PdfPCell cell46 = new iTextSharp.text.pdf.PdfPCell();
            cell46.Phrase = new Phrase(ObjCfdi.SelloSat, sellos);
            cell46.Colspan = 12;
            iTextSharp.text.pdf.PdfPCell cell47 = new iTextSharp.text.pdf.PdfPCell();
            cell47.Phrase = new Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT", textBold);
            cell47.Border = BORDER;
            cell47.Colspan = 12;
            iTextSharp.text.pdf.PdfPCell cell48 = new iTextSharp.text.pdf.PdfPCell();
            cell48.Colspan = 12;
            cell48.Phrase = new Phrase(ObjCfdi.CadenaOriginal, sellos);
            iTextSharp.text.pdf.PdfPCell cell49 = new iTextSharp.text.pdf.PdfPCell();
            cell49.Colspan = 12;
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
            //Header.AddCell(cell43);
            Header.AddCell(cellTitleComplementosPagos);
            Header.AddCell(cellTitlePago);
            Header.AddCell(cellTitleFechaPago);
            Header.AddCell(cellTitleFormaPagoP);
            Header.AddCell(cellTitleMonedaP);
            Header.AddCell(cellTitleTipoCambioP);
            Header.AddCell(cellTitleMonto);
            Header.AddCell(cellTitleNumeroOperacion);            
            Header.AddCell(cellValueFechaPago);
            Header.AddCell(cellValueFormaPagoP);
            Header.AddCell(cellValueMonedaP);
            Header.AddCell(cellValueTipoCambioP);
            Header.AddCell(cellValueMonto);
            Header.AddCell(cellValueNumeroOperacion);
            Header.AddCell(cellTitleDoctoRelacionado);
            Header.AddCell(cellTitleIdDocumento);
            Header.AddCell(cellTitleSerie);
            Header.AddCell(cellTitleFolioDocumentoRelacionado);
            Header.AddCell(cellTitleMonedaDR);
            Header.AddCell(cellTitleMetodoDePagoDR);            
            Header.AddCell(cellTitleNumParcialidad);
            Header.AddCell(cellTitleImpSaldoAnt);
            Header.AddCell(cellTitleImpPagado);
            Header.AddCell(cellTitleImpSaldoInsoluto);
            Header.AddCell(cellValueIdDocumento);
            Header.AddCell(cellValueSerie);
            Header.AddCell(cellValueFolioDocumentoRelacionado);
            Header.AddCell(cellValueMonedaDR);
            Header.AddCell(cellValueMetodoDePagoDR);            
            Header.AddCell(cellValueNumParcialidad);
            Header.AddCell(cellValueImpSaldoAnt);
            Header.AddCell(cellValueImpPagado);
            Header.AddCell(cellValueImpSaldoInsoluto);
            Header.AddCell(salto);
            Header.AddCell(cell49);
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


        /*
        public static void CrearNomina(string server,string NombreArchivo,string LugarDeExpedicion,string RFCEmisor,string NombreEmisor,string DireccionEmisor,string Telefono,string UUID,
            string NoSerieCertificado,string Folio,string Serie,string FechaEmision,string EmpleadoNombre,string EmpleadoDepartamento,string EmpleadoRFC,
            string EmpleadoPuesto,string Logo,string EmpleadoCURP,string EmpleadoNSS,string DiasTrabajados,string FechaPago,string FechaInicialPago,
            string FechaFinalPago,string ImporteLetra,string MetodoPago,string CTABancaria,string RegimenFiscal,
            string ISR,string NetoResibido,string SelloCFDI,string SelloSAT,string CadenaOriginal,List<NominaPercepciones> Percepciones,List<NominaDeduccion> Deducciones)
        {
            CultureInfo CI = CultureInfo.CreateSpecificCulture("es-MX");
            string htmlString = System.IO.File.ReadAllText(server+"Tools\\nomina.html");
            string QRString = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=verificacfdi.facturaelectronica.sat.gob.mx%2Fdefault.aspx%3F";
            QRString += "id=" + UUID;
            QRString += "%26re=" + RFCEmisor;
            QRString += "%26rr=" + EmpleadoRFC;
            QRString += "%26tt=" + NetoResibido;
            QRString += "%26fe=" + SelloSAT.Substring(SelloSAT.Length - 8);
            htmlString = htmlString.Replace("<Logo>",Logo);
            htmlString = htmlString.Replace("<CodigoQR>", QRString);
            htmlString = htmlString.Replace("<EmisorRFC>",RFCEmisor);
            htmlString = htmlString.Replace("<EmisorRazonSocial>", NombreEmisor);
            htmlString = htmlString.Replace("<Folio>", Folio);
            htmlString = htmlString.Replace("<Serie>", Serie);
            htmlString = htmlString.Replace("<NoSerie>", NoSerieCertificado);
            htmlString = htmlString.Replace("<FechaEmision>", FechaEmision);
            htmlString = htmlString.Replace("<UUID>", UUID);
            htmlString = htmlString.Replace("<LugarExpedicion>",LugarDeExpedicion);
            htmlString = htmlString.Replace("<EmpleadoNombre>", EmpleadoNombre);
            htmlString = htmlString.Replace("<EmpleadoRFC>", EmpleadoRFC);
            htmlString = htmlString.Replace("<EmpleadoDepartamento>", EmpleadoDepartamento);
            htmlString = htmlString.Replace("<EmpleadoPuesto>", EmpleadoPuesto);
            htmlString = htmlString.Replace("<EmpleadoCURP>", EmpleadoCURP);
            htmlString = htmlString.Replace("<EmpleadoNSS>", EmpleadoNSS);
            htmlString = htmlString.Replace("<DiasTrabajados>", DiasTrabajados);
            htmlString = htmlString.Replace("<FechaPago>", FechaPago);
            htmlString = htmlString.Replace("<FechaInicialPago>", FechaInicialPago);
            htmlString = htmlString.Replace("<FechaFinalPago>", FechaFinalPago);
            htmlString = htmlString.Replace("<ImporteLetra>", ImporteLetra);
            htmlString = htmlString.Replace("<MetodoPago>", MetodoPago);
            htmlString = htmlString.Replace("<CTABancaria>",CTABancaria);
            htmlString = htmlString.Replace("<RegimenFiscal>", RegimenFiscal);
            //htmlString = htmlString.Replace("<Percepciones>", "$"+((double)Percepciones.Sum(x=>x.ImporteExcento+x.ImporteGravado)).ToString("C2",CI));
            htmlString = htmlString.Replace("<Deducciones>", "$"+Deducciones.Where(x=>!x.Tipo.Contains("002")).Sum(x=>x.Importe).ToString("C2",CI));
            htmlString = htmlString.Replace("<ISR>",ISR);
            htmlString = htmlString.Replace("<NetoResibido>","$"+ NetoResibido);
            htmlString = htmlString.Replace("<SelloCFDI>", SelloCFDI);
            htmlString = htmlString.Replace("<SelloSAT>", SelloSAT);
            htmlString = htmlString.Replace("<CadenaOriginal>", CadenaOriginal);
            string row = "";
            foreach (var item in Percepciones.OrderBy(x=>x.FechaCreacion)) {
                row += "<tr class=\"alert alert-success\">";
                //row += "<td class=\"text-center\">"+item.Tipo+"</td>";
               // row += "<td class=\"text-center\">"+item.Clave+"</td>";
                //row += "<td> "+item.Concepto+"</td>";
                //row += "<td> $"+((double)(item.ImporteExcento+item.ImporteGravado)).ToString("C2",CI)+"</td>";
                row += "<td></td>";
                row += "</tr>";
            }
            
            foreach (var item in Deducciones.OrderBy(x=>x.Tipo)) {
                if (item.Tipo == "002")
                    row += "<tr class=\"alert alert-warning\">";
                else row += "<tr class=\"alert alert-danger\">";
                row += "<td class=\"text-center\">" + item.Tipo + "</td>";
                row += "<td class=\"text-center\">" + item.Clave + "</td>";
                row += "<td>" + item.Concepto + "</td>";
                row += "<td></td>";
                row += "<td> " + item.Importe.ToString("C2",CI) + "</td>";
                row += "</tr>";
            }
            htmlString = htmlString.Replace("<ListaPercepcion>", row);
            string baseUrl = "";
            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32("1024");
            }
            catch { }
            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32("");
            }
            catch { }
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();
            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;
            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);
            // save pdf document
            doc.Save(server+"Facturas//"+ RFCEmisor +"//Nominas//"+ NombreArchivo.Replace("SinTimbrar","")+".pdf");
            // close pdf document
            doc.Close();
        }*/
    }
}