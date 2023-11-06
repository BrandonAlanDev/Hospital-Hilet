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

namespace MaquetaParaFinal.View.Agregar
{
    /// <summary>
    /// Lógica de interacción para AgregarIngreso.xaml
    /// </summary>
    public partial class AgregarIngreso : Window
    {
        public AgregarIngreso()
        {
            InitializeComponent();
        }

        private void txtMedico_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = conectar.DescargaTablaProfesinales();
            List<string> data = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row["Apellido"].ToString()+ row[" "].ToString()+ row["Nombre"].ToString());
            }
            txtMedico.ItemsSource = null;
            txtMedico.Items.Clear();
            txtMedico.ItemsSource = data;
        }

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedico.SelectedValue != null && txtDni.Text != "DNI")
            {
                //int idpaciente 
            }else MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
        }
    }
}
