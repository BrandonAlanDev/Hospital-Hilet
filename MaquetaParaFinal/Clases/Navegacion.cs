using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        private void LoadHome(object sender, RoutedEventArgs e)
        {
            //Hacemos que el frame navegue a la page local Index, con una URI relativa, ya que no ponemos la ruta completa
            btnHome.Background = new SolidColorBrush(Color.FromRgb(240,240,240));
            btnIngresos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPacientes.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPracticas.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnMedicos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));

            btnHome.Foreground = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnIngresos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPacientes.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPracticas.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnMedicos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));

            FrameNavegacion.NavigationService.Navigate(new Uri("View/Index.xaml", UriKind.Relative));
        }
        private void LoadIngresos(object sender, RoutedEventArgs e)
        {
            btnIngresos.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnHome.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPacientes.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPracticas.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnMedicos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));

            btnIngresos.Foreground = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnHome.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPacientes.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPracticas.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnMedicos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));

            FrameNavegacion.NavigationService.Navigate(new Uri("View/Ingresos.xaml", UriKind.Relative));
        }
        private void LoadPacientes(object sender, RoutedEventArgs e)
        {
            btnPacientes.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnIngresos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnHome.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPracticas.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnMedicos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));

            btnPacientes.Foreground = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnIngresos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnHome.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPracticas.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnMedicos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));

            FrameNavegacion.NavigationService.Navigate(new Uri("View/Pacientes.xaml", UriKind.Relative));
        }
        private void LoadPracticas(object sender, RoutedEventArgs e)
        {
            btnPracticas.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPacientes.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnIngresos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnHome.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnMedicos.Background = new SolidColorBrush(Color.FromRgb(33, 53, 85));

            btnPracticas.Foreground = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPacientes.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnIngresos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnHome.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnMedicos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));

            FrameNavegacion.NavigationService.Navigate(new Uri("View/Practicas.xaml", UriKind.Relative));
        }
        private void LoadMedicos(object sender, RoutedEventArgs e)
        {
            btnMedicos.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPracticas.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPacientes.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnIngresos.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnHome.Background = new SolidColorBrush(Color.FromRgb(79, 112, 156));

            btnMedicos.Foreground = new SolidColorBrush(Color.FromRgb(79, 112, 156));
            btnPracticas.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnPacientes.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnIngresos.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            btnHome.Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));

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
