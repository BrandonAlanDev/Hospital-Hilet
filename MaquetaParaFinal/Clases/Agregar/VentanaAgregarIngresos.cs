using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarIngreso : Window
    {
        Conectar conectar = new Conectar();
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtDni_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text == "DNI")
            {
                txtDni.Text = "";
            }
        }

        private void txtDni_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text == "")
            {
                txtDni.Text = "DNI";
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

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedico.SelectedValue != null && txtDni.Text != "DNI")
            {
                SepararNombre();
                int idpaciente = conectar.ObtenerId_Pacientes(txtDni.Text);
                int idmedico = conectar.ObtenerId_Profesionales(nombre, apellido);
                conectar.AgregarIngresos(fecha,idpaciente, idmedico);
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

    }
}
