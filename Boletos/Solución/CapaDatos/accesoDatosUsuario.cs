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
    public class accesoDatosUsuario
    {
        SqlConnection cnx;
        Usuario usuar = new Usuario();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Usuario> listaUsuario = null;

        public int insertarUsuario(Usuario u)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("usuar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@Idusuario", "");
                cm.Parameters.AddWithValue("@Nombre", u.Nombre);
                cm.Parameters.AddWithValue("@Apellido", u.Apellido);
                cm.Parameters.AddWithValue("@Direccion", u.Direccion);
                cm.Parameters.AddWithValue("@Correo", u.Correo);
                cm.Parameters.AddWithValue("@TelefonoU", u.TelefonoU);


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

        public List<Usuario> listarUsuario()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("usuar", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@Idusuario", "");
                cm.Parameters.AddWithValue("@Nombre", "");
                cm.Parameters.AddWithValue("@Apellido", "");
                cm.Parameters.AddWithValue("@Direccion", "");
                cm.Parameters.AddWithValue("@Correo", "");
                cm.Parameters.AddWithValue("@TelefonoU", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaUsuario = new List<Usuario>();
                while (dr.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    usu.Nombre = dr["nombre"].ToString();
                    usu.Apellido = dr["apellido"].ToString();
                    usu.Direccion = dr["direccion"].ToString();
                    usu.Correo = dr["correo"].ToString();
                    usu.TelefonoU = dr["TelefonoU"].ToString();
                    listaUsuario.Add(usu);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaUsuario = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaUsuario;

        }


        public int EliminarUsuario(int idusuar)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("usuar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@Idusuario", idusuar);
                cm.Parameters.AddWithValue("@Nombre", "");
                cm.Parameters.AddWithValue("@Apellido", "");
                cm.Parameters.AddWithValue("@Direccion", "");
                cm.Parameters.AddWithValue("@Correo", "");
                cm.Parameters.AddWithValue("@TelefonoU", "");

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

        public int EditarUsuario(Usuario u)
        {
            try
            {

                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("usuario", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@Idusuario", u.Idusuario);
                cm.Parameters.AddWithValue("@Nombre", "");
                cm.Parameters.AddWithValue("@Apellido", "");
                cm.Parameters.AddWithValue("@Direccion", "");
                cm.Parameters.AddWithValue("@Correo", "");
                cm.Parameters.AddWithValue("@TelefonoU", "");

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

        public List<Usuario> BuscarUsuario(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("usuario", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@Idusuario", "");
                cm.Parameters.AddWithValue("@Nombre", "");
                cm.Parameters.AddWithValue("@Apellido", "");
                cm.Parameters.AddWithValue("@Direccion", "");
                cm.Parameters.AddWithValue("@Correo", "");
                cm.Parameters.AddWithValue("@TelefonoU", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaUsuario = new List<Usuario>();
                while (dr.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    usu.Nombre = dr["nombre"].ToString();
                    usu.Apellido = dr["apellido"].ToString();
                    usu.Direccion = dr["direccion"].ToString();
                    usu.Correo = dr["correo"].ToString();
                    usu.TelefonoU = dr["telefonoU"].ToString();

                    listaUsuario.Add(usu);
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
                listaUsuario = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaUsuario;
        }
    }
}

    

    

