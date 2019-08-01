using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection cn=new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-2DSLLMKU\\SQLEXPRESS;Initial Catalog=Buses_Boletos;Integrated Security=True;";
            return cn;
        }
    }
}
