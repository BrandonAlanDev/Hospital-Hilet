using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarIngreso : Window
    {
        Conectar conectar = new Conectar();

        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
