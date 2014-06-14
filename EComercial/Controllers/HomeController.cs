using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EComercial.Models;


namespace EComercial.Controllers
{
    public class HomeController : Controller
    {
        private EComercialContext db = new EComercialContext();
        public ActionResult Index()
        {
            ViewBag.Message = "";
            IList<Producto> products = db.Productoes.Include(p => p.Item).Include(p => p.Negocio).Where(p => p.Destacado == 1).ToList();
            ViewBag.Products = products;

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

        public ActionResult ListadoProductos(int id = 0)
        {
            var producto = db.Productoes.Where(p => p.ItemId == id);
            return View(producto);

        }

        public ActionResult ListadoDestacado(int id = 0)
        {
            IList<Producto> products= db.Productoes.Where(p => p.ItemId == id && p.Destacado == 1 ).ToList();
            ViewBag.Products = products;
            return View();
        }

        public ActionResult SubCategoriasVistas(int id = 0)
        {
            
            var categoria = db.Categorias.Include(p =>p.SubCategorias.Select(x => x.Items) ).Where(t =>t.CategoriaId==id);

            IList<Producto> products= db.Productoes.Include(p => p.Item).Include(p => p.Item.SubCategoria).
                    Include(p => p.Item.SubCategoria.Categoria).
                    Where(p=>p.Item.SubCategoria.CategoriaId== id).ToList();
            ViewBag.Products = products;
           //db.SubCategorias.Include(p => p. ).Find(SubCategoriaId)
            return View(categoria);
        }

        public ActionResult QR(FormCollection form)
        {

            var pagina = form["txtPagina"];
            ViewBag.Pagina = pagina;
            return View();
        }

    }
}
