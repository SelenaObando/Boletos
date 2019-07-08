using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace capaNegocio
{
    class logicaNegocioPropietario
    {
        accesoDatosPropietario ac = new accesoDatosPropietario();

        public int insertarPropietario(Propietario p)
        {
            return ac.insertarPropietario(p);
        }

        public List<Propietario> listarPropietario()
        {
            return ac.listarPropietario();
        }

        public int EliminarPropietario(int idpropieta)
        {
            return ac.EliminarPropietario(idpropieta);
        }

        public int EditarPropietario(Propietario p)
        {
            return ac.EditarPropietario(p);
        }

        public List<Propietario> BuscarPropietario(string dato)
        {
            return ac.BuscarPropietario(dato);
        }
    }
}
