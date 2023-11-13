using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MaquetaParaFinal.Clases;
using System.Text.RegularExpressions;

namespace MaquetaParaFinal.View.Modificar
{
    public partial class ModificarMedicos : Window
    {
        Conectar conectar = new Conectar();

        int idmedico;

        public ModificarMedicos(int id, string nombre, string apellido, string matricula, string servicios)
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtMatricula.GotFocus += LimpiarTxt;
            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtMatricula.LostFocus += RestaurarNombrePorDefecto;
            CargarServicios();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtMatricula.Text = matricula;
            txtServicio.Text = servicios;
            idmedico = id;
        }

        private readonly Dictionary<string, string> Dicmedicos = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Matricula", "txtMatricula" }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e) // Uso el diccionario para no tener que hacer mil metodos para borrarlo, se tiene que usar como evento en el main.
        {
            if (sender is TextBox textBox)
            {
                if (Dicmedicos.ContainsKey(textBox.Text))
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
                    textBox.Text = Dicmedicos.FirstOrDefault(nom => nom.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void txtServicio_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CargarServicios();
            }
            catch { }
        }
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos())
            {
                int idServicio = conectar.ObtenerId_Servicios(txtServicio.Text);
                conectar.ModificarProfesionales(idmedico,txtNombre.Text, txtApellido.Text, int.Parse(txtMatricula.Text), idServicio);
                MessageBox.Show("Se Modifico el medico correctamente");
                this.Close();
            }
            else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void CargarServicios()
        {
            DataTable dtServicio = conectar.DescargarTablaServicios();
            List<string> data = new List<string>();

            foreach (DataRow row in dtServicio.Rows)
            {
                data.Add(row["Servicio"].ToString());
            }
            txtServicio.ItemsSource = null;
            txtServicio.Items.Clear();
            txtServicio.ItemsSource = data;
        }

        private bool TodosLosCamposLlenos()
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtMatricula.Text != "Matricula" &&
                   txtServicio != null;
        }

        private void btnAgregarServicio_Click(object sender, RoutedEventArgs e)
        {
            AgregarServicio agregarServicio = new AgregarServicio();
            agregarServicio.ShowDialog();
            CargarServicios();
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

    }
}
