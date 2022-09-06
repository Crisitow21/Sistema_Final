using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final.Resources.BLL;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Final.Resources.DAL
{
    class LOGINDAL
    {
        CONEXIONBDD conexion;
        public LOGINDAL()
        {
            conexion = new CONEXIONBDD();
        }
        static string CadenaConexion = "Data Source=DESKTOP-O0AP5KU\\MSSQLSERVER01; Initial Catalog=FACTURACIONPOLLOS; Integrated Security = True";
        SqlConnection Conexion = new SqlConnection(CadenaConexion);
        public int InicioSesion(string usuario, string clave)
        {
            int count;
            Conexion.Open();
            string sente = "SELECT Count(*) FROM USUARIO WHERE USUARIO = '" + usuario + "' AND CLAVE = '" + clave + "'";
            SqlCommand cmd = new SqlCommand(sente, Conexion);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            Conexion.Close(); 
            return count;
        }
    }
}
