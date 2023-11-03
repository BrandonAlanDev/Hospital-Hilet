using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaquetaParaFinal.View
{
    public partial class Practicas : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridPacticas_Loaded(object sender, RoutedEventArgs e)
        {
            try { 
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            } catch { }
        }
        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPractica agregarPractica = new AgregarPractica();
            agregarPractica.ShowDialog();
            try{
                DataGridPracticas.ItemsSource = conectar.DescargarTablaPracticas().DefaultView;
            }catch { }
        }
    }
}
