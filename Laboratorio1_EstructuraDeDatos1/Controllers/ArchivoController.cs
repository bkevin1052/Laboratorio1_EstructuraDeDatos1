using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1_EstructuraDeDatos1.Models;

namespace Laboratorio1_EstructuraDeDatos1.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Archivo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Archivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Archivo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Archivo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Archivo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Archivo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Archivo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET SubirArchivo
        public ActionResult SubirArchivo()
        {
            return View();
        }

        //Post SubirArchivo
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file)
        {
            Archivo modelo = new Archivo();
            if (file != null)
            {
                string ruta = Server.MapPath("~/Temp/");
                ruta += file.FileName;
                modelo.SubirArchivo(ruta, file);
                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
            }
            return View();
        }
    }
}
