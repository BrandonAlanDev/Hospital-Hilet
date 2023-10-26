using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        private void LoadHome(object sender, RoutedEventArgs e)
        {
            //Hacemos que el frame navegue a la page local Index, con una URI relativa, ya que no ponemos la ruta completa
            FrameNavegacion.NavigationService.Navigate(new Uri("View/Index.xaml", UriKind.Relative));
        }
        private void LoadIngresos(object sender, RoutedEventArgs e)
        {
            // ejemplo de uri absoluta
            FrameNavegacion.NavigationService.Navigate(new Uri("https://www.habbo.es/", UriKind.Absolute));
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
            DoubleAnimation animation = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.2)));
            animation.Completed += (s, _) => Close();
            BeginAnimation(UIElement.OpacityProperty, animation);
        }


        private void btnMaxMin(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
