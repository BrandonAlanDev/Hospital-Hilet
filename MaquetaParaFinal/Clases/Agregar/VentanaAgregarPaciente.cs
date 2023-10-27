using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarPaciente : Window
    {
        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Dni", "txtDni" },
            { "Email", "txtEmail" },
            { "Fecha De Nacimiento", "txtFecha_De_Nacimiento" },
            { "Teléfono", "txtTelefono" },
            { "Calle", "txtCalle" },
            { "Nro", "txtNro" },
            { "Piso", "txtPiso" }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e) // Uso el diccionario para no tener que hacer mil metodos para borrarlo, se tiene que usar como evento en el main.
        {
            if (sender is TextBox textBox)
            {
                if (Dicpacientes.ContainsKey(textBox.Text))
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
                    textBox.Text = Dicpacientes.FirstOrDefault(nom => nom.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos()) 
            {
                if (txtEmail.Text == "Email") txtEmail.Text = "";
                if (txtTelefono.Text == "Teléfono") txtTelefono.Text = "";
                conectar.AgregarPaciente(txtNombre.Text, txtApellido.Text, txtFecha_De_Nacimiento.Text, txtDni.Text, txtEmail.Text, txtTelefono.Text, txtCalle.Text, txtNro.Text, txtPiso.Text, 0);
                MessageBox.Show("Agregado Correctamente");
                this.Close();
            }
            MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private bool TodosLosCamposLlenos() //Era muy largo el if si no :c
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtFecha_De_Nacimiento.Text != "Fecha De Nacimiento" &&
                   txtDni.Text != "Dni" &&
                   txtCalle.Text != "Calle" &&
                   txtNro.Text != "Nro" &&
                   txtPiso.Text != "Piso";
        }
    }
}
