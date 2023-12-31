﻿using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace MaquetaParaFinal.View.Agregar
{
    public partial class AgregarMedico : Window
    {
        Conectar conectar = new Conectar();

        public AgregarMedico()
        {
            InitializeComponent();
            txtNombre.GotFocus += LimpiarTxt;
            txtApellido.GotFocus += LimpiarTxt;
            txtMatricula.GotFocus += LimpiarTxt;
            txtNombre.LostFocus += RestaurarNombrePorDefecto;
            txtApellido.LostFocus += RestaurarNombrePorDefecto;
            txtMatricula.LostFocus += RestaurarNombrePorDefecto;
            CargarServicios();
        }

        public string medico { get; set; }

        private readonly Dictionary<string, string> Dicmedicos = new Dictionary<string, string> //Seria la forma de hacerlo una const, con el readonly.
        {
            { "Nombre", "txtNombre" }, //txtNombre es el nombre del textbox.
            { "Apellido", "txtApellido" },
            { "Matricula", "txtMatricula" }
        };

        private void LimpiarTxt(object sender, RoutedEventArgs e) // Uso el diccionario para no tener que hacer mil metodos para borrarlo, se tiene que usar como evento en el main.
        {
            if (sender is TextBox textBox)
            {
                if (Dicmedicos.ContainsKey(textBox.Text))
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
                    textBox.Text = Dicmedicos.FirstOrDefault(nom => nom.Value == textBox.Name).Key; // Busca el nombre del campo en el diccionario
                }
            }
        }
        private void txtServicio_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CargarServicios();
            } catch { }
        }
        private void Principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnCancelarAgPaciente_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnAceptarAgPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (TodosLosCamposLlenos())
            {
                int idServicio = conectar.ObtenerId_Servicios(txtServicio.Text);
                medico = txtApellido.Text + " " + txtNombre.Text;
                conectar.AgregarProfesionales(txtNombre.Text, txtApellido.Text, int.Parse(txtMatricula.Text), idServicio);
                MessageBox.Show("Se agrego el medico correctamente");
                this.Close();
            }
            else   MessageBox.Show("Planilla Incompleta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void CargarServicios()
        {
            DataTable dtServicio = conectar.DescargarTablaServicios();
            List<string> data = new List<string>();

            foreach (DataRow row in dtServicio.Rows)
            {
                data.Add(row["Servicio"].ToString());
            }
            txtServicio.ItemsSource = null;
            txtServicio.Items.Clear();
            txtServicio.ItemsSource = data;
        }

        private bool TodosLosCamposLlenos()
        {
            return txtNombre.Text != "Nombre" &&
                   txtApellido.Text != "Apellido" &&
                   txtMatricula.Text != "Matricula" &&
                   txtServicio != null;
        }

        private void btnAgregarServicio_Click(object sender, RoutedEventArgs e)
        {
            AgregarServicio agregarServicio = new AgregarServicio();
            agregarServicio.ShowDialog();
            CargarServicios();
        }

        private void ControlarNombre(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            string regEx = @"^[A-Za-zÁ-Úá-ú ']{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20))
            {
                textBox.Text = Regex.Replace(input, @"[^A-Za-zÁ-Úá-ú ']", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0); 
            }
        }

        private void SoloNumero(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            string regEx = @"^[0-9]{1,20}$";

            if (!(Regex.IsMatch(input, regEx) && input.Length <= 20) && input != "Matricula") 
            {
                textBox.Text = Regex.Replace(input, @"[^0-9]", "");
                textBox.Text = textBox.Text.Substring(0, Math.Min(20, textBox.Text.Length));
                textBox.Select(textBox.Text.Length, 0); 
            }
        }

    }
}
