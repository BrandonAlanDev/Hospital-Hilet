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
            TxtBoxes.IsEnabled = true;
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxes.IsEnabled = false;
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            //GARGAR LOCALIDAD Y EXTRAER LA FK
            // conectar.AgregarPaciente(txtNombre,txtApellido,txtFecha_De_Nacimiento,txtDni,txtEmail,txtTelefono,txtCalle,txtNro,txtPiso,"SinHacer");
        }
        private void CargarSeleccion(int num = 0)
        {
            
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


        private void DataGridPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridPacientes.SelectedItem;
            CargarSeleccion(int.Parse(row["ID"].ToString()) - 1); //-1 Porque el Datagrid comienza en 0 y el id en 1 (ya le dije al ale que inicie en 0)
        }
        private void EnterBuscar(object sender, KeyEventArgs e)
        {
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPaciente agregarPaciente = new AgregarPaciente();
            agregarPaciente.Show();
        }
    }
}
