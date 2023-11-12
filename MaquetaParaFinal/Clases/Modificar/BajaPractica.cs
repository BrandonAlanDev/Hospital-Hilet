using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View.Modificar
{
    public partial class BajaPractica : Window
    {
        Conectar conectar = new Conectar();
        int id;
        string practica;
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnCancelarBrPractica_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptarBrPractica_Click(object sender, RoutedEventArgs e)
        {
            if (txtPractica.Text != null) 
            {
                id = conectar.ObtenerId_Categorias();
                if () 
                { 
                    conectar.EliminarPracticas(id);
                    this.Close();    
                }
            }
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
            txtPractica.SelectedValue = practica;
        }
    }
}
