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
    public class PedidoController : Controller
    {
        private EComercialContext db = new EComercialContext();

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Comprador);
            return View(pedidoes.ToList());
        }

        //
        // GET: /Pedido/Details/5

        public ActionResult Details(int id = 0)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            ViewBag.CompradorId = new SelectList(db.Compradors, "CompradorId", "Nombre");
            return View();
        }

        //
        // POST: /Pedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompradorId = new SelectList(db.Compradors, "CompradorId", "Nombre", pedido.CompradorId);
            return View(pedido);
        }

        //
        // GET: /Pedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompradorId = new SelectList(db.Compradors, "CompradorId", "Nombre", pedido.CompradorId);
            return View(pedido);
        }

        //
        // POST: /Pedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompradorId = new SelectList(db.Compradors, "CompradorId", "Nombre", pedido.CompradorId);
            return View(pedido);
        }

        //
        // GET: /Pedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // POST: /Pedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
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