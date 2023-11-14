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

namespace MaquetaParaFinal.View.Modificar
{
    public partial class ModificarEspecialidad : Window
    {
        Conectar conectar = new Conectar();

        public int id { get; set; }

        public ModificarEspecialidad()
        {
            InitializeComponent();
        }

        private void txtNombreEspecialidad_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreEspecialidad.Text == "Nombre") 
            {
                txtNombreEspecialidad.Text = "";
            }
        }

        private void txtNombreEspecialidad_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreEspecialidad.Text == "")
            {
                txtNombreEspecialidad.Text = "Nombre";
            }
        }

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


        private void btnAceptarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreEspecialidad.Text != "")
            {
                conectar.ModificarEspecialidades(id,txtNombreEspecialidad.Text);
                this.Close();
            }
        }

        private void btnCancelarAgEspecialidad_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }
    }
}
