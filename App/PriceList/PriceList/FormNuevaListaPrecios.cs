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

        private List<BLogic.Producto> _productos;
        private List<BLogic.Producto> _productosAsignados = new List<BLogic.Producto>();
        private List<BLogic.Producto> _productosNoAsignados = new List<BLogic.Producto>();

        public FormNuevaListaPrecios()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void FormNuevaListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {

           
            //BindingSource source 
              BLogic.Producto producto = new BLogic.Producto();
              List<BLogic.Producto> productos = producto.GetProductos();
                productos = productos.ToList().OrderBy(o => o.Codigo()).ToList();
                _productos = productos;
            dataGridViewProductosNoAsignados.DataSource = null;
            dataGridViewProductosNoAsignados.DataSource = productos.Select(p => new {Código= p.Codigo(), Descripción= p.Descripcion() }).ToList();

            dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductosNoAsignados.Rows.Count==0)
            {
                return;
            }
            _productosAsignados=new List<BLogic.Producto>();
            _productosAsignados.AddRange(_productos);
            _productosNoAsignados = null;



            dataGridViewProductosNoAsignados.DataSource = null;
            //dataGridViewProductosNoAsignados.DataSource = productos.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewProductosAsignados.DataSource = null;
            dataGridViewProductosAsignados.DataSource = _productosAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            dataGridViewProductosAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductosAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductosNoAsignados.Rows.Count == 0)
            {
                return;
            }




        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductosAsignados.Rows.Count == 0)
            {
                return;
            }




        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductosAsignados.Rows.Count == 0)
            {
                return;
            }
            _productosNoAsignados = new List<BLogic.Producto>();
            _productosNoAsignados.AddRange(_productosAsignados);
            _productosAsignados = null;


            dataGridViewProductosNoAsignados.DataSource = null;
            dataGridViewProductosNoAsignados.DataSource = _productosNoAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewProductosAsignados.DataSource = null;
            //dataGridViewProductosAsignados.DataSource = _productosAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            dataGridViewProductosAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductosAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


        }
    }
}
