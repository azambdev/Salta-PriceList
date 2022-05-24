using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioDeProductos : IRepositorio
    {
        public DataTable GetAll()
        {

            try
            {



                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetProductos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@CustId", customerId);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Create(string codigo, int idCategoria, string descripcion, bool activo, byte[] imagen )
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("CreateProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Activo", activo);
                        cmd.Parameters.AddWithValue("@Imagen", imagen);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
