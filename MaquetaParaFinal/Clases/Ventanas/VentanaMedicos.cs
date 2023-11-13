using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;

namespace MaquetaParaFinal.View
{
    public partial class Medicos : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
            try{
                DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            }catch{}
        }

        private void DataGridMedicos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridMedicos.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtMatricula.Text = row["Matricula"].ToString();
                txtServicio.Text = row["Servicio"].ToString();
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
            }
            else
            {
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) 
            { 
                if (e.Key == Key.Enter)
                {
                    DataGridMedicos.ItemsSource = conectar.BuscarEnTablaProfesionales(txtBuscar.Text).DefaultView;
                }
            }else DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataGridMedicos.ItemsSource = conectar.BuscarEnTablaProfesionales(txtBuscar.Text).DefaultView;
            }else DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            AgregarMedico agregarMedico = new AgregarMedico();
            agregarMedico.ShowDialog();
            DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            DataGridMedicos.SelectedValue = id;
        }
        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            ModificarMedicos modificarMedico = new ModificarMedicos(id, txtNombre.Text,txtApellido.Text,txtMatricula.Text,txtServicio.Text);
            modificarMedico.ShowDialog();
            DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            DataGridMedicos.SelectedValue = id;
        }
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar a {txtNombre.Text} {txtApellido.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
                    conectar.EliminarProfesional(int.Parse(row["ID"].ToString()));
                    DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
                    Limpiar();
                }
            }
        }

        private void Limpiar() 
        {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtMatricula.Text = "Matricula";
            txtServicio.Text = "Servicio";
        }

    }
}