using EComercial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EComercial.Controllers
{
    public class HomeController : Controller
    {
        private EComercialContext db = new EComercialContext();
        public ActionResult Index()
        {
            ViewBag.Message = "";
            
            return View(db.Categorias.ToList());
                    }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QR(FormCollection form)
        {

            var pagina = form["txtPagina"];
            ViewBag.Pagina = pagina;
            return View();
        }

    }
}
