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
    public partial class FormImpresionListaPrecios : Form
    {
        public FormImpresionListaPrecios()
        {
            InitializeComponent();
        }

        List<BLogic.ListaDePreciosProductos> _listasDePreciosProductos = new List<BLogic.ListaDePreciosProductos>();
        List<BLogic.Producto> _productos = new List<BLogic.Producto>();
        private List<BLogic.ListaDePrecio> _listaDePreciosExistentes = new List<BLogic.ListaDePrecio>();
        private List<BLogic.HistoricoListaDePrecios> _listaDePreciosHistoricas = new List<BLogic.HistoricoListaDePrecios>();
   
        private void FormImpresionListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {



                dropDownListaDePrecios.Items.Clear();
                dropDownListaDePrecios.Items.Add("Todas");
                BLogic.ListaDePrecio listadePrecios = new BLogic.ListaDePrecio();
                _listaDePreciosExistentes = null;
                _listaDePreciosExistentes = listadePrecios.GetAll();
                dropDownListaDePrecios.SelectedItem = "Todas";


                if (_listaDePreciosExistentes.Any())
                {
                    foreach (var item in _listaDePreciosExistentes)
                    {
                        dropDownListaDePrecios.Items.Add(item.Descripcion());
                    }
                    dropDownListaDePrecios.SelectedValue = "Todas";
                }




                BLogic.HistoricoListaDePrecios listadePreciosHistoricasExistentes = new BLogic.HistoricoListaDePrecios();
                _listaDePreciosHistoricas = null;
                _listaDePreciosHistoricas = listadePreciosHistoricasExistentes.GetAll();



                gridViewProductosAsociados.DataSource = null;

                //if (dropDownCategorias.SelectedItem.ToString() == "Todas")
                //{
                //    gridViewProductosAsociados.DataSource = _listasDePreciosProductos.FindAll(x => x.ListaDePrecio().Descripcion() == dropDownListaDePrecios.SelectedItem.ToString()).Select(p => new { Código = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Costo = p.PrecioCosto(), Porcentaje = p.Porcentaje(), AlicuotaIva = p.AlicuotaIva(), PrecioVentaFinal = p.PrecioVentaFinal(), FechaActualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();

                //}
                //else

                gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();


                this.gridViewProductosAsociados.RowsDefaultCellStyle.BackColor = Color.Bisque;
                this.gridViewProductosAsociados.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                gridViewProductosAsociados.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dropDownListaDePrecios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownListaDePrecios.SelectedItem.ToString() == "Todas")
                {
                    gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                    return;
                }
               
                    gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.FindAll(x => x.ListaDePrecio().Descripcion().ToUpper() == dropDownListaDePrecios.SelectedItem.ToString().ToUpper()).Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                    return;
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

        }

        private void txtFiltroCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtFiltroCodigoProducto.Text.Length == 0)
                {
                    if (dropDownListaDePrecios.SelectedItem.ToString() == "Todas")
                    {
                        gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                        return;
                    }
                    else
                    {
                        gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.FindAll(x => x.ListaDePrecio().Descripcion().ToUpper() == dropDownListaDePrecios.SelectedItem.ToString().ToUpper()).Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                        return;
                    }
                }
                else
                {

                    if (dropDownListaDePrecios.SelectedItem.ToString() == "Todas")
                    {
                        gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.FindAll(x=> x.Producto().Codigo().ToUpper().Contains(txtFiltroCodigoProducto.Text.ToUpper())).Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                        return;
                    }
                    if (dropDownListaDePrecios.SelectedItem.ToString() != "Todas")
                    {
                        gridViewProductosAsociados.DataSource = _listaDePreciosHistoricas.FindAll(x => x.ListaDePrecio().Descripcion().ToUpper() == dropDownListaDePrecios.SelectedItem.ToString().ToUpper() && x.Producto().Codigo().ToUpper().Contains(txtFiltroCodigoProducto.Text.ToUpper())).Select(p => new { Fecha_Consulta = DateTime.Now.ToShortDateString(), Lista_de_Precios = p.ListaDePrecio().Descripcion(), Categoría = p.Producto().Categoria().Descripcion(), Código_Producto = p.Producto().Codigo(), Descripción = p.Producto().Descripcion(), Vigencia = p.Vigencia(), Costo = "$ " + p.PrecioCosto().ToString(), Porcentaje = p.Porcentaje(), Alicuota_Iva = p.AlicuotaIva() + "%", PrecioVentaFinal = "$ " + p.PrecioVentaFinal(), Fecha_Actualizacion = p.FechaActualizacion().ToShortDateString() }).ToList();
                        return;
                    }


                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (gridViewProductosAsociados.Rows.Count > 0)
            {              
                Microsoft.Office.Interop.Excel.ApplicationClass XcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < gridViewProductosAsociados.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = gridViewProductosAsociados.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < gridViewProductosAsociados.Rows.Count; i++)
                {
                    for (int j = 0; j < gridViewProductosAsociados.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = gridViewProductosAsociados.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }


        }
    }
}
