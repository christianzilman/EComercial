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
    public class CompradorController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /Comprador/

        public ActionResult Index()
        {
            return View(db.Compradors.ToList());
        }

        //
        // GET: /Comprador/Details/5

        public ActionResult Details(int id = 0)
        {
            Comprador comprador = db.Compradors.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        //
        // GET: /Comprador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comprador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Compradors.Add(comprador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comprador);
        }

        //
        // GET: /Comprador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Comprador comprador = db.Compradors.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        //
        // POST: /Comprador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comprador);
        }

        //
        // GET: /Comprador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Comprador comprador = db.Compradors.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        //
        // POST: /Comprador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprador comprador = db.Compradors.Find(id);
            db.Compradors.Remove(comprador);
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