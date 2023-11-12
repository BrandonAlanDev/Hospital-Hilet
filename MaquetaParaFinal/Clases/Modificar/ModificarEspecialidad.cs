using System;
using System.Collections.Generic;
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
    public partial class ModificarEspecialidad : Window
    {
        public int id { get; set; }
        private void txtNombreEspecialidad_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombreEspecialidad.Text == "Nombre") 
            {
                txtNombreEspecialidad.Text = "";
            }
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            //TO-DO
        }

        private void txtNombreEspecialidad_GotFocus(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void btnAceptarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            //TO-DO
        }

        private void btnCancelarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //TO-DO
        }
    }
}
