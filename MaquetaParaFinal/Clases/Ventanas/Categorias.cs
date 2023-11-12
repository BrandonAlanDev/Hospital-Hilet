﻿using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View
{
    public partial class Categorias : Page
    {
        Conectar conectar = new Conectar();

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridCategoria.SelectedItem;
            MessageBoxResult resultado = MessageBox.Show($"¿Seguro que Desea Eliminar la Categoria {txtNombre.Text}?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                int id = int.Parse(row["ID"].ToString());
                conectar.EliminarCategorias(id);
                txtNombre.Text = "Nombre";
                DataGridCategoria.ItemsSource = conectar.DescargarTablaEspecialidades().DefaultView;
            }
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridCategoria.SelectedItem;
            ModificarCategoria mc = new ModificarCategoria();
            int id = int.Parse(row["ID"].ToString());
            mc.id = id;
            mc.txtNombreCategoria.Text = row["Categoria"].ToString();
            mc.ShowDialog();
            DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
            DataGridCategoria.SelectedValue = id;
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarCategorias ac = new AgregarCategorias();
            ac.ShowDialog();
            DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
        }

        private void DataGridCategoria_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscar.Focus();
            try {
                DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
            } catch { }
        }

        private void DataGridCategoria_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridCategoria.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridCategoria.SelectedItem;
                txtNombre.Text = row["Categoria"].ToString();
                btAgregar.IsEnabled = true;
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
            }
            else
            {
                btAgregar.IsEnabled = false;
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
            }
        }

        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                if (e.Key == Key.Enter)
                {
                    DataGridCategoria.ItemsSource = conectar.BuscarEnTablaCategorias(txtBuscar.Text).DefaultView;
                }
            } else DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
        }

        private void ClickBuscar(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataGridCategoria.ItemsSource = conectar.BuscarEnTablaCategorias(txtBuscar.Text).DefaultView;
            }
            else DataGridCategoria.ItemsSource = conectar.DescargaTablaCategorias().DefaultView;
        }
    }
}