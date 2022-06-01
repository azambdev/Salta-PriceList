using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    public class ListaDePrecio
    {

        private int _id;
        private string _descripcion;
        private bool _activo;
        private int _porcentaje;
        private List<Producto> _productos;


        public ListaDePrecio()
        {

        }

        public int Id()
        {
            return this._id;
        }

        public string Descripcion()
        {
            return this._descripcion;
        }

        public int Porcentaje()
        {
            return this._porcentaje;
        }

        public ListaDePrecio(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
           
        }

        public ListaDePrecio(int id, string descripcion, bool activo)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;
        }

        public ListaDePrecio(int id, string descripcion, bool activo, int porcentaje)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;
            this._porcentaje = porcentaje;
        }


        public ListaDePrecio(int id, string descripcion, bool activo, List<Producto> productos )
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;
            this._productos = productos;            
        }


        public List<ListaDePrecio> GetAll()
        {

            ListaDePrecio listaDePrecio = new ListaDePrecio();
            List<ListaDePrecio> listasDePrecioExistentes = new List<ListaDePrecio>();

            DAL.RepositorioDeListasDePrecios repo = new DAL.RepositorioDeListasDePrecios();
         
            DataTable table = repo.GetAll();
                    

            foreach (DataRow row in table.Rows)
            {
                bool esActivo = false;
                if (row["activo"].ToString() == "1")
                {
                    esActivo = true;
                }

                listasDePrecioExistentes.Add(new ListaDePrecio(int.Parse(row["id"].ToString()), row["Descripcion"].ToString(), esActivo, int.Parse(row["porcentaje"].ToString())));
            }
            return listasDePrecioExistentes;
        }


        public List<ListaDePrecio> GetAllConProductos()
        {

            ListaDePrecio listaDePrecio = new ListaDePrecio();
            List<ListaDePrecio> listasDePrecioExistentes = new List<ListaDePrecio>();

            DAL.RepositorioDeListasDePrecios repo = new DAL.RepositorioDeListasDePrecios();

            DataTable table = repo.GetAllConProductos();


            foreach (DataRow row in table.Rows)
            {
                bool esActivo = false;
                if (row["activo"].ToString() == "1")
                {
                    esActivo = true;
                }

                listasDePrecioExistentes.Add(new ListaDePrecio(int.Parse(row["id"].ToString()), row["Descripcion"].ToString(), esActivo, int.Parse(row["porcentaje"].ToString())));
            }
            return listasDePrecioExistentes;
        }


        public void Create()
        {
            try
            {
                DAL.RepositorioDeListasDePrecios repositorioDeListasDePrecios = new DAL.RepositorioDeListasDePrecios();
                repositorioDeListasDePrecios.Create(this.Descripcion(), this.Porcentaje());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
