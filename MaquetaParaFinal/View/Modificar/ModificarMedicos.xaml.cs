using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para ModificarMedicos.xaml
    /// </summary>
    public partial class ModificarMedicos : Window
    {
        string MatriculaInicial;
        int idmedico;
        public ModificarMedicos(int id,string nombre, string apellido, string matricula, string servicios)
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtMatricula.GotFocus += LimpiarTxt;
            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtMatricula.LostFocus += RestaurarNombrePorDefecto;
            CargarServicios();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtMatricula.Text = matricula;
            txtServicio.Text = servicios;
            MatriculaInicial = matricula;
            idmedico = id;
        }
    }
}
