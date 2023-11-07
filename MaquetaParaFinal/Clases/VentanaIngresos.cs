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
using System.Windows.Input;

namespace MaquetaParaFinal.View
{
    public partial class Ingresos : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridIngresos_Loaded(object sender, RoutedEventArgs e)
        {
            try{
                DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
            } catch{}
        }

        private void DataGridIngresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridIngresos.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridIngresos.SelectedItem;
                txtPaciente.Text = row["Paciente"].ToString();
                txtDni.Text = row["Dni"].ToString();
                txtMedico.Text = row["Medico"].ToString();
                txtFecha_Ingreso.Text = row["Fecha De Ingreso"].ToString();
                if (row["Fecha De Retiro"].ToString() != string.Empty)
                {
                    txtFecha_Retiro.Text = row["Fecha De Retiro"].ToString();
                }
                else txtFecha_Retiro.Text = "Fecha De Retiro";

                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
                btnImprimirPaciente.IsEnabled = true;
            }
            else
            {
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
                btnImprimirPaciente.IsEnabled = false;
            }
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarIngreso agregarIngreso = new AgregarIngreso();
            agregarIngreso.ShowDialog();
            DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }

        private void DataGridIngresos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                if (e.Key == Key.Enter)
                {
                    DataGridIngresos.ItemsSource = conectar.BuscarEnTablaIngresos(txtBuscar.Text).DefaultView;
                }
            }else DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }

        private void btPracticas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnImprimirPaciente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
