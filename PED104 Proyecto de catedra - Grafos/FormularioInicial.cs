using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulación_de_ensamblaje_de_una_linea_de_automoviles
{
    public partial class FormularioInicial : Form
    {
        public FormularioInicial()
        {
            InitializeComponent();
        }

      
        private void BtmCerrar1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtmMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
