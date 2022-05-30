using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    public class ListaDePreciosProductos
    {

        private int _id;
        private BLogic.ListaDePrecio _listadePrecios = new BLogic.ListaDePrecio();
        private BLogic.Producto _producto;
        private decimal _precioCosto;
        private int _porcentaje;
        private decimal _alicuotaIva;
        private decimal _precioVentaFinal;
        private DateTime _fechaActualizacion;


        public Producto Producto()
        {
            return this._producto;
        }

        public decimal PrecioCosto()
        {
            return this._precioCosto;
        }

        public decimal Porcentaje()
        {
            return this._porcentaje;
        }
        public decimal AlicuotaIva()
        {
            return this._alicuotaIva;
        }
        public decimal PrecioVentaFinal()
        {
            return this._precioVentaFinal;
        }
        public DateTime FechaActualizacion()
        {
            return this._fechaActualizacion;
        }

        public ListaDePreciosProductos(int id, ListaDePrecio listadePrecios, Producto producto, decimal precioCosto, int porcentaje, decimal alicuotaIva, decimal precioVentaFinal, DateTime fechaActualizacion)
        {
            _id = id;
            _listadePrecios = listadePrecios;
            _producto = producto;
            _precioCosto = precioCosto;
            _porcentaje = porcentaje;
            _alicuotaIva = alicuotaIva;
            _precioVentaFinal = precioVentaFinal;
            _fechaActualizacion = fechaActualizacion;
        }

        public ListaDePreciosProductos()
        {

        }


        public List<ListaDePreciosProductos> GetAll()
        {

            List<ListaDePreciosProductos> listaDePreciosProductosExistentes = new List<ListaDePreciosProductos>();

            DAL.RepositorioDeListasDePrecios repo = new DAL.RepositorioDeListasDePrecios();

            DataTable table = repo.GetAllConProductos();

            foreach (DataRow row in table.Rows)
            {
                ListaDePrecio listaDePrecio = new ListaDePrecio(int.Parse(row["idListaPrecio"].ToString()), row["ListaPrecioDescripcion"].ToString(), true, int.Parse(row["PorcentajeListaPrecios"].ToString()));
                Categoria categoria = new Categoria(int.Parse(row["idCategoria"].ToString()), row["CodigoCategoria"].ToString(), row["DescripcionCategoria"].ToString(),true);
                Producto producto = new Producto(int.Parse(row["idProducto"].ToString()), row["CodigoProducto"].ToString(),categoria, row["DescripcionProducto"].ToString(),true,null);
                
                
                listaDePreciosProductosExistentes.Add(new ListaDePreciosProductos(int.Parse(row["idListaPreciosProductos"].ToString()), listaDePrecio, producto, decimal.Parse(row["precioCosto"].ToString()), int.Parse(row["porcentaje"].ToString()), decimal.Parse(row["alicuotaIva"].ToString()), decimal.Parse(row["precioVentaFinal"].ToString()), DateTime.Parse(row["fechaActualizacion"].ToString())));
            }
            return listaDePreciosProductosExistentes;
        }

        public ListaDePrecio ListaDePrecio()
        {
            return this._listadePrecios;
        }


    }
}
