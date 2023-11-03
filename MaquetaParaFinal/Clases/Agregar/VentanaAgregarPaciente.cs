using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Automation;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarPaciente : Window
    {
        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Dni", "txtDni" },
            { "Email", "txtEmail" },
            { "YYYY-MM-DD", "txtFecha_De_Nacimiento" },
            { "Teléfono", "txtTelefono" },
            { "Calle", "txtCalle" },
            { "Nro", "txtNro" },
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

        private void AbrirDatePicker_Click(object sender, RoutedEventArgs e)
        {
            // Abre el Popup que contiene el DatePicker
            datePickerPopup.IsOpen = true;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Captura la fecha seleccionada y cierra el Popup
            datePickerPopup.IsOpen = false;

            // Puedes utilizar la fecha seleccionada como desees
            DateTime fechaSeleccionada = datePicker.SelectedDate ?? DateTime.Now;
            string fecha = $"{fechaSeleccionada.Year}-{fechaSeleccionada.Month}-{fechaSeleccionada.Day}";

            txtFecha_De_Nacimiento.Text = fecha;
        }
        private void RestaurarNombrePorDefecto(object sender, RoutedEventArgs e) // Para cuando se pierde el focus y queda vacio
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = Dicpacientes.FirstOrDefault(nom => nom.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos()) 
            {
                if (txtEmail.Text == "Email") txtEmail.Text = "";
                if (txtTelefono.Text == "Teléfono") txtTelefono.Text = "";
                try
                {
                    int id = conectar.ObtenerId_Localidad(txtLocalidad.Text);
                    conectar.AgregarPaciente(txtNombre.Text, txtApellido.Text, txtFecha_De_Nacimiento.Text, txtDni.Text, txtEmail.Text, txtTelefono.Text, txtCalle.Text, txtNro.Text, txtPiso.Text, id);
                    LimpiarTxt();
                    MessageBox.Show("Agregado Correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Compruebe Los Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool TodosLosCamposLlenos() //Era muy largo el if si no :c
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtFecha_De_Nacimiento.Text != "Fecha De Nacimiento" &&
                   txtDni.Text != "Dni" &&
                   txtCalle.Text != "Calle" &&
                   txtNro.Text != "Nro" &&
                   txtPiso.Text != "Piso" &&
                   txtLocalidad.SelectedValue != null;
        }

        private void LimpiarTxt()
        {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtFecha_De_Nacimiento.Text = "Fecha De Nacimiento";
            txtDni.Text = "Dni";
            txtCalle.Text = "Calle";
            txtNro.Text = "Nro";
            txtPiso.Text = "Piso";
            txtLocalidad.SelectedValue = null;
            txtCodPostas.SelectedValue = null;
        }

        private void CargarLocalidades()
        {
            string connectionString = "workstation id=SegundoCuatriTp1.mssql.somee.com;packet size=4096;user id=Lucho_SQLLogin_2;pwd=66e99i24sw;data " +
            "source=SegundoCuatriTp1.mssql.somee.com;persist security info=False;initial catalog=SegundoCuatriTp1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Nombre_Localidad AS Localidad FROM Localidades";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    txtLocalidad.ItemsSource = null;
                    txtLocalidad.Items.Clear();

                    // Crear una lista para almacenar los datos
                    List<string> data = new List<string>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        data.Add(row["Localidad"].ToString());
                    }

                    // Asignar los datos al ComboBox
                    txtLocalidad.ItemsSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void CargarCodigoPostal()
        {
            string connectionString = "workstation id=SegundoCuatriTp1.mssql.somee.com;packet size=4096;user id=Lucho_SQLLogin_2;pwd=66e99i24sw;data " +
            "source=SegundoCuatriTp1.mssql.somee.com;persist security info=False;initial catalog=SegundoCuatriTp1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT Codigo_Postal AS CodPostal FROM Localidades WHERE Nombre_Localidad = '{txtLocalidad.SelectedItem}'";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (txtCodPostas.IsEnabled == false) txtCodPostas.IsEnabled = true;
                    txtCodPostas.ItemsSource = null;
                    txtCodPostas.Items.Clear();

                    // Crear una lista para almacenar los datos
                    List<string> data = new List<string>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        data.Add(row["CodPostal"].ToString());
                    }

                    // Asignar los datos al ComboBox
                    txtCodPostas.ItemsSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void AgregarPacientes_Loaded(object sender, RoutedEventArgs e) => CargarLocalidades();

        private void BuscarCodigoPostal(object sender, SelectionChangedEventArgs e) => CargarCodigoPostal();
    }
}
