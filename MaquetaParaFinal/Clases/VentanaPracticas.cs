using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Practicas : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridPacticas_Loaded(object sender, RoutedEventArgs e)
        {
            try { 
                DataGridPacticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            } catch { }
        }

    }
}
