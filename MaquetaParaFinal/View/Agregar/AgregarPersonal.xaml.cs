using System;
using System.Collections.Generic;
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
    /// Interaction logic for AgregarPersonal.xaml
    /// </summary>
    public partial class AgregarPersonal : Window
    {
        public AgregarPersonal()
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtDni.GotFocus += LimpiarTxt;

            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtDni.LostFocus += RestaurarNombrePorDefecto;
        }
    }
}
