using MaquetaParaFinal.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void botonPrueba_Click(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.Content = null;
            Medicos medicos = new Medicos();
            FrameNavegacion.Navigate(medicos);
        }
        private void PruebaVolver_Click(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.Content = null;

        }
        private void VentanaPacientes() 
        {
            Pacientes pacientes = new Pacientes();
            FrameNavegacion.Navigate(pacientes);
        }
        private void VolverMenuPrincipal(object sender, EventArgs e)
        {
            FrameNavegacion.Content = null;
            Practicas practicas = new Practicas();
            FrameNavegacion.Navigate(practicas);
        }
    }
}
