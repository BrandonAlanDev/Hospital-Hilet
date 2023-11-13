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
    public partial class Personal : Page
    {
        Conectar conectar = new Conectar();

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridPersonal.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            AgregarPersonal ap = new AgregarPersonal();
            ap.ShowDialog();
            DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
            DataGridPersonal.SelectedValue = id;
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridPersonal.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            ModificarPersonal mp = new ModificarPersonal();
            mp.id = id;
            mp.txtNombre.Text = row["Nombre"].ToString();
            mp.txtApellido.Text = row["Apellido"].ToString();
            mp.txtDni.Text = row["Dni"].ToString();
            mp.categoria = row["Categoria"].ToString();
            mp.especialidad = row["Especialidad"].ToString();
            mp.ShowDialog();
            DataGridPersonal.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
            DataGridPersonal.SelectedValue = id;
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar a {txtNombre.Text} {txtApellido.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)DataGridPersonal.SelectedItem;
                    conectar.EliminarPersonalLaboratorio(int.Parse(row["ID"].ToString()));
                    Limpiar();
                    DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
                }
            }
        }

        private void Limpiar() 
        {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtDni.Text = "Dni";
            txtEspecialidad.Text = "Especialidad";
            txtCategoria.Text = "Categoria";
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                if (e.Key == Key.Enter)
                {
                    DataGridPersonal.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
                }
            }else DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataGridPersonal.ItemsSource = conectar.BuscarEnTablaPersonalLaboratorio(txtBuscar.Text).DefaultView;
            }
            else DataGridPersonal.ItemsSource = conectar.DescargaTablaPersonalLaboratorio().DefaultView;
        }

        private void DataGridPersonal_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
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
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
        }

    }
}
