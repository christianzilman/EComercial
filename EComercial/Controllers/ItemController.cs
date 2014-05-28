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
    public class ItemController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /Item/

        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.SubCategoria);
            return View(items.ToList());
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            ViewBag.SubCategoriaId = new SelectList(db.SubCategorias, "SubCategoriaId", "Nombre");
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoriaId = new SelectList(db.SubCategorias, "SubCategoriaId", "Nombre", item.SubCategoriaId);
            return View(item);
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoriaId = new SelectList(db.SubCategorias, "SubCategoriaId", "Nombre", item.SubCategoriaId);
            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoriaId = new SelectList(db.SubCategorias, "SubCategoriaId", "Nombre", item.SubCategoriaId);
            return View(item);
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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