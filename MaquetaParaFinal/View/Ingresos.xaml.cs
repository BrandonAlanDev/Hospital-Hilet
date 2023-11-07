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
    public partial class Ingresos : Page
    {
        public Ingresos()
        {
            InitializeComponent();
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
                if(row["Fecha De Retiro"].ToString() != string.Empty) txtFecha_Retiro.Text = row["Fecha De Retiro"].ToString();

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
    }
}
