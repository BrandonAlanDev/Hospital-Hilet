using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        private void LoadHome(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Index.xaml", UriKind.Relative));
        }
        private void LoadIngresos(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Index.xaml", UriKind.Relative));
        }
        private void LoadPacientes(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Pacientes.xaml", UriKind.Relative));
        }
        private void LoadPracticas(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Practicas.xaml", UriKind.Relative));
        }
        private void LoadMedicos(object sender, RoutedEventArgs e)
        {
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Medicos.xaml", UriKind.Relative));
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
