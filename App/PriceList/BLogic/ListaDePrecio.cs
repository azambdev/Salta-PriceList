using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    internal class ListaDePrecio
    {

        private int _id;
        private string _descripcion;
        private bool _activo;
        private List<Producto> _productos;


        public ListaDePrecio()
        {

        }

        public ListaDePrecio(int id, string descripcion, bool activo)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;
        }
        public ListaDePrecio(int id, string descripcion, bool activo, List<Producto> productos )
        {
            this._id = id;
            this._descripcion = descripcion;
            this._activo = activo;
            this._productos = productos;            
        }

    }
}
