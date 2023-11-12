using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaquetaParaFinal
{
    public partial class MainWindow : Window
    {
        Conectar conectar = new Conectar();
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            if (conectar.ObtenerId_Categorias("Sin Categoría") == -1) conectar.AgregarSinCategoria();

            if (conectar.ObtenerId_Especialidades("Sin Especialidad") == -1) conectar.AgregarSinEspecialidad();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) //Navigación mediante Ctrl
        {
            if (e.Key == Key.D1 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadHome(sender, e);

            if (e.Key == Key.D2 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadIngresos(sender, e);

            if (e.Key == Key.D3 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadPacientes(sender, e);

            if (e.Key == Key.D4 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadPracticas(sender, e);

            if (e.Key == Key.D5 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadMedicos(sender, e);

            if (e.Key == Key.D6 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadPersonal(sender, e);

            if (e.Key == Key.D7 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadEspecialidad(sender, e);

            if (e.Key == Key.D8 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) LoadCategorias(sender, e);
        }

    }
}
