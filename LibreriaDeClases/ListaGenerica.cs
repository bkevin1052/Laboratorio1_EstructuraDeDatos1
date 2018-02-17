using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public class ListaGenerica<T>
    {

        public NodoLista<T> inicio
        {
            set;
            get;
        }

        public NodoLista<T> fin
        {
            set;
            get;
        }

        public ListaGenerica()
        {
            this.inicio = null;
            this.fin = null;
        }

        /// <summary>
        /// Verifica si la lista esta vacía
        /// </summary>
        /// <returns>Verdadero si la lista está vacia, falso de lo contrario</returns>
        public bool ListaEstaVacia()
        {
            return (inicio == null) && (fin == null);
        }

        /// <summary>
        /// Esta función devuelve la cantidad de elementos que posee la lista
        /// </summary>
        /// <returns></returns>
        public int Cantidadelementos()
        {
            NodoLista<T> pivote = inicio;
            int cantidad = 0;

            while (pivote != null)
            {
                cantidad++;
                pivote = pivote.Siguiente;
            }

            return cantidad;
        }

        /// <summary>
        /// Inserta un nuevo valor, al final de la lista
        /// </summary>
        /// <param name="value">El valor que se desea insertar</param>
        public void Insertar(T value)
        {
            NodoLista<T> nuevo = new NodoLista<T>(value);

            if (ListaEstaVacia())
            {
                inicio = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.Siguiente = nuevo;
                fin = nuevo;
            }

        }

        /// <summary>
        /// Inserta el valor en una determinada posición de la lista
        /// </summary>
        /// <param name="value">El valor que se desea insertar</param>
        /// <param name="index">El indice basado en 0 en el que se desea insertar, si el indice es mayor al tamaño se inserta al final</param>
        public void Insertar(T value, int index)
        {
            NodoLista<T> nuevo = new NodoLista<T>(value);

            if (ListaEstaVacia()) //Lista vacia, se inserta al inicio
            {
                Insertar(value);
            }
            else if (!ListaEstaVacia() && (Cantidadelementos() <= index))
            { //Lista no vacía y la cantidad de elementos es menor o igual que el índice
                fin.Siguiente = nuevo;
                fin = nuevo;
            }
            else  //Hay elementos y el numero esta dentro del rango
            {

                if (index == 0) //Se inserta en el inicio
                {
                    nuevo.Siguiente = inicio;
                    inicio = nuevo;
                }
                else
                { //Se inserta en cualquier otra posición no inicial.
                    NodoLista<T> pivote = inicio;
                    for (int i = 1; i < index; i++)
                    {
                        pivote = pivote.Siguiente;
                    }

                    nuevo.Siguiente = pivote.Siguiente;
                    pivote.Siguiente = nuevo;
                }

            }
        }

        /// <summary>
        /// Método que extrae un valor de la lista.
        /// </summary>
        /// <param name="index">El valor que se desea extraer</param>
        /// <returns>Valor T extraido</returns>
        public T Extraer(int index)
        {
            if (!ListaEstaVacia())
            {
                if (index == 0) //Extraigo valor inicial
                {
                    if (Cantidadelementos() == 1) //Solo tengo un elemento
                    {
                        T valorExtraido = inicio.Value;
                        inicio = null;
                        fin = null;
                        return valorExtraido;
                    }
                    else //Varios elementos
                    {
                        T valorExtraido = inicio.Value;
                        inicio = inicio.Siguiente;
                        return valorExtraido;

                    }
                }
                else if (index == (Cantidadelementos() - 1))
                { //Extraigo el valor final
                    if (Cantidadelementos() == 1) //Solo tengo un elemento
                    {
                        T valorExtraido = fin.Value;
                        inicio = null;
                        fin = null;
                        return valorExtraido;
                    }
                    else //Varios elementos
                    {
                        NodoLista<T> pivote = inicio;
                        T valorExtraido = fin.Value;
                        while (pivote.Siguiente != fin)
                        {
                            pivote = pivote.Siguiente;
                        }

                        pivote.Siguiente = null;
                        fin = pivote;
                        return valorExtraido;
                    }
                }
                else //El valor a extraer no es ni el inicio ni el fin
                {
                    NodoLista<T> pivote = inicio;
                    for (int i = 1; i < index; i++)
                    {
                        pivote = pivote.Siguiente;
                    }

                    T valorExtraido = pivote.Siguiente.Value;
                    pivote.Siguiente = pivote.Siguiente.Siguiente;
                    return valorExtraido;
                }

            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Método que devuelve el arreglo de elementos.
        /// </summary>
        /// <returns>Arreglo de elementos</returns>
        public T[] ObtenerArreglo()
        {

            if (!ListaEstaVacia())
            {
                T[] arreglo = new T[Cantidadelementos()];
                NodoLista<T> pivote = inicio;
                int index = 0;
                while (pivote != null)
                {
                    arreglo[index] = pivote.Value;
                    pivote = pivote.Siguiente;
                    index++;
                }

                return arreglo;
            }
            else
            {
                return null;
            }
        }
    }
}
