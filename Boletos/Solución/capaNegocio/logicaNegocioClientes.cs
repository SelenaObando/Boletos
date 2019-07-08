using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace capaNegocio
{
    class logicaNegocioClientes
    {
        accesoDatosClientes ac = new accesoDatosClientes();

        public int insertarClientes(Clientes c)
        {
            return ac.insertarClientes(c);
        }

        public List<Clientes> listarClientes()
        {
            return ac.listarClientes();
        }

        public int EliminarClientes(int idclient)
        {
            return ac.EliminarClientes(idclient);
        }

        public int EditarClientes(Clientes c)
        {
            return ac.EditarClientes(c);
        }

        public List<Clientes> BuscarClientes(string dato)
        {
            return ac.BuscarClientes(dato);
        }
    }
}
