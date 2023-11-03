using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Data;
using MaquetaParaFinal.Clases;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarPractica : Window
    {
        Conectar conectar = new Conectar();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtNombrePractica_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombrePractica.Text == "Nombre")
            {
                txtNombrePractica.Text = "";
            }
        }

        private void txtNombrePractica_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombrePractica.Text == "")
            {
                txtNombrePractica.Text = "Nombre";
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dtespecialidad = 
        }
    }
}
