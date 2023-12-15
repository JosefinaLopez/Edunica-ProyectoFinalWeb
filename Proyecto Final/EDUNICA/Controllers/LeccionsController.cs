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
    [Authorize]
    public class LeccionsController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        // GET: Leccions
        public ActionResult Index(int ? id)
        {
            var lecciones = db.Lecciones.Include(l => l.Curso).Include(l => l.Progreso).Where( l=> l.CursoId == id);
            return View(lecciones.ToList());
        }

        // GET: Leccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            return View(leccion);
        }

        // GET: Leccions/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "NombreCurso");
            ViewBag.ProgresoId = new SelectList(db.Progresos, "Id", "Cantidad");
            return View();
        }

        // POST: Leccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreLeccion,Descripcion,Completado,CursoId,ProgresoId,Img")] Leccion leccion)
        {
            if (ModelState.IsValid)
            {
                db.Lecciones.Add(leccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "NombreCurso", leccion.CursoId);
            ViewBag.ProgresoId = new SelectList(db.Progresos, "Id", "Cantidad", leccion.ProgresoId);
            return View(leccion);
        }

        // GET: Leccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "NombreCurso", leccion.CursoId);
            ViewBag.ProgresoId = new SelectList(db.Progresos, "Id", "Cantidad", leccion.ProgresoId);
            return RedirectToAction("Index", "Cursoes");

        }

        // POST: Leccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreLeccion,Descripcion,Completado,CursoId,ProgresoId,Img")] Leccion leccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "NombreCurso", leccion.CursoId);
            ViewBag.ProgresoId = new SelectList(db.Progresos, "Id", "Id", leccion.ProgresoId);
            return RedirectToAction("Index","Cursoes");
        }

        // GET: Leccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            return View(leccion);
        }

        // POST: Leccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leccion leccion = db.Lecciones.Find(id);
            db.Lecciones.Remove(leccion);
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
