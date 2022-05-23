using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    internal class Producto
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
    }
}
