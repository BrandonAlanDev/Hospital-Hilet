using MaquetaParaFinal.View.Agregar;
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
    public partial class Medicos : Page
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private void DataGridMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridMedicos.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridMedicos.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtMatricula.Text = row["Matricula"].ToString();
                txtServicio.Text = row["Servicio"].ToString();
                btModificar.IsEnabled = true;
                btEliminar.IsEnabled = true;
                btnImprimirMedicos.IsEnabled = true;
            }
            else
            {
                btModificar.IsEnabled = false;
                btEliminar.IsEnabled = false;
                btnImprimirMedicos.IsEnabled = false;
            }
        }
    }
}
