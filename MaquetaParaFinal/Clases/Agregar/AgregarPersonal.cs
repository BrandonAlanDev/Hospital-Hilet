using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarPersonal : Window
    {
        Conectar conectar = new Conectar();

        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string>
        {
            { "Nombre", "txtNombre" },
            { "Apellido", "txtApellido" },
            { "DNI", "txtDni" }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e)
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
                    textBox.Text = Dicpacientes.FirstOrDefault(nom => nom.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            string regEx = @"^[A-Za-z ']{1,20}$";
            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20))
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-z ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = conectar.DescargarTablaEspecialidades();
            List<string> data = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row["Especialidad"].ToString());
            }
            txtEspecialidad.ItemsSource = null;
            txtEspecialidad.Items.Clear();
            txtEspecialidad.ItemsSource = data;

            dt = conectar.DescargaTablaCategorias();
            List<string> data1 = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data1.Add(row["Categoria"].ToString());
            }
            txtCategoria.ItemsSource = null;
            txtCategoria.Items.Clear();
            txtCategoria.ItemsSource = data1;
        }

        private void SoloNumero(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            string regEx = @"^[0-9]{1,20}$";
            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20) && input != "DNI")
            {
                textBox.Text = Regex.Replace(input, @"[^0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarQueIngresoDatos())
            {
                int cat = conectar.ObtenerId_Categorias(txtCategoria.Text);
                int esp = conectar.ObtenerId_Especialidades(txtEspecialidad.Text);
                conectar.AgregarPersonalLaboratorio(txtNombre.Text, txtApellido.Text, cat, esp);
            }
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAgregarEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            AgregarEspecialidad agregarEspecialidad = new AgregarEspecialidad();
            agregarEspecialidad.ShowDialog();
        }
        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }
        
        private bool VerificarQueIngresoDatos() 
        {
            return txtCategoria.Text != string.Empty &&
                   txtEspecialidad.Text != string.Empty &&
                   txtDni.Text != "DNI" &&
                   txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido";
        }

    }
}
