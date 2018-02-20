using Laboratorio1_EstructuraDeDatos1.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace Laboratorio1_EstructuraDeDatos1.Controllers
{
    public class JugadorController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        /*Permite obtener el nombre de usuario de la computadora
         * Se espera que funcione en cualquier computadora
         */
        public static string ruta = @"C:\Users\" + Environment.UserName + @"\Desktop\logs.txt";
        // GET: /Jugador/Index
        public ActionResult Index()
        {
            logWriter("Visito en INICIO", ruta, false);
            return View(db.Jugadores.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            logWriter("Visito en DETALLES DEL JUGADOR", ruta, false);
            return View(db.Jugadores.Where(x => x.jugadorID == id).FirstOrDefault());
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            logWriter("Visito en CREAR UN JUGADOR", ruta, false);

            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(Jugador jugador)
        {
            try
            {
                // TODO: Add insert logic here
                db.Jugadores.Add(jugador);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //FUNCIONALIDAD EDITAR
        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            logWriter("Visito en EDITAR JUGADOR", ruta, false);
            return View(db.Jugadores.Where(x => x.jugadorID == id).FirstOrDefault());
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Club,Apellido,Nombre,Posicion,SalarioBase,CompensacionGarantizada,JugadorID")]Jugador jugador)
        {
            try
            {
                Jugador jugadorBuscado = db.Jugadores.Find(x => x.jugadorID == jugador.jugadorID);

                if (jugadorBuscado == null)
                {
                    return HttpNotFound();
                }

                jugadorBuscado.Nombre = jugador.Nombre;
                jugadorBuscado.Apellido = jugador.Apellido;
                jugadorBuscado.Club = jugador.Club;
                jugadorBuscado.SalarioBase = jugador.SalarioBase;
                jugadorBuscado.Posicion = jugador.Posicion;
                jugadorBuscado.CompensacionGarantizada = jugador.CompensacionGarantizada;

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        //FUNCIONALIDAD ELIMINAR
        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            logWriter("Visito ELIMINAR UN JUGADOR", ruta, false);

            return View(db.Jugadores.Where(x => x.jugadorID == id).FirstOrDefault());
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Jugador jugador = db.Jugadores.Where(x => x.jugadorID == id).FirstOrDefault();
                db.Jugadores.Remove(jugador);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Funcion que permite agregar logs de la acciones realizada por el usuario dentro del programa
        /// </summary>
        /// <param name="contenido">Acciones realizadas por el usuario</param>
        /// <param name="rutaArchivo"> ruta del archivo en la computadora</param>
        /// <param name="sobrescribir">no sobreescribir</param>
        public static void logWriter(string contenido, string rutaArchivo, bool sobrescribir = true)
        {
            StreamWriter logReporter = new StreamWriter(rutaArchivo, !sobrescribir);
            logReporter.WriteLine(contenido + "; " + DateTime.Now);
            logReporter.Close();
        }
    }
}
