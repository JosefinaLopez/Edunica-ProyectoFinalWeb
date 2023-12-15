using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDUNICA.Models;

namespace EDUNICA.Controllers
{
    public class InteresesCategoriasController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        // GET: InteresesCategorias
        public ActionResult Index()
        {
            var interesesCategorias = db.InteresesCategorias.Include(i => i.Estudiante).Include(i => i.Categoria);
            return View(interesesCategorias.ToList());
        }

        // GET: InteresesCategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresesCategoria interesesCategoria = db.InteresesCategorias.Find(id);
            if (interesesCategoria == null)
            {
                return HttpNotFound();
            }
            return View(interesesCategoria);
        }

        // GET: InteresesCategorias/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "NombreEstudiante");
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria");
            return View();
        }

        // POST: InteresesCategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EstudianteId,CategoriaId")] InteresesCategoria interesesCategoria)
        {
            if (ModelState.IsValid)
            {
                db.InteresesCategorias.Add(interesesCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "NombreEstudiante", interesesCategoria.EstudianteId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", interesesCategoria.CategoriaId);
            return View(interesesCategoria);
        }

        // GET: InteresesCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresesCategoria interesesCategoria = db.InteresesCategorias.Find(id);
            if (interesesCategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "NombreEstudiante", interesesCategoria.EstudianteId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", interesesCategoria.CategoriaId);
            return View(interesesCategoria);
        }

        // POST: InteresesCategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EstudianteId,CategoriaId")] InteresesCategoria interesesCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interesesCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "NombreEstudiante", interesesCategoria.EstudianteId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", interesesCategoria.CategoriaId);
            return View(interesesCategoria);
        }

        // GET: InteresesCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresesCategoria interesesCategoria = db.InteresesCategorias.Find(id);
            if (interesesCategoria == null)
            {
                return HttpNotFound();
            }
            return View(interesesCategoria);
        }

        // POST: InteresesCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InteresesCategoria interesesCategoria = db.InteresesCategorias.Find(id);
            db.InteresesCategorias.Remove(interesesCategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
