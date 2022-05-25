using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    public class Producto
    {
        private int _id;
        private string _codigo;
        private Categoria _categoria;
        private string _descripcion;
        private bool _activo;
        private Byte[] _imagen;
           

        public Producto()
        {

        }

        public Producto(int id, string codigo, Categoria categoria, string descripcion, bool activo, byte[] imagen)
        {
            _id = id;
            _codigo = codigo;
            _categoria = categoria;
            _descripcion = descripcion;
            _activo = activo;
            _imagen = imagen;
        }

        public int Id()
        {
            return this._id;
        }

        public string Codigo()
        {
            return this._codigo;
        }
        public string Descripcion()
        {
            return this._descripcion;
        }
        public bool Activo()
        {
            return this._activo;
        }

        public byte[] Imagen()
        {
            return this._imagen;
        }

        public Categoria Categoria()
        {
            return this._categoria;
        }

        public List<Producto> GetProductos()
        {

            Categoria categoria = new Categoria();
            List<Categoria> categorias = categoria.GetCategorias();

            DAL.RepositorioDeProductos repo = new DAL.RepositorioDeProductos();
            List<Producto> productos = new List<Producto>();
            DataTable table = repo.GetAll();

            Encoding unicode = Encoding.Unicode;

            foreach (DataRow row in table.Rows)
            {
                bool esActivo = false;
                if (row["activo"].ToString() == "1")
                {
                    esActivo = true;
                }
                Categoria categoriaDeProducto = categorias.Find(x => x.Id() == int.Parse(row["IdCategoria"].ToString()));


                productos.Add(new Producto(int.Parse(row["id"].ToString()), row["codigo"].ToString(), categoriaDeProducto, row["Descripcion"].ToString(), esActivo, unicode.GetBytes(row["Imagen"].ToString())));
            }
            return productos;
        }

        public void Create()
        {
            try
            {
                DAL.RepositorioDeProductos repositorioDeProductos = new DAL.RepositorioDeProductos();
                repositorioDeProductos.Create(this.Codigo(), this.Categoria().Id(), this.Descripcion(), this.Activo(), this.Imagen());
            }
            catch (Exception ex)
            {

                throw ex;
            }
          


        }



    }
}
