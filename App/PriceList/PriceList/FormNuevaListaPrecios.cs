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
        private FormListaPrecios _formprincipal;
        private List<BLogic.ListaDePrecio> _listaDePreciosExistentes = new List<BLogic.ListaDePrecio>();
       
        public FormNuevaListaPrecios (FormListaPrecios formprincipal)
        {
            InitializeComponent();
            _formprincipal = formprincipal;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtDescripcionLista.Text.Length < 5)
            {
                MessageBox.Show("Debe completar la descripción de la lista. Mínimo 5 caracteres", "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_listaDePreciosExistentes.Any(x=> x.Descripcion().Trim().ToUpper()== txtDescripcionLista.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Ya existe una lista de precios con esa descripcion", "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {                          

            BLogic.ListaDePrecio listaNueva = new BLogic.ListaDePrecio(0,txtDescripcionLista.Text.Trim(), true, int.Parse(porcentajeAplicar.Value.ToString()));
            listaNueva.Create();

            MessageBox.Show("Lista de Precios Creada Correctamente", "Validación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcionLista.Clear();
                porcentajeAplicar.Value = 0;
                _formprincipal.ActualizarListadoDeListas();
            return;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FormNuevaListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {              
                               
                BLogic.ListaDePrecio listadePrecios = new BLogic.ListaDePrecio();
                _listaDePreciosExistentes = listadePrecios.GetAll();
                
                //dataGridViewProductosNoAsignados.DataSource = null;
                //dataGridViewProductosNoAsignados.DataSource = productos.Select(p => new {Código= p.Codigo(), Descripción= p.Descripcion() }).ToList();

                //dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

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
            //_productosAsignados=new List<BLogic.Producto>();
            //_productosAsignados.AddRange(_productos);
            //_productosNoAsignados = null;



            //dataGridViewProductosNoAsignados.DataSource = null;
            ////dataGridViewProductosNoAsignados.DataSource = productos.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            //dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //dataGridViewProductosAsignados.DataSource = null;
            //dataGridViewProductosAsignados.DataSource = _productosAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            //dataGridViewProductosAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewProductosAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


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
            //_productosNoAsignados = new List<BLogic.Producto>();
            //_productosNoAsignados.AddRange(_productosAsignados);
            //_productosAsignados = null;


            //dataGridViewProductosNoAsignados.DataSource = null;
            //dataGridViewProductosNoAsignados.DataSource = _productosNoAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            //dataGridViewProductosNoAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewProductosNoAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //dataGridViewProductosAsignados.DataSource = null;
            ////dataGridViewProductosAsignados.DataSource = _productosAsignados.Select(p => new { Código = p.Codigo(), Descripción = p.Descripcion() }).ToList();

            //dataGridViewProductosAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewProductosAsignados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


        }
    }
}
