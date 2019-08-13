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
    public class accesoDatosRuta
    {
        SqlConnection cnx;
        Ruta rta = new Ruta();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Ruta> listaRuta = null;

        public int insertarRuta(Ruta r)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("rut", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@Idruta", "");
                cm.Parameters.AddWithValue("@NombreR", r.NombreR);
                cm.Parameters.AddWithValue("@Idbus", r.Idbus);
                cm.Parameters.AddWithValue("@Cant_asientos", r.Cant_asientos);
                cm.Parameters.AddWithValue("@Hora_origen1", r.Hora_origen1);
                cm.Parameters.AddWithValue("@Hora_destino1", r.Hora_destino1);
                cm.Parameters.AddWithValue("@Hora_origen2", r.Hora_origen2);
                cm.Parameters.AddWithValue("@Hora_destino2", r.Hora_destino2);

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

        public List<Ruta> listarRuta()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("rut", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@Idruta", "");
                cm.Parameters.AddWithValue("@NombreR", "");
                cm.Parameters.AddWithValue("@Idbus", "");
                cm.Parameters.AddWithValue("@Cant_asientos", "");
                cm.Parameters.AddWithValue("@Hora_origen1", "");
                cm.Parameters.AddWithValue("@Hora_destino1", "");
                cm.Parameters.AddWithValue("@Hora_origen2", "");
                cm.Parameters.AddWithValue("@Hora_destino2", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRuta = new List<Ruta>();
                while (dr.Read())
                {
                    Ruta rt = new Ruta();
                    rt.Idruta = Convert.ToInt32(dr["Idruta"].ToString());
                    rt.NombreR = dr["NombreR"].ToString();
                    rt.Idbus = Convert.ToInt32(dr["Idbus"].ToString());
                    rt.Cant_asientos = Convert.ToInt32(dr["Cant_asientos"].ToString());
                    rt.Hora_origen1 = Convert.ToDateTime(dr["Hora_origen1"]);
                    rt.Hora_destino1 = Convert.ToDateTime(dr["Hora_destino1"]);
                    rt.Hora_origen2 = Convert.ToDateTime(dr["Hora_origen2"]);
                    rt.Hora_destino2 = Convert.ToDateTime(dr["Hora_destino2"]);

                    listaRuta.Add(rt);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaRuta = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaRuta;

        }


        public int EliminarRuta(int idrut)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("rut", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@Idruta", idrut);
                cm.Parameters.AddWithValue("@NombreR", "");
                cm.Parameters.AddWithValue("@Idbus", "");
                cm.Parameters.AddWithValue("@Cant_asientos", "");
                cm.Parameters.AddWithValue("@Hora_origen1", "");
                cm.Parameters.AddWithValue("@Hora_destino1", "");
                cm.Parameters.AddWithValue("@Hora_origen2", "");
                cm.Parameters.AddWithValue("@Hora_destino2", "");

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

        public int EditarRuta(Ruta r)
        {
            try
            {

                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("rut", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@Idruta", r.Idruta);
                cm.Parameters.AddWithValue("@NombreR", "");
                cm.Parameters.AddWithValue("@Idbus", "");
                cm.Parameters.AddWithValue("@Cant_asientos", "");
                cm.Parameters.AddWithValue("@Hora_origen1", "");
                cm.Parameters.AddWithValue("@Hora_destino1", "");
                cm.Parameters.AddWithValue("@Hora_origen2", "");
                cm.Parameters.AddWithValue("@Hora_destino2", "");

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

        public List<Ruta> BuscarRuta(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("rut");
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@Idruta", "");
                cm.Parameters.AddWithValue("@NombreR", dato);
                cm.Parameters.AddWithValue("@Idbus", "");
                cm.Parameters.AddWithValue("@Cant_asientos", "");
                cm.Parameters.AddWithValue("@Hora_origen1", "");
                cm.Parameters.AddWithValue("@Hora_destino1", "");
                cm.Parameters.AddWithValue("@Hora_origen2", "");
                cm.Parameters.AddWithValue("@Hora_destino2", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRuta = new List<Ruta>();
                while (dr.Read())
                {
                    Ruta rt = new Ruta();
                    rt.Idruta = Convert.ToInt32(dr["Idruta"].ToString());
                    rt.NombreR = dr["NombreR"].ToString();
                    rt.Idbus = Convert.ToInt32(dr["Idbus"].ToString());
                    rt.Cant_asientos = Convert.ToInt32(dr["Cant_asientos"].ToString());
                    rt.Hora_origen1 = Convert.ToDateTime(dr["Hora_origen1"]);
                    rt.Hora_destino1 = Convert.ToDateTime(dr["Hora_destino1"]);
                    rt.Hora_origen2 = Convert.ToDateTime(dr["Hora_origen2"]);
                    rt.Hora_destino2 = Convert.ToDateTime(dr["Hora_destino2"]);
                    listaRuta.Add(rt);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaRuta = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaRuta;
        }
    }
}

