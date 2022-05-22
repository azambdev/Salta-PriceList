using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    public class Categoria
    {

        private int _id;
        private string _descripcion;
        private bool _activo;


        public string Descripcion()
        { return this._descripcion; }

        public int Id()
        { return this._id; }

        public bool Activo()
        { return this._activo; }

        public Categoria(int id, string descripcion, bool activo)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;

        }

        public Categoria()
        {

        }

        public List<Categoria> GetCategorias()
        {
          DAL.RepositorioDeCategorias repo = new DAL.RepositorioDeCategorias();
          List<Categoria> categorias = new List<Categoria>();
          DataTable table=  repo.GetCategoriasDeProductos();

            foreach (DataRow row in table.Rows)
            {
                bool esActivo = false;
                if (row["activo"].ToString() == "1")
                {
                    esActivo = true;
                }

                categorias.Add(new Categoria(int.Parse(row["id"].ToString()), row["descripcion"].ToString(), esActivo));
            }
            return categorias;
        }


    }
}
