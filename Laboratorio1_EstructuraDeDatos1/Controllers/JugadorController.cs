using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1_EstructuraDeDatos1.Models;
using Laboratorio1_EstructuraDeDatos1.DBContext;
using System.Net;

namespace Laboratorio1_EstructuraDeDatos1.Controllers
{
    public class JugadorController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        // GET: /Jugador/Index
        public ActionResult Index()
        {
            return View(db.Jugadores.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Jugadores.Where(x => x.jugadorID == id).FirstOrDefault());
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
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

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
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

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
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
    }
}
