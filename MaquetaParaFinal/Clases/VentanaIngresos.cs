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
    public partial class Ingresos : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridIngresos_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridIngresos.ItemsSource = conectar.Des
        }
    }
}
