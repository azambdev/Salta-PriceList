using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceList
{
    public partial class FormNuevaListaPrecios : Form
    {
      

        public FormNuevaListaPrecios()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void FormNuevaListaPrecios_Load(object sender, EventArgs e)
        {
            //BindingSource source 
              BLogic.Producto producto = new BLogic.Producto();
              List<BLogic.Producto> productos = producto.GetProductos();
            dataGridViewProductosNoAsignados.DataSource = null;
            dataGridViewProductosNoAsignados.DataSource = productos.Select(p => new {V= p.Codigo(), V1= p.Descripcion() }).ToList();


        }
    }
}
