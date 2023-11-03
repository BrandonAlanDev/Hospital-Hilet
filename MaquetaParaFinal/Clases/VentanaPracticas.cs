using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Practicas : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridPacticas_Loaded(object sender, RoutedEventArgs e)
        {
            try { 
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            } catch { }
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPractica agregarPractica = new AgregarPractica();
            agregarPractica.ShowDialog();
            try{
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            }catch { }
        }

        private void DataGridPracticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPracticas.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridPracticas.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtEspecialidades.Text = row["Especialidades"].ToString();
                txtTipo_De_Muestra.Text = row["Tipo De Muestra"].ToString();
                txtFecha_De_Realizacion.Text = row["Fecha De Realizacion"].ToString();
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
                btnImprimirPacticas.IsEnabled = true;
            }
            else
            {
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
                btnImprimirPacticas.IsEnabled = false;
            }
        }

    }
}
