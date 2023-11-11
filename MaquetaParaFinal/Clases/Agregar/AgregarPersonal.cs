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
            DataTable dtEspe = conectar.DescargarTablaEspecialidades();
            List<string> data = new List<string>();

            foreach (DataRow row in dtEspe.Rows)
            {
                data.Add(row["Especialidad"].ToString());
            }
            txtEspecialidad.ItemsSource = null;
            txtEspecialidad.Items.Clear();
            txtEspecialidad.ItemsSource = data;
        }

        private void SoloNumero(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            string regEx = @"^[0-9]{1,20}$";
            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20))
            {
                textBox.Text = Regex.Replace(input, @"[^0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAgregarEspecialidad_Click(object sender, RoutedEventArgs e)
        {
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

    }
}
