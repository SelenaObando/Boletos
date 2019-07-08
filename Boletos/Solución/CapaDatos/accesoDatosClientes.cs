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
    public class accesoDatosClientes
    {
        SqlConnection cnx;
        Clientes c = new Clientes();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Clientes> listaClientes = null;

        public int insertarClientes(Clientes c)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("cliente", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@Idcliente", "");
                cm.Parameters.AddWithValue("@Nombres", c.Nombres);
                cm.Parameters.AddWithValue("@Apellidos", c.Apellidos);
                cm.Parameters.AddWithValue("@Cedula", c.Cedula);
                cm.Parameters.AddWithValue("@Telefono", c.Telefono);

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

public List<Clientes> listarClientes()
{
    try
    {
        SqlConnection cnx = cn.conectar();
        cm = new SqlCommand("cliente", cnx);
        cm.Parameters.AddWithValue("@b", 3);
        cm.Parameters.AddWithValue("@Idcliente", "");
        cm.Parameters.AddWithValue("@Nombres", "");
        cm.Parameters.AddWithValue("@Apellidos", "");
        cm.Parameters.AddWithValue("@Cedula", "");
        cm.Parameters.AddWithValue("@Telefono", "");

        cm.CommandType = CommandType.StoredProcedure;
        cnx.Open();
        dr = cm.ExecuteReader();
        listaClientes = new List<Clientes>();
        while (dr.Read())
        {
            Clientes cl = new Clientes();
            cl.Idcliente = Convert.ToInt32(dr["idcliente"].ToString());
            cl.Nombres = dr["nombres"].ToString();
            cl.Apellidos = dr["apellidos"].ToString();
            cl.Cedula = dr["cedula"].ToString();
            cl.Telefono = dr["telefono"].ToString();
            listaClientes.Add(cl);
        }
    }

    catch (Exception e)
    {
        e.Message.ToString();
        listaClientes = null;
    }
finally
{
cm.Connection.Close();
}
return listaClientes;

}



public int EliminarClientes(int idclient)
{
try
{
SqlConnection cnx=cn.conectar();

cm=new SqlCommand("cliente", cnx);
cm.Parameters.AddWithValue("@b", 2);
cm.Parameters.AddWithValue("@Idcliente", idclient);
cm.Parameters.AddWithValue("@Nombres", "");
cm.Parameters.AddWithValue("@Apellidos", "");
cm.Parameters.AddWithValue("@Cedula", "");
cm.Parameters.AddWithValue("@Telefono", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
cm.ExecuteNonQuery();
indicador= 1;

}
catch(Exception e)
{
e.Message.ToString();
indicador=0;
}
finally
{
cm.Connection.Close();
}
return indicador;

}

public int EditarClientes(Clientes c)
{
try
{

SqlConnection cnx=cn.conectar();
cm=new SqlCommand("cliente", cnx);
cm.Parameters.AddWithValue("@b", 4);
cm.Parameters.AddWithValue("@Idcliente", c.Idcliente);
cm.Parameters.AddWithValue("@Nombres", "");
cm.Parameters.AddWithValue("@Apellidos", "");
cm.Parameters.AddWithValue("@Cedula", "");
cm.Parameters.AddWithValue("@Telefono", "");


cm.CommandType = CommandType.StoredProcedure;
cnx.Open();
cm.ExecuteNonQuery();
indicador= 1;

}
catch(Exception e)
{
e.Message.ToString();
indicador=0;
}
finally
{
cm.Connection.Close();
}
return indicador;
}

public List<Clientes> BuscarClientes(string dato)
{
try
{
SqlConnection cnx= cn.conectar();
cm= new SqlCommand("cliente");
cm.Parameters.AddWithValue("@b", 5);
cm.Parameters.AddWithValue("@Idcliente", "");
cm.Parameters.AddWithValue("@Nombres", dato);
cm.Parameters.AddWithValue("@Apellidos", "");
cm.Parameters.AddWithValue("@Cedula", "");
cm.Parameters.AddWithValue("@Telefono", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
dr=cm.ExecuteReader();
listaClientes= new List<Clientes>();
while(dr.Read())
{
Clientes cl= new Clientes();
cl.Idcliente= Convert.ToInt32(dr["idcliente"].ToString());
cl.Nombres= dr["nombres"].ToString();
cl.Apellidos=dr["apellidos"].ToString();
cl.Cedula=dr["cedula"].ToString();
cl.Telefono=dr["Telefono"].ToString();
listaClientes.Add(cl);
}
}

catch (Exception e)
{
e.Message.ToString();
listaClientes=null;
}
finally
{
cm.Connection.Close();
}
return listaClientes;


}
    }

    
}
