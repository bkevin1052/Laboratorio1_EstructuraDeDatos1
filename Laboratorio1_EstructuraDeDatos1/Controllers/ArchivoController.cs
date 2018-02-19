using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1_EstructuraDeDatos1.Models;

namespace Laboratorio1_EstructuraDeDatos1.Controllers
{
    public class ArchivoController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
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
            string filePath = string.Empty;
            Archivo modelo = new Archivo();
            if (file != null)
            {
                string ruta = Server.MapPath("~/Temp/");
                
                if(!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                filePath = ruta + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);

                foreach(string row in csvData.Split('\n'))
                {
                    if (!(row == "club,last_name,first_name,position,base_salary,guaranteed_compensation"))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            db.Jugadores.Add(new Jugador
                            {
                                Club = row.Split(',')[0],
                                Apellido = row.Split(',')[1],
                                Nombre = row.Split(',')[2],
                                Posicion = row.Split(',')[3],
                                SalarioBase = Convert.ToDouble(row.Split(',')[4]),
                                CompensacionGarantizada = Convert.ToDouble(row.Split(',')[5])
                            });

                            }
                        }
                    }

                modelo.SubirArchivo(ruta, file);

                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
            }
            return View(db.Jugadores);
        }
    }
}
