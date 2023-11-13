using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace MaquetaParaFinal.Clases.Ventanas
{
    public class Impresora
    {
        public void ImprimirDocumento()
        {
            // Crear una instancia de la clase LocalPrintServer para obtener la impresora predeterminada.
            LocalPrintServer impresora = new LocalPrintServer();

            // Obtener la impresora predeterminada.
            PrintQueue impresoraConsulta = impresora.DefaultPrintQueue;

            // Crear un objeto PrintDialog para configurar las opciones de impresión.
            PrintDialog impresoraDialog = new PrintDialog();
            impresoraDialog.PrintQueue = impresoraConsulta;

            if (impresoraDialog.ShowDialog() == true)
            {

                // DocumentPaginatorSource: Un FlowDocument es un ejemplo común, pero puede ser otro tipo que implemente IDocumentPaginatorSource.
                FlowDocument document = new FlowDocument(new Paragraph(new Run("8=D")));
                IDocumentPaginatorSource paginatorSource = document;

                // Configura la impresora seleccionada por el usuario.
                impresoraDialog.PrintQueue.UserPrintTicket = impresoraDialog.PrintQueue.DefaultPrintTicket;

                // Imprime en la impresora seleccionada.
                impresoraDialog.PrintDocument(paginatorSource.DocumentPaginator, "Documento Medico");
            }
        }
        private void MostrarVistaPrevia(string texto) // No anda necesita un archivo pfd
        {
            // Crear un FlowDocument con el contenido que deseas imprimir.
            FlowDocument document = new FlowDocument(new Paragraph(new Run(texto)));

            // Crear un objeto DocumentPaginatorSource para el documento.
            IDocumentPaginatorSource paginatorSource = document;

            // Crear un objeto DocumentViewer para la vista previa.
            DocumentViewer viewer = new DocumentViewer();
            viewer.Document = document;

            // Crear una ventana para la vista previa.
            Window previewWindow = new Window
            {
                Title = "Vista Previa del Documento",
                Content = viewer,
                Width = 600,
                Height = 800
            };

            // Mostrar la ventana de vista previa.
            previewWindow.ShowDialog();
        }
    }
}
