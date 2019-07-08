using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Compra_boleto
    {
        public int Idboleto { get; set; }
        public int Nmero_asiento { get; set; }
        public int Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int Idruta { get; set; }
    }
}
