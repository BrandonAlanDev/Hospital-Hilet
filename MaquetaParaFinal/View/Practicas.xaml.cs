using MaquetaParaFinal.View.Agregar;
using MaquetaParaFinal.View.Modificar;
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
    /// Lógica de interacción para Practicas.xaml
    /// </summary>
    public partial class Practicas : Page
    {
        public Practicas()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPractica agregarPractica = new AgregarPractica();
            agregarPractica.ShowDialog();
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            BajaPractica bp = new BajaPractica();
            bp.ShowDialog();
        }
    }
}
