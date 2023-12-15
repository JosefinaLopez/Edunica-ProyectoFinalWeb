using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EDUNICA.Models;

namespace EDUNICA.Controllers
{
    [Authorize]
    public class CursoesController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        public JsonResult ObtenerCursosConProgresoJson()
        {
            var cursosConProgreso = db.Cursos
                .Include(c => c.Categoria)
                .Include(c => c.Grado)
                .Include(c => c.Maestro)
                .Include(c => c.Colaboracion)
                .Join(db.Lecciones, c => c.Id, l => l.CursoId, (c, l) => new { Curso = c, Leccion = l })
                .Join(db.Progresos, cl => cl.Leccion.ProgresoId, pr => pr.Id, (cl, pr) => new { CursoLeccion = cl, Progreso = pr })
                .Where(joined => joined.CursoLeccion.Leccion.Completado == true || joined.CursoLeccion.Leccion.Completado == false)
                .GroupBy(joined => joined.CursoLeccion)
                .Select(group => new
                {
                    Curso = group.Key.Curso.NombreCurso,  // Agrega el Id del curso
                    CantidadProgreso = group.Sum(joined => joined.Progreso.Cantidad),
                    Docente = group.Key.Curso.Maestro.NombreMaestro,
                    Anio = group.Key.Curso.Grado.NombreGrado,
                    Colaboracion = group.Key.Curso.Colaboracion.TipoColaboracion
                })
                .ToList();

            return Json(cursosConProgreso, JsonRequestBehavior.AllowGet);
        }


        // GET: Cursoes
        //Se adapta los requerimientos de los usuarios
        public ActionResult Index()
        {
            var cursos = db.Cursos
           .Include(c => c.Categoria)
           .Include(c => c.Grado)
           .Include(c => c.Maestro)
           .Include(c => c.Colaboracion)
           .Include(c => c.Leccions);


            return View(cursos.ToList());
        }

        // GET: Cursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria");
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "NombreGrado");
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "NombreMaestro");
            ViewBag.ColaboracionId = new SelectList(db.Colaboraciones, "Id", "TipoColaboracion");
            return View();
        }

        // POST: Cursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCurso,Presupuesto,CategoriaId,GradoId,MaestroId,ColaboracionId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", curso.CategoriaId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "NombreGrado", curso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "NombreMaestro", curso.MaestroId);
            ViewBag.ColaboracionId = new SelectList(db.Colaboraciones, "Id", "TipoColaboracion", curso.ColaboracionId);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", curso.CategoriaId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "NombreGrado", curso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "NombreMaestro", curso.MaestroId);
            ViewBag.ColaboracionId = new SelectList(db.Colaboraciones, "Id", "TipoColaboracion", curso.ColaboracionId);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,NombreCurso,Presupuesto,CategoriaId,GradoId,MaestroId,ColaboracionId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "NombreCategoria", curso.CategoriaId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "NombreGrado", curso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "NombreMaestro", curso.MaestroId);
            ViewBag.ColaboracionId = new SelectList(db.Colaboraciones, "Id", "TipoColaboracion", curso.ColaboracionId);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
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
