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

        private readonly Dictionary<string, string> medicos = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Matrícula", "txtMatricula" }
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
        private void RestaurarNombrePorDefecto(object sender, RoutedEventArgs e) // Para cuando se pierde el focus y queda vacio
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = medicos.FirstOrDefault(pair => pair.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }

    }
}
