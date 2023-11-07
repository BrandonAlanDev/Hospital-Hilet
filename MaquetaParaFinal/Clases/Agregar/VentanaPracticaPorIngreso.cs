using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class VentanaPracticaPorIngreso : Window
    {
        private void Salir(object sender, RoutedEventArgs e)=>this.Close();

        private void EliminarPractica(object sender, RoutedEventArgs e)
        {

        }

        private void ModificarPractica(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarPractica(object sender, RoutedEventArgs e)
        {
            AgregarPracticaPorIngreso agregar = new AgregarPracticaPorIngreso();
            agregar.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
