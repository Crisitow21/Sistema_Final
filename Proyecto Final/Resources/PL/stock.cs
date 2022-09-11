using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final.Resources.BLL;
using Proyecto_Final.Resources.DAL;

namespace Proyecto_Final.Resources.PL
{
    public partial class stock : Form
    {
        STOCKDAL oStockDal;
        public stock()
        {
            oStockDal = new STOCKDAL();
            InitializeComponent();
            dataGridView1.DataSource = oStockDal.mostrarStock().Tables[0];
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            txtCodigo.Text = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.Rows[indice].Cells[1].Value.ToString();
            txtPrecio.Text = dataGridView1.Rows[indice].Cells[2].Value.ToString();
            txtStock.Text = dataGridView1.Rows[indice].Cells[3].Value.ToString();

        }

        private void stock_Load(object sender, EventArgs e)
        {
            
        }

        private STOCKBLL RecuperarInformacion()
        {
            STOCKBLL oDepartamentoBLL = new STOCKBLL();
            int COD = 0; int.TryParse(txtCodigo.Text, out COD);
            oDepartamentoBLL.Cod_pro = COD;
            oDepartamentoBLL.Nombre = txtNombre.Text;
            //oDepartamentoBLL.Precio = (float)Convert.ToDouble(txtPrecio.Text);
            //oDepartamentoBLL.Stock = (float)Convert.ToDouble(txtStock.Text);
            return oDepartamentoBLL;

        }

        public void busqueda()
        {
            try
            {
                txtNombre.Text = oStockDal.BuscarNombre(txtCodigo.Text);
                txtPrecio.Text = Convert.ToString(oStockDal.BuscarPrecio(txtCodigo.Text));
                txtStock.Text = Convert.ToString(oStockDal.BuscarStock(txtCodigo.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("ARTICULO NO ENCONTRADO");
                limpiar();
            }
            
        }

        public void limpiar()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                busqueda();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            txtCodigo.Focus();
        }
    }
}
