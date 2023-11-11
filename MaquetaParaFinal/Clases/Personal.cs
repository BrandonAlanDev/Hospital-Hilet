using MaquetaParaFinal.Clases;
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
    public partial class Personal : Page
    {
        Conectar conectar = new Conectar();

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                if (e.Key == Key.Enter)
                {
                    DataGridPersonal.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
                }
            }else DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                DataGridPersonal.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
            }
            else DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
        }

        private void DataGridPersonal_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
            } catch { }
        }

        private void DataGridPersonal_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPersonal.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridPersonal.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtDni.Text = row["Dni"].ToString();
                txtEspecialidad.Text = row["Especialidad"].ToString();
                txtCategoria.Text = row["Categoria"].ToString();
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
    }
}
