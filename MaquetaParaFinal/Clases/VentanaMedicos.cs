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

        private readonly Dictionary<string, bool> medicos = new Dictionary<string, bool> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", true },
            { "Apellido", true },
            { "Matrícula", true }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e) // Uso el diccionario para no tener que hacer mil metodos para borrarlo, se tiene que usar como evento en el main.
        {
            if (sender is TextBox textBox)
            {

                if (medicos.ContainsKey(textBox.Text))
                {
                    textBox.Clear();
                }
            }
        }
    }
}
