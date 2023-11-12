using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;
using System;
using System.Collections.Generic;
using System.Data;
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
                    DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaEspecialidades(txtBuscar.Text).DefaultView;
                }
            }else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaEspecialidades(txtBuscar.Text).DefaultView;
            }
            else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void DataGridEspecialidad_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridEspecialidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridEspecialidad.SelectedItem != null)
            { 
                DataRowView row = (DataRowView)DataGridEspecialidad.SelectedItem;
                txtNombre.Text = row["Especialidad"].ToString();
                btAgregar.IsEnabled = true;
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
            }
            else
            {
                btAgregar.IsEnabled = false;
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
}

        private void DataGridEspecialidad_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarEspecialidad ag = new AgregarEspecialidad();
            ag.ShowDialog();
            DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarEspecialidad me = new ModificarEspecialidad();
            me.ShowDialog();
            DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridEspecialidad.SelectedItem;
            MessageBoxResult resultado = MessageBox.Show($"Esta Seguro que desea Eliminar la Especialidad {txtNombre.Text}.","Confirmación",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes) 
            {
                int id = int.Parse(row["ID"].ToString());
                conectar.EliminarEspecialidad(id);
                DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
            }
        }
    }
}
