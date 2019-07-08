using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;	
using System.Data;

namespace CapaDatos
{
   public  class accesoDatosCompra_boleto
    {
        SqlConnection cnx;
        Compra_boleto  cob= new Compra_boleto();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Compra_boleto> lista_compra_boleto = null;

        

        public int insertarCompra_boleto(Compra_boleto cb)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("compraboleto", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@Idboleto", "");
                cm.Parameters.AddWithValue("@Nmero_asiento", cb.Nmero_asiento);
                cm.Parameters.AddWithValue("@Precio", cb.Precio);
                cm.Parameters.AddWithValue("@Fecha", cb.Fecha);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }

            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }

        public List<Compra_boleto> listarCompra_boleto()
{
try
{
SqlConnection cnx=cn.conectar();
cm=new SqlCommand("compraboleto", cnx);
cm.Parameters.AddWithValue("@b", 3);
cm.Parameters.AddWithValue("@Idboleto", "");
cm.Parameters.AddWithValue("@Nmero_asiento", "");
cm.Parameters.AddWithValue("@Precio", "");
cm.Parameters.AddWithValue("@Fecha", "");

cm.CommandType= CommandType.StoredProcedure;
cnx.Open();
dr=cm.ExecuteReader();
lista_compra_boleto=new List<Compra_boleto>();
while (dr.Read())
{
Compra_boleto cob=new Compra_boleto();
cob.Idboleto=Convert.ToInt32(dr["idboleto"].ToString());
cob.Nmero_asiento=Convert.ToInt32(dr["nmero_asiento"].ToString());
cob.Precio=Convert.ToInt32(dr["precio"].ToString());
cob.Fecha=Convert.ToDateTime(dr["fecha"]);
lista_compra_boleto.Add(cob);
}
}
catch(Exception e)
{
e.Message.ToString();
lista_compra_boleto=null;
}
finally
{
cm.Connection.Close();
}
return lista_compra_boleto;

}

public int EliminarCompra_boleto(int idbolet)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("compraboleto", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@Idboleto", idbolet);
                cm.Parameters.AddWithValue("@Nmero_asiento", "");
                cm.Parameters.AddWithValue("@Precio", "");
                cm.Parameters.AddWithValue("@Fecha", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;

        }

        public int EditarCompra_boleto(Compra_boleto cb)
        {
            try
            {

                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("compraboleto", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@Idboleto", cb.Idboleto);
                cm.Parameters.AddWithValue("@Nmero_asiento", "");
                cm.Parameters.AddWithValue("@precio", "");
                cm.Parameters.AddWithValue("@fecha", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;

        }

        public List<Compra_boleto> BuscarCompra_boleto(string dato)
{
try
{
SqlConnection cnx= cn.conectar();
cm= new SqlCommand("compraboleto");
cm.Parameters.AddWithValue("@b", 5);
cm.Parameters.AddWithValue("@Idcompraboleto", "");
cm.Parameters.AddWithValue("@Nmero_asiento", "");
cm.Parameters.AddWithValue("@Precio", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
dr=cm.ExecuteReader();
lista_compra_boleto= new List<Compra_boleto>();
while(dr.Read())
{
Compra_boleto cob= new Compra_boleto();
cob.Idboleto= Convert.ToInt32(dr["idboleto"].ToString());
cob.Nmero_asiento= Convert.ToInt32(dr["nmero_asiento"].ToString());
cob.Precio= Convert.ToInt32(dr["precio"].ToString());
cob.Fecha=Convert.ToDateTime(dr["fecha"]);
lista_compra_boleto.Add(cob);
}
}

catch (Exception e)
{
e.Message.ToString();
lista_compra_boleto=null;
}
finally
{
    cm.Connection.Close();
}
return lista_compra_boleto;


}
    }

   
}
}

        
