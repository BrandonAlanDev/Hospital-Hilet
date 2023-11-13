using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
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
    public partial class AgregarCategorias : Window
    {
        Conectar conectar = new Conectar();

        public AgregarCategorias()
        {
            InitializeComponent();
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            string regEx = @"^[A-Za-zÁ-Úá-ú 0-9]{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20))
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-zÁ-Úá-ú 0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void txtNombreCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                btnAceptarAgCategoria_Click(sender,e);
            }
        }

        private void txtNombreCategoria_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreCategoria.Text == "Nombre") 
            {
                txtNombreCategoria.Text = "";
            }
        }

        private void txtNombreCategoria_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreCategoria.Text == "")
            {
                txtNombreCategoria.Text = "Nombre";
            }
        }

        private void btnAceptarAgCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreCategoria.Text != "Nombre") 
            {
                conectar.AgregarCategorias(txtNombreCategoria.Text);
                this.Close();
            }
        }

        private void btnCancelarAgCategoria_Click(object sender, RoutedEventArgs e) => this.Close();

    }
}
