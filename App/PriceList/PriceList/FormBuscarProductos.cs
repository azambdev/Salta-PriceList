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
    public partial class FormBuscarProductos : Form
    {
        private FormProductos _formPadre;
        private List<BLogic.Categoria> _categorias;
        private List<BLogic.Producto> _productos;

        public FormBuscarProductos(List<BLogic.Categoria> categorias, List<BLogic.Producto> productos, FormProductos formPadre)
        {
            _categorias = categorias;
            _productos = productos;
            _formPadre = formPadre;
            InitializeComponent();
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            dataGridViewResultados.DataSource = null;
            txtCodigoProducto.Clear();
            dropDownCategorias.SelectedIndex = -1;



        }

        private void FormBuscarProductos_Load(object sender, EventArgs e)
        {
            foreach (var item in _categorias)
            {
                dropDownCategorias.Items.Add(item.Descripcion());
            }
            //dropDownCategorias.SelectedIndex = 0;
            dataGridViewResultados.DataSource = _productos.OrderBy(x=>x.Codigo()).Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion(), Categoría = p.Categoria().Descripcion() }).ToList();
            dataGridViewResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (dropDownCategorias.SelectedIndex == -1 && Descripcion().Length == 0 && CodigoProducto().Length == 0)
            {
                return;
            }

            try
            {

                List<BLogic.Producto> productosFiltrados = new List<BLogic.Producto>();

                if (dropDownCategorias.SelectedIndex >= 0)
                {
                    productosFiltrados.AddRange(_productos.FindAll(x => x.Categoria().Descripcion().Contains(dropDownCategorias.SelectedItem.ToString())));
                }

                if (CodigoProducto().Length>0)
                {
                    productosFiltrados.AddRange(_productos.FindAll(x => x.Codigo().ToUpper().Contains(CodigoProducto().ToUpper())));
                }

                if (Descripcion().Length>0)
                {
                    productosFiltrados.AddRange(_productos.FindAll(x => x.Descripcion().ToUpper().Contains(txtDescripcionProducto.Text.ToUpper())));
                }
                
                // var selected = _productos.Where(p => p.Descripcion().Any(a => p.Descripcion().Contains(txtDescripcionProducto.Text))).ToList();

                // productosFiltrados = _productos.FindAll(x=> x.Codigo().Contains(txtCodigoProducto.Text) || x.Descripcion().Contains(txtDescripcionProducto.Text) || x.Categoria().Descripcion().Contains(dropDownCategorias.SelectedItem.ToString())  ) ;
                dataGridViewResultados.DataSource = productosFiltrados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion(), Categoría = p.Categoria().Descripcion() }).ToList();
                dataGridViewResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;



                _formPadre.CargarProductoPorCodigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private string CodigoProducto()
        {
            return txtCodigoProducto.Text;
        }

        private string Descripcion()
        {
            return txtDescripcionProducto.Text;
        }

        private void dataGridViewResultados_DoubleClick(object sender, EventArgs e)
        {

            int rowindex = dataGridViewResultados.CurrentCell.RowIndex;
            int columnindex = dataGridViewResultados.CurrentCell.ColumnIndex;
            string codigoDeProducto = dataGridViewResultados.Rows[rowindex].Cells[0].Value.ToString();
            _formPadre.CargarProductoPorCodigo(codigoDeProducto);
            this.Close();

        }
      
    }
}
