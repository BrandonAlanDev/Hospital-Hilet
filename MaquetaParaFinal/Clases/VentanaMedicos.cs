using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Medicos : Page
    {
        public event EventHandler VolverClicked;
        private void VolverMenu_Click(object sender, RoutedEventArgs e)
        {
            Principal.Visibility = Visibility.Collapsed;
            VolverClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
