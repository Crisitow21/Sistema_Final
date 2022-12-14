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
using Proyecto_Final.Resources.PL;

namespace Proyecto_Final
{
    public partial class Form1 : Form
    {
        LOGINDAL LoginDAL;


        public Form1()
        {
            LoginDAL = new LOGINDAL();
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
            conexion.CadenaConexion = "Data Source=DESKTOP-O0AP5KU\\MSSQLSERVER01; Initial Catalog=FACTURACIONPOLLOS; Integrated Security = True";

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

            if (LoginDAL.InicioSesion(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("El usuario ha sido encontrado");
                Resources.PL.Menu frm = new Resources.PL.Menu();
                frm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("El usuario no ha sido encontrado");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                MessageBox.Show("El usuario ha sido encontrado");
                Resources.PL.Menu frm = new Resources.PL.Menu();
                frm.Show();
                Hide();
            }
        }
    }
}
