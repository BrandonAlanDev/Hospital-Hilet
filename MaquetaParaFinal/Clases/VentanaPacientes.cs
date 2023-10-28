using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaquetaParaFinal.View
{
    public partial class Pacientes : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridPacientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void DataGridPacientes_Loaded(object sender, RoutedEventArgs e)
        {
            try {             
                DataGridPacientes.ItemsSource = conectar.DescargaTablaPaciente().DefaultView;
            } catch { }
        }
       
        private void DataGridPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPacientes.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridPacientes.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtDni.Text = row["Dni"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtFecha_De_Nacimiento.Text = row["Fecha De Nacimiento"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCalle.Text = row["Calle"].ToString();
                txtNro.Text = row["Numero"].ToString();
                txtLocalidad.Text = row["Localidad"].ToString();
                txtCodPostas.Text = row["Codigo Postal"].ToString();
                txtPiso.Text = row["Piso"].ToString();
            }
        }
        private void ClickBuscar(object sender, RoutedEventArgs e) 
        {
            DataGridPacientes.ItemsSource = conectar.BuscarEnTablaPacientes(txtBuscar.Text).DefaultView;
        }
        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            { 
                DataGridPacientes.ItemsSource = conectar.BuscarEnTablaPacientes(txtBuscar.Text).DefaultView;
            }
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPaciente agregarPaciente = new AgregarPaciente();
            agregarPaciente.ShowDialog();
        }
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar a {txtNombre.Text} {txtApellido.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    // Aquí va el código para eliminar si lo tuviera (ponete a laburar alejandro)
                }
            }
        }
        private void btnImprimirPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre") 
            { 
                Impresora impresora = new Impresora();
                impresora.ImprimirDocumento();
            }
            
        }
    }
}
