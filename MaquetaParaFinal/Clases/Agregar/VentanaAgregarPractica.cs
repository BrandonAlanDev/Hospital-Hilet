using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Data;
using MaquetaParaFinal.Clases;
using System.Text.RegularExpressions;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarPractica : Window
    {
        Conectar conectar = new Conectar();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtNombrePractica_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombrePractica.Text == "Nombre")
            {
                txtNombrePractica.Text = "";
            }
        }

        private void txtNombrePractica_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombrePractica.Text == "")
            {
                txtNombrePractica.Text = "Nombre";
            }
        }
        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Patrón para permitir letras, espacios y comilla simple
            string regEx = @"^[A-Za-z ']{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20)) // La entrada no cumple con el patrón, elimina caracteres no válidos
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-z ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length)); // Limita a 20 caracteres
                textBox.Select(textBox.Text.Length, 0); // Coloca el cursor al final del texto
            }
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombrePractica.Text != "Nombre" && txtEspecialidad.SelectedValue != null && txtTipoDeMuestra.SelectedValue != null)
            {
                int tiempodemora = 0;
                int idEspecialidad = conectar.ObtenerId_Especialidades(txtEspecialidad.Text);
                int idTipoMuestra = conectar.ObtenerId_TiposDeMuestras(txtTipoDeMuestra.Text);
                conectar.AgregarPracticas(txtNombrePractica.Text, idEspecialidad, idTipoMuestra,tiempodemora);
                LimpiarTxt();
                MessageBox.Show("Agregado Correctamente");
            }
            else 
            {
                MessageBox.Show("Plantilla Incompleta","Error",MessageBoxButton.OK,MessageBoxImage.Question);
            }
        }
        private void LimpiarTxt()
        {
            txtNombrePractica.Text = "Nombre";
            txtTipoDeMuestra.Text = null;
            txtEspecialidad.SelectedValue = null;
            txtTipoDeMuestra.SelectedValue = null;
        }
        void CargarEnBoxEspecilidad() 
        {
            DataTable dtespecialidad = conectar.DescargaTablaEspecialidades();
            // Crear una lista para almacenar los datos
            List<string> data = new List<string>();

            foreach (DataRow row in dtespecialidad.Rows)
            {
                data.Add(row["Especialidad"].ToString());
            }
            txtEspecialidad.ItemsSource = null;
            txtEspecialidad.Items.Clear();
            txtEspecialidad.ItemsSource = data;
        }

        void CargarEnBoxTipoDeMuestra()
        {
            DataTable dtesmuestra = conectar.DescargaTablaTiposDeMuestra();
            // Crear una lista para almacenar los datos
            List<string> data = new List<string>();

            foreach (DataRow row in dtesmuestra.Rows)
            {
                data.Add(row["Tipo de Muestra"].ToString());
            }
            txtTipoDeMuestra.ItemsSource = null;
            txtTipoDeMuestra.Items.Clear();
            txtTipoDeMuestra.ItemsSource = data;
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            try{
                CargarEnBoxEspecilidad();
            }catch{ }

            try{
                CargarEnBoxTipoDeMuestra();
            }catch { }

        }
    }
}
