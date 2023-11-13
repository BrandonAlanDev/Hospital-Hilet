using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    /// <summary>
    /// Lógica de interacción para AgregarResultado.xaml
    /// </summary>
    public partial class AgregarResultado : Window
    {
        int id;

        Conectar conectar = new Conectar();

        public AgregarResultado(int idPxi, string resultado)
        {
            this.id = idPxi;
            InitializeComponent();
            txtResultado.Text = resultado;
        }

        private void txtResultado_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text == "Resultado")
            {
                txtResultado.Text = "";
            }
        }

        private void txtResultado_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text == "")
            {
                txtResultado.Text = "Resultado";
            }
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnAceptarAgEspecialidad_Click(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text != "Resultado")
            {
                try 
                { 
                    conectar.ActualizarResultado(id, txtResultado.Text);
                    this.Close();
                }
                catch 
                { 
                    MessageBox.Show("Falló la conexión.","ERROR",MessageBoxButton.OK,MessageBoxImage.Warning); 
                }
            }else MessageBox.Show("Formulario Incompleto", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnCancelarAgEspecialidad_Click(object sender, RoutedEventArgs e) => this.Close();

    }
}
