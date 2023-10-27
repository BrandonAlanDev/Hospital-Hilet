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
    public partial class Medicos : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;

        }
    }
}
