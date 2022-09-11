using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Resources.BLL;

namespace Proyecto_Final.Resources.DAL
{
    internal class STOCKDAL
    {
        CONEXIONBDD conexion;
        public STOCKDAL()
        {
            conexion = new CONEXIONBDD();
        }

        static string CadenaConexion = "Data Source=DESKTOP-O0AP5KU\\MSSQLSERVER01; Initial Catalog=FACTURACIONPOLLOS; Integrated Security = True";

        SqlConnection Conexion = new SqlConnection(CadenaConexion);

        public DataSet mostrarStock()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM PRODUCTO");
            return conexion.EjecutarSentecia(sentencia);
        }

        public string BuscarNombre(string codigo)
        {
            string count;
            Conexion.Open();
            string sente = "SELECT NOMBRE_PROD FROM PRODUCTO WHERE COD_PROD = " + codigo + " ";
            SqlCommand cmd = new SqlCommand(sente, Conexion);
            count = Convert.ToString(cmd.ExecuteScalar());
            Conexion.Close();
            return count;
        }

        public float BuscarPrecio(string codigo)
        {
            float count;
            Conexion.Open();
            string sente = "SELECT PRECIO FROM PRODUCTO WHERE COD_PROD = " + codigo + " ";
            SqlCommand cmd = new SqlCommand(sente, Conexion);
            count = (float)Convert.ToDecimal(cmd.ExecuteScalar());
            Conexion.Close();
            return count;
        }

        public float BuscarStock(string codigo)
        {
            float count;
            Conexion.Open();
            string sente = "SELECT STOCK FROM PRODUCTO WHERE COD_PROD = " + codigo + " ";
            SqlCommand cmd = new SqlCommand(sente, Conexion);
            count = (float)Convert.ToDecimal(cmd.ExecuteScalar());
            Conexion.Close();
            return count;
        }

    }
}
