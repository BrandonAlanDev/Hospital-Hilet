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
    /// <summary>
    /// Interaction logic for BajaPractica.xaml
    /// </summary>
    public partial class BajaPractica : Window
    {
        Conectar conectar = new Conectar();
        public BajaPractica()
        {
            InitializeComponent();
            CargarPracticas();
        }

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnCancelarAgServicio_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptarAgServicio_Click(object sender, RoutedEventArgs e)
        {
            if (txtPractica.Text != null) //TO-DO /////////////////////////////////////////////////////////////////////////////////////////////////////
            this.Close();
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
        }
    }
}
