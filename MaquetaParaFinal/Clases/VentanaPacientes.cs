﻿using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Pacientes : Page 
    {
        Conectar conectar = new Conectar();

        private readonly Dictionary<string, string> Dicpacientes = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Dni", "txtDni" },
            { "Email", "txtEmail" },
            { "Fecha De Nacimiento", "txtFecha_De_Nacimiento" },
            { "Telefono", "txtTelefono" },
            { "Calle", "txtCalle" },
            { "Nro", "txtNro" },
            { "Localidad", "txtLocalidad" },
            { "Codigo Postal", "txtCodPostas" },
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
                    textBox.Text = Dicpacientes.FirstOrDefault(pair => pair.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void DataGridPacientes_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridPacientes.ItemsSource = conectar.DescargaTablaPaciente().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxes.IsEnabled = true;
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxes.IsEnabled = false;
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            //GARGAR LOCALIDAD Y EXTRAER LA FK
            // conectar.AgregarPaciente(txtNombre,txtApellido,txtFecha_De_Nacimiento,txtDni,txtEmail,txtTelefono,txtCalle,txtNro,txtPiso,"SinHacer");
        }
    }
}
