using MaquetaParaFinal.Clases;
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

namespace MaquetaParaFinal.View
{
    public partial class Medicos : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            }catch{}
        }
        private void DataGridMedicos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}