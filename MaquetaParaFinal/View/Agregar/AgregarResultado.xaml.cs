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

namespace MaquetaParaFinal.View.Agregar
{
    /// <summary>
    /// Lógica de interacción para AgregarResultado.xaml
    /// </summary>
    public partial class AgregarResultado : Window
    {
        int id;
        public AgregarResultado(int idPxi)
        {
            this.id = idPxi;
            InitializeComponent();
        }

        private void txtResultado_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text == "Nombre")
            {
                txtResultado.Text = "";
            }
        }

        private void txtResultado_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text == "")
            {
                txtResultado.Text = "Nombre";
            }
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnAceptarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
