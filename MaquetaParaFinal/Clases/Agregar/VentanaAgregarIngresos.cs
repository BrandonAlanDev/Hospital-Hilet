using iText.Layout.Element;
using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtComboboxDni_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtComboboxDni.Text == "")
            {
                txtComboboxDni.Text = "DNI";
            }
        }

        private void txtComboboxDni_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtComboboxDni.Text == "DNI")
            {
                txtComboboxDni.Text = "";
            }
        }

        private void txtFecha_Loaded(object sender, RoutedEventArgs e)
        {
            fecha = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
            txtFecha.Text = fecha; 
        }

        private void ActualizarMedicos()
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

        private void txtMedico_Loaded(object sender, RoutedEventArgs e)
        {
            ActualizarMedicos();
        }

        private void btnAgregarMedico(object sender, RoutedEventArgs e)
        {
            AgregarMedico agregarMedico = new AgregarMedico();
            agregarMedico.ShowDialog();
            ActualizarMedicos();
        }

        private void ActualizarDNI()
        {
            DataTable dt = conectar.DescargaTablaPaciente();
            List<string> data = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row["Dni"].ToString());
            }
            txtComboboxDni.ItemsSource = null;
            txtComboboxDni.Items.Clear();
            txtComboboxDni.ItemsSource = data;
        }

        private void txtComboboxDni_Loaded(object sender, RoutedEventArgs e)
        {
            ActualizarDNI();
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedico.SelectedValue != null && txtComboboxDni.Text != "DNI")
            {
                int idpaciente = conectar.ObtenerId_Pacientes(txtComboboxDni.Text);
                int idmedico = conectar.ObtenerId_Profesionales(txtMedico.Text);
                if (idpaciente != -1) 
                {
                    conectar.AgregarIngresos(fecha, idpaciente, idmedico);
                    this.Close();
                    VentanaPracticaPorIngreso pxi = new VentanaPracticaPorIngreso(conectar.ObtenerUltimaIDIngresos());
                    pxi.ShowDialog();
                }else MessageBox.Show("DNI No Cargado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnAgregarPaciente(object sender, RoutedEventArgs e)
        {
            AgregarPaciente agregarPaciente = new AgregarPaciente();
            agregarPaciente.ShowDialog();
            ActualizarDNI();
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
