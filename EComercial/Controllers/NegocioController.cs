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
    public class NegocioController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /Negocio/

        public ActionResult Index()
        {
            return View(db.Negocios.ToList());
        }

        //
        // GET: /Negocio/Details/5

        public ActionResult Details(int id = 0)
        {
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        //
        // GET: /Negocio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Negocio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Negocios.Add(negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(negocio);
        }

        //
        // GET: /Negocio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        //
        // POST: /Negocio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(negocio);
        }

        //
        // GET: /Negocio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        //
        // POST: /Negocio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Negocio negocio = db.Negocios.Find(id);
            db.Negocios.Remove(negocio);
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