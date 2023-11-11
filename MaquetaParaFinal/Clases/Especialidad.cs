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
    public partial class Especialidad : Page
    {
        Conectar conectar = new Conectar();

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                if (e.Key == Key.Enter)
                {
                    DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
                }
            }else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
            }
            else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void DataGridEspecialidad_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //TO-DO
        }

        private void DataGridEspecialidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TO-DO
        }

        private void DataGridEspecialidad_Loaded(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarEspecialidad ag = new AgregarEspecialidad();
            ag.ShowDialog();
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarEspecialidad me = new ModificarEspecialidad();
            me.ShowDialog();
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }
    }
}
