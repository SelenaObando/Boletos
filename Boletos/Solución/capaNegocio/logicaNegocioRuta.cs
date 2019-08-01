using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace capaNegocio
{
    public class logicaNegocioRuta
    {
        accesoDatosRuta ac = new accesoDatosRuta();

        public int insertarRuta(Ruta r)
        {
            return ac.insertarRuta(r);
        }

        public List<Ruta> listarRuta()
        {
            return ac.listarRuta();
        }

        public int EliminarRuta(int idrut)
        {
            return ac.EliminarRuta(idrut);
        }

        public int EditarRuta(Ruta r)
        {
            return ac.EditarRuta(r);
        }

        public List<Ruta> BuscarRuta(string dato)
        {
            return ac.BuscarRuta(dato);
        }
    }
}
