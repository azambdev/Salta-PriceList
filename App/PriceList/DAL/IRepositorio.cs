using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepositorio
    {

         DataTable GetAll();

        void Create(string codigo, int idCategoria, string descripcion, bool activo, byte[] imagen);

    }
}
