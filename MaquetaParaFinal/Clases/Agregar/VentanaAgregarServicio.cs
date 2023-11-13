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
    /// <summary>
    /// Interaction logic for AgregarServicio.xaml
    /// </summary>
    public partial class AgregarServicio : Window
    {
        private void btnAceptarAgServicio_Click(object sender, RoutedEventArgs e)
        {
            if (conectar.ValidarSiexisteServicio(txtNombreServicio.Text) != 1)
            {
                if (txtNombreServicio.Text != "Nombre")
                {
                    try
                    {
                        conectar.AgregarServicios(txtNombreServicio.Text);
                        MessageBox.Show("Servicio agregado correctamente");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al ingresar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }else MessageBox.Show("Ingrese un Nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }else MessageBox.Show("El servicio ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            string regEx = @"^[A-Za-zÁ-Úá-ú ']{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20)) // La entrada no cumple con el patrón, elimina caracteres no válidos
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-zÁ-Úá-ú ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length)); // Limita a 20 caracteres
                textBox.Select(textBox.Text.Length, 0); // Coloca el cursor al final del texto
            }
        }

        private void txtNombreServicio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreServicio.Text == "")
            {
                txtNombreServicio.Text = "Nombre";
            }
        }

        private void txtNombreServicio_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreServicio.Text == "Nombre")
            {
                txtNombreServicio.Text = "";
            }
        }

        private void btnCancelarAgServicio_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
