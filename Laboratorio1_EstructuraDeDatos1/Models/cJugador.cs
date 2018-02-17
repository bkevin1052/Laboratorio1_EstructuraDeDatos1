using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio1_EstructuraDeDatos1.Models
{
    public class cJugador
    {
        public string Club { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Posicion { get; set; }

        public double SalarioBase { get; set; }

        public double CompensacionGarantizada { get; set; }
    }
}