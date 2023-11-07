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
    public partial class AgregarPracticaPorIngreso : Window
    {
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnCancelarAgServicio_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptarAgServicio_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CargarPracticas()
        {
            DataTable dtPractica = conectar.DescargarTablaPracticas();
            List<string> data = new List<string>();

            foreach (DataRow row in dtPractica.Rows)
            {
                data.Add(row["Nombre"].ToString());
            }
            txtPractica.ItemsSource = null;
            txtPractica.Items.Clear();
            txtPractica.ItemsSource = data;
        }
    }
}
