using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View
{
    public partial class Categorias : Page
    {
        Conectar conectar = new Conectar();

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarCategoria mc = new ModificarCategoria();
            mc.ShowDialog();
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarCategorias ac = new AgregarCategorias();
            ac.ShowDialog();
        }

        private void DataGridCategoria_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
            try {
                DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
            } catch { }
        }

        private void DataGridCategoria_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {

        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {

        }
    }
}
