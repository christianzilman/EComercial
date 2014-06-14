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
    public class ProductoController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var productoes = db.Productoes.Include(p => p.Item).Include(p => p.Negocio);
            return View(productoes.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre");
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre");
            return View();
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", producto.ItemId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", producto.NegocioId);
            return View(producto);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", producto.ItemId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", producto.NegocioId);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", producto.ItemId);
                ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", producto.NegocioId);
                return View(producto);
        }

        //
        // GET: /Producto/Delete/5



        public ActionResult Delete(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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