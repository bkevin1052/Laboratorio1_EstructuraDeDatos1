using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio1_EstructuraDeDatos1.Models;

namespace Laboratorio1_EstructuraDeDatos1.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        public LinkedList<Jugador> Jugadores = new LinkedList<Jugador>();

        public int IDActual { get; set; }

        private DefaultConnection()
        {
            IDActual = 0;
        }

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}