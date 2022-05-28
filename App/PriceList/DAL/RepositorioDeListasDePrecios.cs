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
    public class RepositorioDeListasDePrecios 
    {

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetListaPrecios", con))
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

        public void Create(string descripcion, int porcentaje)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("CreateListaDePrecios", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inDescripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Inporcentaje", porcentaje);                     
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


        public void Update(string codigo, int idCategoria, string descripcion, bool activo, byte[] imagen)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UpdateProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inCodigo", codigo);
                        cmd.Parameters.AddWithValue("@inIdCategoria", idCategoria);
                        cmd.Parameters.AddWithValue("@inDescripcion", descripcion);
                        cmd.Parameters.AddWithValue("@inActivo", activo);
                        cmd.Parameters.AddWithValue("@inImagen", imagen);
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

        public DataTable GetAllConProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetListaPreciosProductos", con))
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


    }
}
