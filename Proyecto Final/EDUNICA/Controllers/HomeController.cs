using EDUNICA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUNICA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DiagramaEDUNICAContainer db = new DiagramaEDUNICAContainer();

        public ActionResult Index()
        {
            var resultados = (from c in db.Cursos
                              join cl in db.Colaboraciones on c.ColaboracionId equals cl.Id
                              group c by 1 into g
                              select new DatosInfo
                              {
                                  Cantidad = db.Cursos.Count(),
                                  CantidadColaboraciones = db.Colaboraciones.Count(),
                                  Presupuesto = db.Cursos.Sum(curso => curso.Presupuesto)
                              }).ToList();
            return View(resultados);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}