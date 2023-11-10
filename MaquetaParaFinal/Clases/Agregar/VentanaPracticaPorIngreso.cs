using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class VentanaPracticaPorIngreso : Window
    {
        private void ActualizarPracticas(int id)
        {
            try { ActualizarFechaRetiro(); } catch { }
            DataGridPracticasxIngreso.ItemsSource = conectar.DescargarPracticaDeUnIngreso(id).DefaultView;
        }
        private void ActualizarFechaRetiro()
        {
            int horasDemora = conectar.BuscarTiempoDemora(idIngreso);
            DateTime fecha = DateTime.Now.AddHours(horasDemora);
            string fechaRetiro = $"{fecha.Year}-{fecha.Month}-{fecha.Day}";
            conectar.ActualizarFecha_Retiro(idIngreso, fechaRetiro);
        }

        private void Salir(object sender, RoutedEventArgs e) => this.Close();

        private void EliminarPractica(object sender, RoutedEventArgs e) => ActualizarPracticas(idIngreso);

        private void ModificarPractica(object sender, RoutedEventArgs e) => ActualizarPracticas(idIngreso);

        private void AgregarPractica(object sender, RoutedEventArgs e)
        {
            AgregarPracticaPorIngreso agregar = new AgregarPracticaPorIngreso(idIngreso);
            agregar.ShowDialog();
            ActualizarPracticas(idIngreso);
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
