using MaquetaParaFinal.Clases;
using MaquetaParaFinal.Clases.Ventanas;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace MaquetaParaFinal.View
{
    public partial class Ingresos : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridIngresos_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
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
                txtCantidad.Text = row["Practicas"].ToString();
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
                btPxI.IsEnabled = true;
            }
            else
            {
                btPxI.IsEnabled = false;
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
        }

        private void DataGridIngresos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataGridIngresos.ItemsSource = conectar.BuscarEnTablaIngresos(txtBuscar.Text).DefaultView;
            }else DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                if (e.Key == Key.Enter)
                {
                    DataGridIngresos.ItemsSource = conectar.BuscarEnTablaIngresos(txtBuscar.Text).DefaultView;
                }
            }else DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }

        private void btPracticas_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView) DataGridIngresos.SelectedItem;
            int id = int.Parse(row["ID"].ToString());
            VentanaPracticaPorIngreso vtn = new VentanaPracticaPorIngreso(id);
            vtn.ShowDialog();
            DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
            DataGridIngresos.SelectedValue = id;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarIngreso agregarIngreso = new AgregarIngreso();
            agregarIngreso.ShowDialog();
            DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridIngresos.SelectedItem;
                int id = int.Parse(row["ID"].ToString());
                ModificarIngreso mi = new ModificarIngreso(id, row["Dni"].ToString(), row["Medico"].ToString());
                mi.ShowDialog();
                DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
                DataGridIngresos.SelectedValue= id;
            }
            catch { }
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el Ingreso de {txtPaciente.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                DataRowView row = (DataRowView)DataGridIngresos.SelectedItem;
                conectar.EliminarIngresos(int.Parse(row["ID"].ToString()));
                DataGridIngresos.ItemsSource = conectar.DescargarTablaIngresos().DefaultView;
            }
        }

        private void btnImprimirPaciente_Click(object sender, RoutedEventArgs e)
        {
            Impresora impresora = new Impresora();
            impresora.ImprimirDocumento();
        }
    }
}
