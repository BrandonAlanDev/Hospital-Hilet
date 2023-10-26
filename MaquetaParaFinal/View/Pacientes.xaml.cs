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
    /// <summary>
    /// Lógica de interacción para Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        public Pacientes()
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtDni.GotFocus += LimpiarTxt;
            txtEmail.GotFocus += LimpiarTxt;
            txtFecha_De_Nacimiento.GotFocus += LimpiarTxt;
            txtTelefono.GotFocus += LimpiarTxt;
            txtNro.GotFocus += LimpiarTxt;
            txtPiso.GotFocus += LimpiarTxt;
            txtCalle.GotFocus += LimpiarTxt;
            txtLocalidad.GotFocus += LimpiarTxt;
            txtCodPostas.GotFocus += LimpiarTxt;
            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtDni.LostFocus += RestaurarNombrePorDefecto;
            txtEmail.LostFocus += RestaurarNombrePorDefecto;
            txtFecha_De_Nacimiento.LostFocus += RestaurarNombrePorDefecto;
            txtTelefono.LostFocus += RestaurarNombrePorDefecto;
            txtNro.LostFocus += RestaurarNombrePorDefecto;
            txtPiso.LostFocus += RestaurarNombrePorDefecto;
            txtCalle.LostFocus += RestaurarNombrePorDefecto;
            txtLocalidad.LostFocus += RestaurarNombrePorDefecto;
            txtCodPostas.LostFocus += RestaurarNombrePorDefecto;
        }

        private void DataGridPacientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID") 
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        
    }
}
