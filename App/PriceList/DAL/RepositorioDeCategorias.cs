using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class RepositorioDeCategorias
    {

        public DataTable GetCategoriasDeProductos()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetCategorias", con))
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
    }
}
