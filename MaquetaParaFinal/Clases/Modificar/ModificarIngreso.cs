using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View.Modificar
{
    public partial class ModificarIngreso : Window
    {
        Conectar conectar = new Conectar();
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
            txtMedico.SelectedValue = medico;
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
            txtMedico.SelectedValue = agregarMedico.medico;
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
            txtComboboxDni.SelectedValue = pacientedni;
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
                    conectar.ModificarIngresos(ID, idpaciente, idmedico);
                    this.Close();
                }
                else MessageBox.Show("DNI No Cargado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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
