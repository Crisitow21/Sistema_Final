using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Resources.DAL;
using Proyecto_Final.Resources.BLL;

namespace Proyecto_Final
{
    public partial class Form1 : Form
    {
        LOGINDAL LoginDAL = new LOGINDAL();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("hh:mm:ss");
            label5.Text = DateTime.Now.ToLongDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            CONEXIONBDD conexion = new CONEXIONBDD();
            conexion.CadenaConexion = "Data Source=ISP_LAB1_PC10; Initial Catalog=SESION; Integrated Security = True";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TIENES QUE INGRESAR TU USUARIO Y CONTRASEÑA");
        }
        
        private LOGINBLL Recuperarinfo()
        {
            LOGINBLL LoginBLL = new LOGINBLL();
            LoginBLL.Usuario = textBox1.Text;
            LoginBLL.Clave = textBox2.Text;
            return LoginBLL;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Recuperarinfo();
            DataSet datosinicio;
            datosinicio = LoginDAL.InicioSesion(Recuperarinfo());
            if (datosinicio != null)
            {
                MessageBox.Show("usuario o contraseña incorrectos");
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
                Hide();
            }
        }
    }
}
