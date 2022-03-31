using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace PED104_Proyecto_de_catedra___Grafos
{
    class Conexion
    {
        SqlConnection SqlCon;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;


        public void Open()
        {
            try
            {
                SqlCon = new SqlConnection("Data Source=DESKTOP-KJSRL4B\\SQLEXPRESS;Initial Catalog=ProyectoPED;Integrated Security=True");
                SqlCon.Open();

                MessageBox.Show("Conexion Abierta");
            }
            catch (Exception)
            {

            }
        }

        public void Close()
        {
            SqlCon.Close();

            MessageBox.Show("Conexion Cerrada");
        }
        public string Cadena()
        {
            
            return SqlCon.ConnectionString;
        }
    }

}
