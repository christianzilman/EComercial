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
    public class TipoEntregaController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /TipoEntrega/

        public ActionResult Index()
        {
            return View(db.TipoEntregas.ToList());
        }

        //
        // GET: /TipoEntrega/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoEntrega tipoentrega = db.TipoEntregas.Find(id);
            if (tipoentrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoentrega);
        }

        //
        // GET: /TipoEntrega/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoEntrega/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEntrega tipoentrega)
        {
            if (ModelState.IsValid)
            {
                db.TipoEntregas.Add(tipoentrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoentrega);
        }

        //
        // GET: /TipoEntrega/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoEntrega tipoentrega = db.TipoEntregas.Find(id);
            if (tipoentrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoentrega);
        }

        //
        // POST: /TipoEntrega/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoEntrega tipoentrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoentrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoentrega);
        }

        //
        // GET: /TipoEntrega/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoEntrega tipoentrega = db.TipoEntregas.Find(id);
            if (tipoentrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoentrega);
        }

        //
        // POST: /TipoEntrega/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEntrega tipoentrega = db.TipoEntregas.Find(id);
            db.TipoEntregas.Remove(tipoentrega);
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