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
    public class SubCategoriaController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /SubCategoria/

        public ActionResult Index()
        {
            var subcategorias = db.SubCategorias.Include(s => s.Categoria);
            return View(subcategorias.ToList());
        }

        //
        // GET: /SubCategoria/Details/5

        public ActionResult Details(int id = 0)
        {
            SubCategoria subcategoria = db.SubCategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        //
        // GET: /SubCategoria/Create

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre");
            return View();
        }

        //
        // POST: /SubCategoria/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.SubCategorias.Add(subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        //
        // GET: /SubCategoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubCategoria subcategoria = db.SubCategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        //
        // POST: /SubCategoria/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", subcategoria.CategoriaId);
            return View(subcategoria);
        }

        //
        // GET: /SubCategoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubCategoria subcategoria = db.SubCategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        //
        // POST: /SubCategoria/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoria subcategoria = db.SubCategorias.Find(id);
            db.SubCategorias.Remove(subcategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}