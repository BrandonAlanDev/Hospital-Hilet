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
    /// Interaction logic for AgregarServicio.xaml
    /// </summary>
    public partial class AgregarServicio : Window
    {
        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // futura consulta para comprobar que no exista ya dicho servicio
                if (txtNombreServicio.Text != "Nombre" && true)
                {
                    conectar.AgregarServicios(txtNombreServicio.Text);
                    MessageBox.Show("Servicio agregado correctamente");
                    this.Close();
                }
                else MessageBox.Show("El servicio ya existe");
            }
            catch
            {
                MessageBox.Show("Error al ingresar los datos");
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

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
