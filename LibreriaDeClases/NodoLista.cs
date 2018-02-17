using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public class NodoLista<T>
    {
        public NodoLista(T value)
        {
            this.Value = value;
        }

        //Atributos
        public T Value
        {
            set;
            get;
        }

        public NodoLista<T> Siguiente
        {
            set;
            get;
        }
    }
}
