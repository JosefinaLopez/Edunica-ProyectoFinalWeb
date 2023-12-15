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
    public class GradoesController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        // GET: Gradoes
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Grados.ToList());
        }

        // GET: Gradoes/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: Gradoes/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gradoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,NombreGrado")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Grados.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grado);
        }

        // GET: Gradoes/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Gradoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,NombreGrado")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grado);
        }

        // GET: Gradoes/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Gradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = db.Grados.Find(id);
            db.Grados.Remove(grado);
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
