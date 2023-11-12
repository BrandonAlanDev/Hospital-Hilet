using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace MaquetaParaFinal.View.Modificar
{
    public partial class ModificarPaciente : Window
    {
        Conectar conectar = new Conectar();

        public int Id { get; set; }

        public string Localidad { get; set; }

        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Dni", "txtDni" },
            { "Email", "txtEmail" },
            { "Fecha De Nacimiento", "txtFecha_De_Nacimiento" },
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

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            string regEx = @"^[A-Za-z ']{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20)) // La entrada no cumple con el patrón, elimina caracteres no válidos
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-z ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length)); // Limita a 20 caracteres
                textBox.Select(textBox.Text.Length, 0); // Coloca el cursor al final del texto
            }
        }

        private void SoloNumero(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Patrón para permitir solo números
            string regEx = @"^[0-9]{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20)) // La entrada no cumple con el patrón, elimina caracteres no válidos
            {
                textBox.Text = Regex.Replace(input, @"[^0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length)); // Limita a 20 caracteres
                textBox.Select(textBox.Text.Length, 0); // Coloca el cursor al final del texto
            }
        }

        private void AbrirDatePicker_Click(object sender, RoutedEventArgs e)
        {
            // Abre el Popup que contiene el DatePicker
            if (datePickerPopup.IsOpen == false)
            {
                datePickerPopup.IsOpen = true;
                DateTime fechaHace150Anios = DateTime.Now.AddYears(-150);
                datePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, fechaHace150Anios));
                datePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
                BotonFecha.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(239, 98, 98));
                BotonFecha.Content = "Cerrar Fecha";
                datePicker.Focus();
            }
            else
            {
                datePickerPopup.IsOpen = false;
                BotonFecha.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(143, 198, 67));
                BotonFecha.Content = "Ingresar Fecha";
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime fechaSeleccionada = datePicker.SelectedDate ?? DateTime.Now;
            string fecha = $"{fechaSeleccionada.Year}-{fechaSeleccionada.Month}-{fechaSeleccionada.Day}";

            txtFecha_De_Nacimiento.Text = fecha;

            BotonFecha.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(143, 198, 67));
            BotonFecha.Content = "Ingresar Fecha";
            datePickerPopup.IsOpen = false;
            BotonFecha.Focus();
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

        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            CargarLocalidades();
            txtLocalidad.SelectedValue = Localidad;
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos())
            {
                if (txtEmail.Text == "Email") txtEmail.Text = "";
                if (txtTelefono.Text == "Teléfono") txtTelefono.Text = "";
                try
                {
                    int idLocalidad = conectar.ObtenerId_Localidades(txtLocalidad.Text);
                    conectar.ModificarPacientes(Id,txtNombre.Text, txtApellido.Text, txtFecha_De_Nacimiento.Text, txtDni.Text, txtEmail.Text, txtTelefono.Text, txtCalle.Text, txtNro.Text, txtPiso.Text, idLocalidad);
                    MessageBox.Show("Modificado Correctamente");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Compruebe Los Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool TodosLosCamposLlenos()
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtFecha_De_Nacimiento.Text != "Fecha De Nacimiento" &&
                   txtDni.Text != "Dni" &&
                   txtCalle.Text != "Calle" &&
                   txtNro.Text != "Nro" &&
                   txtPiso.Text != "Piso" &&
                   txtLocalidad.SelectedValue != null; ;
        }

        private void CargarLocalidades()
        {
            DataTable dtLocaldiades = conectar.DescargarTablaLocalidades();
            List<string> data = new List<string>();

            foreach (DataRow row in dtLocaldiades.Rows)
            {
                data.Add(row["Localidad"].ToString());
            }
            // Asignar los datos al ComboBox
            txtLocalidad.ItemsSource = null;
            txtLocalidad.Items.Clear();
            txtLocalidad.ItemsSource = data;
        }

        private void CargarCodigoPostal()
        {
            DataTable dtCodigoPostal = conectar.DescargarTablaCodPostal(txtLocalidad.SelectedItem);
            // Crear una lista para almacenar los datos
            List<string> data = new List<string>();

            foreach (DataRow row in dtCodigoPostal.Rows)
            {
                data.Add(row["CodPostal"].ToString());
            }
            if (txtCodPostas.IsEnabled == false) txtCodPostas.IsEnabled = true;
            txtCodPostas.ItemsSource = null;
            txtCodPostas.Items.Clear();
            txtCodPostas.ItemsSource = data;
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void AgregarPacientes_Loaded(object sender, RoutedEventArgs e) => CargarLocalidades();

        private void BuscarCodigoPostal(object sender, SelectionChangedEventArgs e) => CargarCodigoPostal();
    
    }
}