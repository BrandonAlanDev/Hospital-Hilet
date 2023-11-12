using MaquetaParaFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View.Modificar
{
    public partial class BajaPractica : Window
    {
        public BajaPractica(int id,string practica)
        {
            InitializeComponent();
            this.id = id;
            this.practica = practica;
            CargarPracticas();
        }       
    }
}
