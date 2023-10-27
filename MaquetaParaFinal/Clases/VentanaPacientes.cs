using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Pacientes : Page
    {
        Conectar conectar = new Conectar();
        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Dni", "txtDni" },
            { "Email", "txtEmail" },
            { "Fecha De Nacimiento", "txtFecha_De_Nacimiento" },
            { "Telefono", "txtTelefono" },
            { "Calle", "txtCalle" },
            { "Nro", "txtNro" },
            { "Localidad", "txtLocalidad" },
            { "Codigo Postal", "txtCodPostas" },
            { "Piso", "txtPiso" }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e) // Uso el diccionario para no tener que hacer mil metodos para borrarlo, se tiene que usar como evento en el main.
        {
            if (sender is TextBox textBox)
            {
                if (Dicpacientes.ContainsKey(textBox.Text))
                {
                    textBox.Clear();
                }
            }
        }
        private void RestaurarNombrePorDefecto(object sender, RoutedEventArgs e) // Para cuando se pierde el focus y queda vacio
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = Dicpacientes.FirstOrDefault(pair => pair.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
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
            if (DataGridPacientes.SelectedItem != null && DataGridPacientes.Items.Count >= num)
            {
                DataGridPacientes.SelectedIndex = num;
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
        private void DataGridPacientes_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridPacientes.ItemsSource = conectar.DescargaTablaPaciente().DefaultView;
        }


        private void DataGridPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridPacientes.SelectedItem; 
            CargarSeleccion(int.Parse(row["ID"].ToString()) - 1); //-1 Porque el Datagrid comienza en 0 y el id en 1 (ya le dije al ale que inicie en 0)
        }

        private void FiltrarDatos(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return;
            }

            foreach (DataRowView columna in DataGridPacientes.ItemsSource)
            {
                int mostrarFila = -1;

                for (int i = 0; i < columna.Row.ItemArray.Length; i++)
                {
                    if (columna.Row.ItemArray[i] is string valorCelda)
                    { // "StringComparison.OrdinalIgnoreCase" es para que compare pero ignorando las diferencias de mayusculas y minusculas
                        if (valorCelda.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0) // Aca compara el valor de la celda con lo buscando
                        {
                            mostrarFila = int.Parse(columna.Row["ID"].ToString())-1;
                            break;
                        }
                    }
                }
                if (mostrarFila != -1) 
                {
                    DataGridPacientes.SelectedIndex = mostrarFila;
                    CargarSeleccion(mostrarFila);
                }
            }
        }
    }
}
