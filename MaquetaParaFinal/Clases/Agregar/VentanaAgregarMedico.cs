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

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarMedico : Window
    {
        Conectar conectar = new Conectar();

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

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos())
            {
                int idServicio = conectar.ObtenerId_Servicio(txtServicio.Text);
                conectar.AgregarProfesionales(txtNombre.Text, txtApellido.Text, int.Parse(txtMatricula.Text), idServicio);
                LimpiarTxt();
                return;
            }
            MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool TodosLosCamposLlenos()
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtMatricula.Text != "Matricula" &&
                   txtServicio != null;
        }

        private void LimpiarTxt()
        {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtMatricula.Text = "Matricula";
        }

        private void CargarServicios()
        {
            string connectionString = "workstation id=SegundoCuatriTp1.mssql.somee.com;packet size=4096;user id=Lucho_SQLLogin_2;pwd=66e99i24sw;data " +
            "source=SegundoCuatriTp1.mssql.somee.com;persist security info=False;initial catalog=SegundoCuatriTp1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Nombre_Servicio AS Servicio FROM Servicios";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    txtServicio.ItemsSource = null;
                    txtServicio.Items.Clear();

                    // Crear una lista para almacenar los datos
                    List<string> data = new List<string>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        data.Add(row["Servicio"].ToString());
                    }

                    // Asignar los datos al ComboBox
                    txtServicio.ItemsSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAgregarServicio_Click(object sender, RoutedEventArgs e) 
        {
            AgregarServicio agregarServicio = new AgregarServicio();
            agregarServicio.ShowDialog();
            CargarServicios();
        }
    }
}
