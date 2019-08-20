using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;	
using System.Data;
using CapaDatos;

namespace CapaDatos
{
    public class accesoDatosPropietario
    {
        SqlConnection cnx;
        Propietario propie = new Propietario();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Propietario> listaPropietario = null;

        public int insertarPropietario(Propietario p)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("propiet", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@Idpropietario", "");
                cm.Parameters.AddWithValue("@Nombresp", p.Nombresp);
                cm.Parameters.AddWithValue("@Apellidosp", p.Apellidosp);
                cm.Parameters.AddWithValue("@Direccionp", p.Direccionp);
                cm.Parameters.AddWithValue("@Telefonop", p.Telefonop);
                cm.Parameters.AddWithValue("@Nombretransp", p.Nombretransp);

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

        public List<Propietario> listarPropietario()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("propiet", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@Idpropietario", "");
                cm.Parameters.AddWithValue("@Nombresp", "");
                cm.Parameters.AddWithValue("@Apellidosp", "");
                cm.Parameters.AddWithValue("@Direccionp", "");
                cm.Parameters.AddWithValue("@Telefonop", "");
                cm.Parameters.AddWithValue("@Nombretransp", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaPropietario = new List<Propietario>();
                while (dr.Read())
                {
                    Propietario prop = new Propietario();
                    prop.Idpropietario = Convert.ToInt32(dr["idpropietario"].ToString());
                    prop.Nombresp = dr["nombresp"].ToString();
                    prop.Apellidosp = dr["apellidosp"].ToString();
                    prop.Direccionp = dr["direccionp"].ToString();
                    prop.Telefonop = dr["telefonop"].ToString();
                    prop.Nombretransp = dr["nombretransp"].ToString();

                    listaPropietario.Add(prop);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaPropietario = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaPropietario;
        }


        public int EliminarPropietario(int idpropieta)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("propiet", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@Idpropietario", idpropieta);
                cm.Parameters.AddWithValue("@Nombresp", "");
                cm.Parameters.AddWithValue("@Apellidosp", "");
                cm.Parameters.AddWithValue("@Direccionp", "");
                cm.Parameters.AddWithValue("@Telefonop", "");
                cm.Parameters.AddWithValue("@Nombretransp", "");

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

        public int EditarPropietario(Propietario p)
        {
            try
            {

                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("propiet", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@Idpropietario", p.Idpropietario);
                cm.Parameters.AddWithValue("@Nombresp", "");
                cm.Parameters.AddWithValue("@Apellidosp", "");
                cm.Parameters.AddWithValue("@Direccionp", "");
                cm.Parameters.AddWithValue("@Telefonop", "");
                cm.Parameters.AddWithValue("@Nombretransp", "");

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

        public List<Propietario> BuscarPropietario(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("propiet", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@Idpropietario", "");
                cm.Parameters.AddWithValue("@Nombresp", dato);
                cm.Parameters.AddWithValue("@Apellidosp", "");
                cm.Parameters.AddWithValue("@Direccionp", "");
                cm.Parameters.AddWithValue("@Telefonop", "");
                cm.Parameters.AddWithValue("@Nombretransp", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaPropietario = new List<Propietario>();
                while (dr.Read())
                {
                    Propietario prop = new Propietario();
                    prop.Idpropietario = Convert.ToInt32(dr["idpropietario"].ToString());
                    prop.Nombresp = dr["nombresp"].ToString();
                    prop.Apellidosp = dr["apellidosp"].ToString();
                    prop.Direccionp = dr["direccionp"].ToString();
                    prop.Telefonop = dr["telefonop"].ToString();
                    prop.Nombretransp = dr["nombretransp"].ToString();
                    listaPropietario.Add(prop);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaPropietario = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaPropietario;
        }
    }
}
    

    

