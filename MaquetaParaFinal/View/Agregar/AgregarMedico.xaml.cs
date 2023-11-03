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
    /// Lógica de interacción para AgregarMedico.xaml
    /// </summary>
    public partial class AgregarMedico : Window
    {
        public AgregarMedico()
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtMatricula.GotFocus += LimpiarTxt;
            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtMatricula.LostFocus += RestaurarNombrePorDefecto;
        }

        private void txtServicio_Loaded(object sender, RoutedEventArgs e)
        {
            try{
                CargarServicio();
            }catch { }
        }
    }
}
