using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    public class HistoricoListaDePrecios
    {

        private int _id;
        private BLogic.ListaDePrecio _listadePrecios = new BLogic.ListaDePrecio();
        private BLogic.Producto _producto;
        private string _vigencia;
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

        public string Vigencia()
        {
            return this._vigencia;
        }


        public BLogic.ListaDePrecio ListaDePrecio()
        {
            return _listadePrecios;
        }

        public HistoricoListaDePrecios(int id, ListaDePrecio listadePrecios, Producto producto, string vigencia, decimal precioCosto, int porcentaje, decimal alicuotaIva, decimal precioVentaFinal, DateTime fechaActualizacion)
        {
            _id = id;
            _listadePrecios = listadePrecios;
            _producto = producto;
            _vigencia = vigencia;
            _precioCosto = precioCosto;
            _porcentaje = porcentaje;
            _alicuotaIva = alicuotaIva;
            _precioVentaFinal = precioVentaFinal;
            _fechaActualizacion = fechaActualizacion;
        }

          


        public List<HistoricoListaDePrecios> GetAll()
        {
            List<HistoricoListaDePrecios> listaDePreciosHistoricos = new List<HistoricoListaDePrecios>();

            DAL.RepositorioDeHistoricoDeListaDePrecios repo = new DAL.RepositorioDeHistoricoDeListaDePrecios();

            DataTable table = repo.GetAll();

            foreach (DataRow row in table.Rows)
            {
                ListaDePrecio listaDePrecio = new ListaDePrecio(int.Parse(row["idListaPrecio"].ToString()), row["ListaPrecioDescripcion"].ToString(), true, int.Parse(row["PorcentajeListaPrecios"].ToString()));
                Categoria categoria = new Categoria(int.Parse(row["idCategoria"].ToString()), row["CodigoCategoria"].ToString(), row["DescripcionCategoria"].ToString(), true);
                Producto producto = new Producto(int.Parse(row["idProducto"].ToString()), row["CodigoProducto"].ToString(), categoria, row["DescripcionProducto"].ToString(), true, null);


                listaDePreciosHistoricos.Add(new HistoricoListaDePrecios(int.Parse(row["idListaPreciosProductos"].ToString()), listaDePrecio, producto, row["Vigencia"].ToString(), decimal.Parse(row["precioCosto"].ToString()), int.Parse(row["porcentaje"].ToString()), decimal.Parse(row["alicuotaIva"].ToString()), decimal.Parse(row["precioVentaFinal"].ToString()), DateTime.Parse(row["fechaActualizacion"].ToString())));
            }
            return listaDePreciosHistoricos;
        }


        public HistoricoListaDePrecios()
        {

        }


    }
}
