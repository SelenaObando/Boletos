using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace capaNegocio
{
    public class logicaNegocioCompra_boleto
    {
        accesoDatosCompra_boleto ac = new accesoDatosCompra_boleto();

        public int insertarCompra_boleto(Compra_boleto cb)
        {
            return ac.insertarCompra_boleto(cb);
        }

        public List<Compra_boleto> listarCompra_boleto()
        {
            return ac.listarCompra_boleto();
        }

        public int EliminarCompra_boleto(int idbolet)
        {
            return ac.EliminarCompra_boleto(idbolet);
        }

        public int EditarCompra_boleto(Compra_boleto cb)
        {
            return ac.EditarCompra_boleto(cb);
        }

        public List<Compra_boleto> BuscarCompra_boleto(string dato)
        {
            return ac.BuscarCompra_boleto(dato);
        }
    }
}
