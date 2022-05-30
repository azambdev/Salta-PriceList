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
    public partial class FormListaPrecios : Form
    {
        List<BLogic.ListaDePreciosProductos> _listasDePreciosProductos = new List<BLogic.ListaDePreciosProductos>();
        public FormListaPrecios()
        {
            InitializeComponent();
        }

        private List<BLogic.ListaDePrecio> _listaDePreciosExistentes = new List<BLogic.ListaDePrecio>();

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FormNuevaListaPrecios"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FormNuevaListaPrecios"].Activate();
            }
            else
            {
                FormNuevaListaPrecios frmLista = new FormNuevaListaPrecios(this);
                // frm.MdiParent = this;
                // frm.Dock = DockStyle.;
                frmLista.ShowDialog();

            }
        }


        public void ActualizarListadoDeListas()
        {
            dropDownListaDePrecios.Items.Clear();
            BLogic.ListaDePrecio listadePrecios = new BLogic.ListaDePrecio();
            _listaDePreciosExistentes = null;
            _listaDePreciosExistentes = listadePrecios.GetAll();

            if (_listaDePreciosExistentes.Any())
            {
                foreach (var item in _listaDePreciosExistentes)
                {
                    dropDownListaDePrecios.Items.Add(item.Descripcion());
                }
                dropDownListaDePrecios.SelectedIndex = -1;
            }
        }


        private void FormListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {

                ActualizarListadoDeListas();

                BLogic.Categoria categoria = new BLogic.Categoria();
                List<BLogic.Categoria> listaCategorias = categoria.GetCategorias();

                if (listaCategorias.Any())
                {
                    foreach (var item in listaCategorias)
                    {
                        dropDownCategorias.Items.Add(item.Codigo() + " - " + item.Descripcion());
                    }
                    dropDownCategorias.SelectedIndex = 0;
                }
                BLogic.ListaDePreciosProductos listaDePreciosProductos = new BLogic.ListaDePreciosProductos();
                List<BLogic.ListaDePreciosProductos> listasDePreciosProductos = listaDePreciosProductos.GetAll();
                _listasDePreciosProductos = listasDePreciosProductos;

                //if (listasDePreciosProductos.Any())
                //{
                //    gridViewProductosAsociados.DataSource = listasDePreciosProductos.Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal() }).ToList();
                //    //  gridViewProductosAsociados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    //  gridViewProductosAsociados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //}

                LimpiarCamposPrecios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {

                if (gridViewProductosAsociados.Rows.Count == 0)
                {
                    return;
                }

                if (gridViewProductosAsociados.SelectedRows.Count == 0)
                {
                    
                        return;                    
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }

        private void gridViewProductosAsociados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gridViewProductosAsociados.Rows.Count == 0)
                {
                    return;
                }
                int rowindex = gridViewProductosAsociados.CurrentCell.RowIndex;
                int columnindex = gridViewProductosAsociados.CurrentCell.ColumnIndex;
                string codigoDeProducto = gridViewProductosAsociados.Rows[rowindex].Cells[0].Value.ToString();
                txtCodigoProductoSeleccionado.Text = codigoDeProducto;
                decimal costoDeProducto = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[3].Value.ToString());
                txtCostoProductoSeleccionado.Text = costoDeProducto.ToString();
                int porcentajeGanancia = int.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[4].Value.ToString());
                porcentajeAplicarProductoSeleccionado.Value = porcentajeGanancia;
                decimal alicuotaIva = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[5].Value.ToString());
                AlicuotaIvaProductoSeleccionado.Text = alicuotaIva.ToString();
                decimal precioFinal = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[6].Value.ToString());
                precioVentaFinalProductoSeleccionado.Text = precioFinal.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void dropDownListaDePrecios_SelectedIndexChanged(object sender, EventArgs e)
        {

                      gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x =>x.ListaDePrecio().Descripcion()== dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal() }).ToList();

            LimpiarCamposPrecios();

        }

        private void LimpiarCamposPrecios()
        {
            txtCodigoProductoSeleccionado.Clear();
            txtCostoProductoSeleccionado.Clear();
            porcentajeAplicarProductoSeleccionado.Value = 0;
            AlicuotaIvaProductoSeleccionado.Text = "0";
            precioVentaFinalProductoSeleccionado.Text = "0";
            gridViewProductosAsociados.ClearSelection();

        }
    }
}
