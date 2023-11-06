using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
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
            try{
                DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
            } catch{}
        }
        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarIngreso agregarIngreso = new AgregarIngreso();
            agregarIngreso.ShowDialog();
            DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }
    }
}
