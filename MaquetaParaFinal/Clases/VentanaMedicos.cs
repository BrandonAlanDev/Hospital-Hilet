using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;

namespace MaquetaParaFinal.View
{
    public partial class Medicos : Page
    {
        Conectar conectar = new Conectar();

        private void DataGridMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            try{
                DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            }catch{}
        }

        private void DataGridMedicos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (txtBuscar.Text.Length >0) 
            { 
                if (e.Key == Key.Enter)
                {
                    DataGridMedicos.ItemsSource = conectar.BuscarEnTablaProfesionales(txtBuscar.Text).DefaultView;
                }
            }else DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                DataGridMedicos.ItemsSource = conectar.BuscarEnTablaProfesionales(txtBuscar.Text).DefaultView;
            }else DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarMedico agregarMedico = new AgregarMedico();
            agregarMedico.ShowDialog();
            DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }
        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView) DataGridMedicos.SelectedItem;
            ModificarMedicos modificarMedico = new ModificarMedicos(int.Parse(row["ID"].ToString()),txtNombre.Text,txtApellido.Text,txtMatricula.Text,txtServicio.Text);
            modificarMedico.ShowDialog();
            DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
        }
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "Nombre")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar a {txtNombre.Text} {txtApellido.Text}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
                    conectar.EliminarProfesional(int.Parse(row["ID"].ToString()));
                    DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
                }
            }
        }

    }
}