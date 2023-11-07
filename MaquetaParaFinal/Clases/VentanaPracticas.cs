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
                    //conectar.EliminarPractica(int.Parse(row["ID"].ToString())); PARA CUANDO ESTE EL METODO
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
            DataGridPracticas.ItemsSource = conectar.BuscarEnTablaPracticas(txtBuscar.Text).DefaultView;
        }

    }
}
