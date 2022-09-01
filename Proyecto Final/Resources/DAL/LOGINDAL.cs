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
        public bool InicioSesion(LOGINBLL LoginBLL)
        {
            SqlCommand SQLComado = new SqlCommand("SELECT * FROM USUARIO WHERE USUARIO = @USU AND CLAVE = @CLAVE");
            SQLComado.Parameters.Add("@USU", SqlDbType.VarChar).Value = LoginBLL.Usuario;
            SQLComado.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = LoginBLL.Clave;
            return conexion.Ejecutarcomando(SQLComado);
        }
    }
}
