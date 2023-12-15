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
    public class ProgresoesController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        // GET: Progresoes
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Progresos.ToList());
        }

        // GET: Progresoes/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progreso progreso = db.Progresos.Find(id);
            if (progreso == null)
            {
                return HttpNotFound();
            }
            return View(progreso);
        }

        // GET: Progresoes/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Progresoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,Cantidad")] Progreso progreso)
        {
            if (ModelState.IsValid)
            {
                db.Progresos.Add(progreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(progreso);
        }

        // GET: Progresoes/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progreso progreso = db.Progresos.Find(id);
            if (progreso == null)
            {
                return HttpNotFound();
            }
            return View(progreso);
        }

        // POST: Progresoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Cantidad")] Progreso progreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(progreso);
        }

        // GET: Progresoes/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progreso progreso = db.Progresos.Find(id);
            if (progreso == null)
            {
                return HttpNotFound();
            }
            return View(progreso);
        }

        // POST: Progresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Progreso progreso = db.Progresos.Find(id);
            db.Progresos.Remove(progreso);
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
