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
    public class ColaboracionsController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        // GET: Colaboracions
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Colaboraciones.ToList());
        }

        // GET: Colaboracions/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboracion colaboracion = db.Colaboraciones.Find(id);
            if (colaboracion == null)
            {
                return HttpNotFound();
            }
            return View(colaboracion);
        }

        // GET: Colaboracions/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colaboracions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,TipoColaboracion")] Colaboracion colaboracion)
        {
            if (ModelState.IsValid)
            {
                db.Colaboraciones.Add(colaboracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colaboracion);
        }

        // GET: Colaboracions/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboracion colaboracion = db.Colaboraciones.Find(id);
            if (colaboracion == null)
            {
                return HttpNotFound();
            }
            return View(colaboracion);
        }

        // POST: Colaboracions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,TipoColaboracion")] Colaboracion colaboracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaboracion);
        }

        // GET: Colaboracions/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboracion colaboracion = db.Colaboraciones.Find(id);
            if (colaboracion == null)
            {
                return HttpNotFound();
            }
            return View(colaboracion);
        }

        // POST: Colaboracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaboracion colaboracion = db.Colaboraciones.Find(id);
            db.Colaboraciones.Remove(colaboracion);
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
