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
        void CargarEnBoxEspecilidad() 
        {
            DataTable dtespecialidad = conectar.DescargaTablaEspecialidades();
            // Crear una lista para almacenar los datos
            List<string> data = new List<string>();

            foreach (DataRow row in dtespecialidad.Rows)
            {
                data.Add(row["Especialidad"].ToString());
            }

            // Asignar los datos al ComboBox
            txtEspecialidad.ItemsSource = data;
        }

        void CargarEnBoxTipoDeMuestra()
        {
            DataTable dtesmuestra = conectar.DescargaTablaTiposDeMuestra();
            // Crear una lista para almacenar los datos
            List<string> data = new List<string>();

            foreach (DataRow row in dtesmuestra.Rows)
            {
                data.Add(row["Tipo de Muestra"].ToString());
            }

            // Asignar los datos al ComboBox
            txtTipoDeMuestra.ItemsSource = data;
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            try{
                CargarEnBoxEspecilidad();
                CargarEnBoxTipoDeMuestra();
            }catch{ }
        }
    }
}
