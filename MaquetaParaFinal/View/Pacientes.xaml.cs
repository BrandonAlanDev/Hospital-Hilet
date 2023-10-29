using MaquetaParaFinal.Clases;
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
    /// <summary>
    /// Lógica de interacción para Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        public Pacientes()
        {
            InitializeComponent();
        }
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                // Aquí va el código para eliminar el elemento
            }
        }
    }
}
