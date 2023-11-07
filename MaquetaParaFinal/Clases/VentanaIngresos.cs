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
            try
            {
                DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
            } catch{}
        }
        private void btPracticas_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnImprimirPaciente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
