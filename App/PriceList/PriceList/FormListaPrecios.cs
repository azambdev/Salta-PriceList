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
                        dropDownCategorias.Items.Add(/*item.Codigo() + " - " +*/ item.Descripcion());
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
                dropDownCategorias.Items.Add("Todas");
                dropDownCategorias.SelectedItem = "Todas";
                BloquearFiltros();
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

                if (gridViewProductosAsociados.SelectedCells.Count == 0)
                {

                    return;
                }

                BLogic.Producto productoSeleccionado = new BLogic.Producto(CodigoProductoSeleccionado());

                BLogic.ListaDePrecio listaPrecioSeleccionada = _listaDePreciosExistentes.Find(x => x.Descripcion().ToString() == dropDownListaDePrecios.SelectedItem.ToString());

                BLogic.ListaDePreciosProductos listaPrecioProductoSeleccionada = new BLogic.ListaDePreciosProductos(0, listaPrecioSeleccionada, productoSeleccionado, decimal.Parse(CostoproductoSeleccionado()), int.Parse(PorcentajeAplicarProductoSeleccionado().ToString()), decimal.Parse(AlicuotaIvaProductoSeleccionado()), decimal.Parse(PrecioVentaFinalProductoSeleccionado()), DateTime.Now);
                listaPrecioProductoSeleccionada.Update();

                BLogic.ListaDePreciosProductos listaDePreciosProductos = new BLogic.ListaDePreciosProductos();
                List<BLogic.ListaDePreciosProductos> listasDePreciosProductos = listaDePreciosProductos.GetAll();
                _listasDePreciosProductos = listasDePreciosProductos;
                gridViewProductosAsociados.DataSource = null;

                if (dropDownCategorias.SelectedItem.ToString()=="Todas")
                {
                    gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();

                }
                else
                {
                    gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString() && x.Producto().Categoria().Descripcion()==dropDownCategorias.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();

                }


                LimpiarCamposPrecios();

                MessageBox.Show("Lista de precios actualizada correctamente", "Validación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }

        private string PrecioVentaFinalProductoSeleccionado()
        {
            return txtprecioVentaFinalProductoSeleccionado.Text.Trim();
        }

        private string AlicuotaIvaProductoSeleccionado()
        {
            return txtAlicuotaIvaProductoSeleccionado.Text.Trim();
        }

        private decimal PorcentajeAplicarProductoSeleccionado()
        {
            return porcentajeAplicarProductoSeleccionado.Value;
        }

        private string CostoproductoSeleccionado()
        {
            return txtCostoProductoSeleccionado.Text.Trim();
        }

        private string CodigoProductoSeleccionado()
        {
            return txtCodigoProductoSeleccionado.Text.Trim();
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
                txtAlicuotaIvaProductoSeleccionado.Text = alicuotaIva.ToString();
                decimal precioFinal = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[6].Value.ToString());
                txtprecioVentaFinalProductoSeleccionado.Text = precioFinal.ToString();
                txtDescripcionProducto.Text= gridViewProductosAsociados.Rows[rowindex].Cells[1].Value.ToString();
                txtFechaActualizacion.Text= gridViewProductosAsociados.Rows[rowindex].Cells[7].Value.ToString();
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void dropDownListaDePrecios_SelectedIndexChanged(object sender, EventArgs e)
        {

            gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
            lblCantidadproductos.Text = gridViewProductosAsociados.Rows.Count.ToString();
            dropDownCategorias.SelectedItem = "Todas";
            LimpiarCamposPrecios();
            DesbloquearFiltros();

        }

        private void LimpiarCamposPrecios()
        {
            txtCodigoProductoSeleccionado.Clear();
            txtCostoProductoSeleccionado.Clear();
            txtCostoProductoSeleccionado.Text = "0";
            porcentajeAplicarProductoSeleccionado.Value = 0;
            txtAlicuotaIvaProductoSeleccionado.Text = "0";
            txtprecioVentaFinalProductoSeleccionado.Text = "0";
            
            txtDescripcionProducto.Clear();
            txtFechaActualizacion.Clear();
            gridViewProductosAsociados.ClearSelection();


        }

        private void BloquearFiltros()
        {
            dropDownCategorias.Enabled = false;
            txtFiltroCodigoProducto.ReadOnly = true;
            txtFiltroDescripcopnProducto.ReadOnly = true;

        }
        private void DesbloquearFiltros()
        {
            dropDownCategorias.Enabled = true;
            txtFiltroCodigoProducto.ReadOnly = false;
            txtFiltroDescripcopnProducto.ReadOnly = false;

        }


        private void gridViewProductosAsociados_SelectionChanged(object sender, EventArgs e)
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
                string descripcionDeProducto =  gridViewProductosAsociados.Rows[rowindex].Cells[1].Value.ToString();
                txtDescripcionProducto.Text = descripcionDeProducto;
                decimal costoDeProducto = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[3].Value.ToString());
                txtCostoProductoSeleccionado.Text = costoDeProducto.ToString();
                int porcentajeGanancia = int.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[4].Value.ToString());
                porcentajeAplicarProductoSeleccionado.Value = porcentajeGanancia;
                decimal alicuotaIva = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[5].Value.ToString());
                txtAlicuotaIvaProductoSeleccionado.Text = alicuotaIva.ToString();
                decimal precioFinal = decimal.Parse(gridViewProductosAsociados.Rows[rowindex].Cells[6].Value.ToString());
                txtprecioVentaFinalProductoSeleccionado.Text = precioFinal.ToString();
                txtFechaActualizacion.Text= gridViewProductosAsociados.Rows[rowindex].Cells[7].Value.ToString();

               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //numericUpDown1.Text = numericUpDown1.Text.Replace(',', '.');
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.Handled = e.KeyChar == '.';
            }
        }

        private void txtCostoProductoSeleccionado_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioFinal();
        }

        private void CalcularPrecioFinal()
        {

            try
            {

                decimal precioFinalCalculado = 0;
                decimal costoDelProducto = 0;
                if (txtCostoProductoSeleccionado.Text != "")
                {
                    costoDelProducto = decimal.Parse(txtCostoProductoSeleccionado.Text);
                }

                decimal ivaDelProducto = decimal.Parse(txtAlicuotaIvaProductoSeleccionado.Text);
                decimal porcentajeAgregado = decimal.Parse(porcentajeAplicarProductoSeleccionado.Value.ToString());

                decimal precioConIva = (costoDelProducto * ivaDelProducto) / 100 + costoDelProducto;
                precioFinalCalculado = (precioConIva * porcentajeAgregado) / 100 + precioConIva;

                txtprecioVentaFinalProductoSeleccionado.Text = precioFinalCalculado.ToString("#.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void porcentajeAplicarProductoSeleccionado_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecioFinal();
        }

        private void txtAlicuotaIvaProductoSeleccionado_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioFinal();
        }

        private void porcentajeAplicarProductoSeleccionado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }

        private void txtAlicuotaIvaProductoSeleccionado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string result = "";
            //char[] validChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }; // these are ok
            //foreach (char c in txtAlicuotaIvaProductoSeleccionado.Text) // check each character in the user's input
            //{
            //    if (Array.IndexOf(validChars, c) != -1)
            //    {
            //        result += c; // if this is ok, then add it to the result
            //    }
            //    else
            //    {
            //        txtAlicuotaIvaProductoSeleccionado.Text = result; // change the text to the "clean" version where illegal chars have been removed.

            //    }


            //}



            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }

        private void dropDownCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{


            //txtFiltroDescripcopnProducto.Text="";
            //txtFiltroCodigoProducto.Text = "";
            //if (dropDownListaDePrecios.SelectedIndex==-1)
            //{
            //        return;
            //}

            //    ComboBox comboBox = sender as ComboBox;
            ////    if (_listasDePreciosProductos!=null && comboBox.SelectedItem.ToString()  != "")
            ////{

            //gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString() &&  x.Producto().Categoria().Descripcion() == dropDownCategorias.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal() }).ToList();
            ////}
            //LimpiarCamposPrecios();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dropDownCategorias.SelectedIndex = -1;
            if (gridViewProductosAsociados.Rows.Count == 0)
            {
                LimpiarCamposPrecios();
                return;
            }

            if (txtFiltroCodigoProducto.Text.Length == 0)
            {
                gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal() }).ToList();
                lblCantidadproductos.Text = gridViewProductosAsociados.Rows.Count.ToString();
                dropDownCategorias.SelectedIndex = -1;
                LimpiarCamposPrecios();
            }

            gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString() && x.Producto().Codigo().ToUpper().Contains(txtFiltroCodigoProducto.Text.ToUpper())).OrderBy(x => x.Producto().Codigo()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal() }).ToList();




        }

        private void txtFiltroDescripcopnProducto_TextChanged(object sender, EventArgs e)
        {

            dropDownCategorias.SelectedIndex = -1;
            txtFiltroCodigoProducto.Clear();
            if (gridViewProductosAsociados.Rows.Count == 0)
            {
                LimpiarCamposPrecios();
                return;
            }

            if (txtFiltroDescripcopnProducto.Text.Length == 0)
            {
                gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                lblCantidadproductos.Text = gridViewProductosAsociados.Rows.Count.ToString();
                dropDownCategorias.SelectedIndex = -1;
                LimpiarCamposPrecios();
            }

            gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString() && x.Producto().Descripcion().ToUpper().Contains(txtFiltroDescripcopnProducto.Text.ToUpper())).OrderBy(x => x.Producto().Codigo()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();



        }

        private void dropDownCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (dropDownCategorias.SelectedItem.ToString() == "Todas")
                {

                    gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).OrderBy(x => x.Producto().Codigo()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                    return;
                }



                txtFiltroDescripcopnProducto.Text = "";
                txtFiltroCodigoProducto.Text = "";
                if (dropDownListaDePrecios.SelectedIndex == -1)
                {
                    return;
                }

                ComboBox comboBox = sender as ComboBox;
                if (_listasDePreciosProductos != null && dropDownCategorias.SelectedItem != null)
                {

                    gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString() && x.Producto().Categoria().Descripcion() == dropDownCategorias.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                }
                LimpiarCamposPrecios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
