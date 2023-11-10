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
    public partial class Practicas : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridPacticas_Loaded(object sender, RoutedEventArgs e)
        {
            try { 
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            } catch { }
        }

        private void DataGridPracticas_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPractica agregarPractica = new AgregarPractica();
            agregarPractica.ShowDialog();
            try{
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            }catch { }
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar la practica {txtNombre.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)DataGridPracticas.SelectedItem;
                    conectar.EliminarPracticas(int.Parse(row["ID"].ToString()));
                    DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
                }
            }
        }

        private void DataGridPracticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPracticas.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridPracticas.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtEspecialidades.Text = row["Especialidades"].ToString();
                txtTiempo_Demora.Text = row["Tiempo De Demora"].ToString();
                txtTipo_De_Muestra.Text = row["Tipo De Muestra"].ToString();
                if (row["Tiempo De Demora"].ToString() == string.Empty) txtTiempo_Demora.Text = "Fecha"; 
            }
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                if (e.Key == Key.Enter)
                {
                    DataGridPracticas.ItemsSource = conectar.BuscarEnTablaPracticas(txtBuscar.Text).DefaultView;
                }
            }else DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                DataGridPracticas.ItemsSource = conectar.BuscarEnTablaPracticas(txtBuscar.Text).DefaultView;
            }else DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
        }

    }
}
