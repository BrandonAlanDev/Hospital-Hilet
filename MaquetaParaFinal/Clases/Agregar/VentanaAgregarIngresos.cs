using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarIngreso : Window
    {
        Conectar conectar = new Conectar();
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        private bool dniElegido = false;
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtBuscarDni_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBuscarDni.Text == "DNI")
            {
                txtBuscarDni.Text = "";
            }
        }

        private void txtBuscarDni_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBuscarDni.Text == "")
            {
                txtBuscarDni.Text = "DNI";
                txtComboboxDni.Visibility = Visibility.Collapsed;
            }
        }

        private void txtFecha_Loaded(object sender, RoutedEventArgs e)
        {
            fecha = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
            txtFecha.Text = fecha; 
        }

        private void txtMedico_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = conectar.DescargaTablaProfesinales();
            List<string> data = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row["Apellido"].ToString() + " " + row["Nombre"].ToString());
            }
            txtMedico.ItemsSource = null;
            txtMedico.Items.Clear();
            txtMedico.ItemsSource = data;
        }

        private void BuscarDni(object sender, KeyEventArgs e)
        {
            if (txtBuscarDni.Text.Length > 0)
            {
                DataTable dt = conectar.BuscarEnTablaPacientesSoloPorDni(txtBuscarDni.Text);
                List<string> data = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    data.Add(row["Dni"].ToString());
                }
                txtComboboxDni.ItemsSource = null;
                txtComboboxDni.Items.Clear();
                txtComboboxDni.ItemsSource = data;
                txtComboboxDni.Visibility = data.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                if (data.Count > 0)
                {
                    txtComboboxDni.IsDropDownOpen = true;
                    txtBuscarDni.Focus();
                }
            }
            else 
            { 
                txtComboboxDni.Visibility = Visibility.Collapsed;
                txtComboboxDni.IsDropDownOpen = false;
            }
        }

        private void txtComboboxDni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtComboboxDni.Visibility != Visibility.Collapsed) 
            {             
                txtBuscarDni.Text = txtComboboxDni.SelectedItem.ToString() != null ? txtComboboxDni.SelectedItem.ToString() : string.Empty;
                txtComboboxDni.Visibility = Visibility.Collapsed;
                dniElegido = true;
            }
        }

        private bool ComprobarSeleccion() 
        {
            if (dniElegido == true || txtBuscarDni.Text == txtComboboxDni.Text)
            {
                return true;
            }
            return false;
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedico.SelectedValue != null && ComprobarSeleccion())
            {
                int idpaciente = conectar.ObtenerId_Pacientes(txtBuscarDni.Text);
                int idmedico = conectar.ObtenerId_Profesionales(txtMedico.SelectedValue.ToString());
                conectar.AgregarIngresos(fecha,idpaciente, idmedico);
                this.Close();
            }
            else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void SepararNombre() 
        {
            string s = txtMedico.SelectedValue.ToString();
            string[] corte = s.Split(" ");
            foreach (var c in corte)
            {
                apellido = c.ToString();
                nombre = c.ToString();
            }
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void txtBuscarDni_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text)) e.Handled = true;
        }

        private bool IsNumber(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return true;
            }
            return false;
        }

    }
}
