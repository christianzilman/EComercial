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
    public class FormaEntregaController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /FormaEntrega/

        public ActionResult Index()
        {
            var formaentregas = db.FormaEntregas.Include(f => f.Pedido).Include(f => f.TipoEntrega);
            return View(formaentregas.ToList());
        }

        //
        // GET: /FormaEntrega/Details/5

        public ActionResult Details(int id = 0)
        {
            FormaEntrega formaentrega = db.FormaEntregas.Find(id);
            if (formaentrega == null)
            {
                return HttpNotFound();
            }
            return View(formaentrega);
        }

        //
        // GET: /FormaEntrega/Create

        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId");
            ViewBag.TipoEntregaId = new SelectList(db.TipoEntregas, "TipoEntregaId", "Nombre");
            return View();
        }

        //
        // POST: /FormaEntrega/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaEntrega formaentrega)
        {
            if (ModelState.IsValid)
            {
                db.FormaEntregas.Add(formaentrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", formaentrega.PedidoId);
            ViewBag.TipoEntregaId = new SelectList(db.TipoEntregas, "TipoEntregaId", "Nombre", formaentrega.TipoEntregaId);
            return View(formaentrega);
        }

        //
        // GET: /FormaEntrega/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FormaEntrega formaentrega = db.FormaEntregas.Find(id);
            if (formaentrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", formaentrega.PedidoId);
            ViewBag.TipoEntregaId = new SelectList(db.TipoEntregas, "TipoEntregaId", "Nombre", formaentrega.TipoEntregaId);
            return View(formaentrega);
        }

        //
        // POST: /FormaEntrega/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaEntrega formaentrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaentrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", formaentrega.PedidoId);
            ViewBag.TipoEntregaId = new SelectList(db.TipoEntregas, "TipoEntregaId", "Nombre", formaentrega.TipoEntregaId);
            return View(formaentrega);
        }

        //
        // GET: /FormaEntrega/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FormaEntrega formaentrega = db.FormaEntregas.Find(id);
            if (formaentrega == null)
            {
                return HttpNotFound();
            }
            return View(formaentrega);
        }

        //
        // POST: /FormaEntrega/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaEntrega formaentrega = db.FormaEntregas.Find(id);
            db.FormaEntregas.Remove(formaentrega);
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