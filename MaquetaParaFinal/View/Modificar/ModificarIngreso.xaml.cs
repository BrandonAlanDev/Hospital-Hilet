using System;
using System.Collections.Generic;
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
    public partial class ModificarIngreso : Window
    {
        int ID;
        public ModificarIngreso(int idIngreso)
        {
            this.ID = idIngreso;
            InitializeComponent();

            // TO-DO PONER EL MEDICO Y EL DNI PRESELECCIONADO SEGUN EL id INGRESO seleccionado
        }
    }
}
