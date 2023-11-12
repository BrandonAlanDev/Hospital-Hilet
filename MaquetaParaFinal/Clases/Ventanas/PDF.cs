using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iText;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        //Ruta para el guardar el documento
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\DocumentosPDF\";
        public void CrearPdf()
        {
            var exportarPDF = System.IO.Path.Combine(path, "Documento.pdf");
            //Instanciamos el pdfwriter que es lo que nos permite modificar pdf de forma local
            using (var writer = new PdfWriter(exportarPDF))
            {
                //Instanciamos un archivo del formato PDF Document, al que se le requiere pasar un writer que nos permita modificar el mismo
                using (var pdf = new PdfDocument(writer))
                {
                    //Instanciamos el documento y le damos el formato A4 gracias a iText
                    var doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4);
                    doc.SetMargins(90,0,0,0);
                    //Cargo desde disco la imagen
                    ImageData logo = ImageDataFactory.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DocumentosPDF\logo.png");
                    //Defino la imagen y defino sus parametros
                    var image = new iText.Layout.Element.Image(logo)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFixedPosition(1,10,700)
                    ;

                    //Agrego la imagen
                    doc.Add(image);

                    Paragraph encabezado = new Paragraph("");
                    encabezado.Add(image);

                    doc.Add(encabezado);




                }
            }
        }
    }
}
