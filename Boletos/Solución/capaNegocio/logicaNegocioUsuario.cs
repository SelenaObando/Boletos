using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaEntidades;
using CapaDatos;

namespace capaNegocio
{
    public class logicaNegocioUsuario
    {
        accesoDatosUsuario ac = new accesoDatosUsuario();

        public int insertarUsuario(Usuario u)
        {
            return ac.insertarUsuario(u);
        }

        public List<Usuario> listarUsuario()
        {
            return ac.listarUsuario();
        }

        public int EliminarUsuario(int idusuar)
        {
            return ac.EliminarUsuario(idusuar);
        }

        public int EditarUsuario(Usuario u)
        {
            return ac.EditarUsuario(u);
        }

        public List<Usuario> BuscarUsuario(string dato)
        {
            return ac.BuscarUsuario(dato);
        }
    }
}
