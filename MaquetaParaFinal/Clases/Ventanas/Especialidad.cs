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
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                if (e.Key == Key.Enter)
                {
                    DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaEspecialidades(txtBuscar.Text).DefaultView;
                }
            }else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataGridEspecialidad.ItemsSource = conectar.BuscarEnTablaEspecialidades(txtBuscar.Text).DefaultView;
            }
            else DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
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
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
            }
            else
            {
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
        }

        private void DataGridEspecialidad_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
            try
            {
                DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
            }catch{}
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridEspecialidad.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            AgregarEspecialidad ag = new AgregarEspecialidad();
            ag.ShowDialog();
            DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
            DataGridEspecialidad.SelectedValue = id;
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarEspecialidad me = new ModificarEspecialidad();
            DataRowView row = (DataRowView)DataGridEspecialidad.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            me.id = id;
            me.txtNombreEspecialidad.Text = row["Especialidad"].ToString();
            me.ShowDialog();
            DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
            DataGridEspecialidad.SelectedValue = id;
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridEspecialidad.SelectedItem;
            MessageBoxResult resultado = MessageBox.Show($"¿Esta Seguro que desea Eliminar la Especialidad {txtNombre.Text}?","Confirmación",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes) 
            {
                int id = int.Parse(row["ID"].ToString());
                conectar.EliminarEspecialidad(id,conectar.ObtenerId_Especialidades("Sin Especialidad"));
                txtNombre.Text = "Nombre";
                DataGridEspecialidad.ItemsSource = conectar.DescargarTablaEspecialidadesParaElDataGrid().DefaultView;
            }
        }
    }
}
