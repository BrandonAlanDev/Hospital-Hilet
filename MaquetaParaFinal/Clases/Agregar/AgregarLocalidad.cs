using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarLocalidad : Window
    {
        Conectar conectar = new Conectar();

        private void txtCodLocal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCodPostal.Text == "Codigo Postal")
            {
                txtCodPostal.Text = "";
            }
        }

        private void txtCodLocal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCodPostal.Text == "")
            {
                txtCodPostal.Text = "Codigo Postal";
            }
        }

        private void txtNombreLocal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreLocalidad.Text =="") 
            {
                txtNombreLocalidad.Text = "Nombre";
            }
        }

        private void txtNombreLocal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreLocalidad.Text == "Nombre")
            {
                txtNombreLocalidad.Text = "";
            }
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            string regEx = @"^[A-Za-zÁ-Úá-ú ']{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20))
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-zÁ-Úá-ú ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void SoloNumero(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            string regEx = @"^[0-9]{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20) && input != "Codigo Postal")
            {
                textBox.Text = Regex.Replace(input, @"[^0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void txtCodLocal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNombreLocal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAceptarAgLocalidad_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodPostal.Text != "Codigo Postal" && txtNombreLocalidad.Text != "Nombre")
            {
                conectar.AgregarLocalidades(txtNombreLocalidad.Text, txtCodPostal.Text);
                this.Close();
            }else MessageBox.Show("Plantilla Incompleta","ERROR",MessageBoxButton.OK,MessageBoxImage.Exclamation);
        }

        private void btnCancelarAgLocalidad_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
