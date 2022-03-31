using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Conexion con = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void Conexion_Click(object sender, EventArgs e)
        {
            con.Open();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La cadena de conexion es: " + con.Cadena());
        }
    }
}
