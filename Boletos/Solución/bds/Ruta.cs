using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Ruta
    {
        public int Idruta { get; set; }
        public string NombreR { get; set; }
        public int Cant_asientos { get; set; }
        public string Hora_origen1 { get; set; }
        public string Hora_destino1 { get; set; }
        public string Hora_origen2 { get; set; }
        public string Hora_destino2 { get; set; }
        public int Idpropietario { get; set; }
    }
}
