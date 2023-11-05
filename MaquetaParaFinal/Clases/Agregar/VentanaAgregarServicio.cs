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
