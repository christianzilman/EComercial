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
    public class CarroController : Controller
    {
        //
        // GET: /Carro/
        private EComercialContext db = new EComercialContext();

        public ActionResult Index()
        {
            var productoes = db.Productoes.Include(p => p.Item).Include(p => p.Negocio);
            return View(productoes.ToList());            
        }


        public ActionResult VerCarrito()
        {
            var carros = db.Carros.Include(p => p.Producto).Where(p => p.UserId == 1);
            return View("VerCarrito", carros.ToList());
           
            //return View(productoes.ToList());   
        }
        public ActionResult Add(int id = 0)
        {

            // Retrieve the product from the database.           
            var carro = db.Carros.SingleOrDefault(
                c => c.UserId == 1
                && c.ProductoId == id);
            if (carro == null)
            {
                Producto producto = db.Productoes.Find(id);
                // Create a new cart item if no cart item exists.                 
                carro = new Carro
                {
                    ProductoId = id,
                    Producto = producto,
                    Precio = producto.PrecioVenta,
                    SubTotal = producto.PrecioVenta,
                    UserId = 1,
                    Cantidad = 1
                };
                db.Carros.Add(carro);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                carro.Cantidad++;
                carro.SubTotal = carro.Precio * carro.Cantidad;
            }
            db.SaveChanges();

            var carros = db.Carros.Include(p=>p.Producto).Where(p =>p.UserId == 1);
            return View("Carro", carros.ToList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update(FormCollection fc, List<int> ProductoId, List<int> Cantidad) 
        {
            
            ViewBag.Suma = 0;
            if (!(fc["update"] == null))
            {
                for (int i = 0; i < ProductoId.Count; i++)
                {
                    // Retrieve the product from the database.           
                    int id = ProductoId[i];
                    var carro = db.Carros.SingleOrDefault(
                        c => c.UserId == 1
                        && c.ProductoId == id);
                    carro.Cantidad = Cantidad[i];
                    carro.SubTotal = carro.Precio * carro.Cantidad;
                    ViewBag.Suma = ViewBag.Suma + Convert.ToDouble(carro.SubTotal);
                    db.SaveChanges();
                }
                var carros = db.Carros.Include(p => p.Producto).Where(p => p.UserId == 1);
                return View("Carro", carros.ToList());
            }
            else {

                List<DetallePedido> detallePedidos = new List<DetallePedido>();

                double total = 0.00;
                for (int i = 0; i < ProductoId.Count; i++)
                {
                    // Retrieve the product from the database.           
                    int id = ProductoId[i];
                    var carro = db.Carros.SingleOrDefault(
                        c => c.UserId == 1
                        && c.ProductoId == id);
                    carro.Cantidad = Cantidad[i];
                    carro.SubTotal = carro.Precio * carro.Cantidad;

                    DetallePedido detallePedido = new DetallePedido();
                    detallePedido.Cantidad = carro.Cantidad;
                    detallePedido.Precio = carro.Precio;
                    detallePedido.ProductoId = carro.ProductoId;
                    detallePedido.SubTotal = carro.SubTotal;

                    total = total + (double) carro.SubTotal;
                    detallePedidos.Add(detallePedido);

                    
                }

                Pedido pedido = new Pedido();
                pedido.CompradorId = 1;
                pedido.EstadoId = 1;
                pedido.Fecha = DateTime.Now;
                pedido.Total = total;
                pedido.DetallePedidoes = detallePedidos;
                db.Pedidoes.Add(pedido);
                

                var carros = db.Carros.Where(c => c.UserId == 1);
                foreach(Carro carro in carros)
                {
                    db.Carros.Remove(carro);                   
                }
                db.SaveChanges();
                var productoes = db.Productoes.Include(p => p.Item).Include(p => p.Negocio);
                return View("Index",productoes.ToList());   
            }          
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Confirmate(List<int> ProductoId, List<int> Cantidad)
        {

            for (int i = 0; i < ProductoId.Count; i++)
            {
                // Retrieve the product from the database.           
                int id = ProductoId[i];
                var carro = db.Carros.SingleOrDefault(
                    c => c.UserId == 1
                    && c.ProductoId == id);
                carro.Cantidad = Cantidad[i];
                carro.SubTotal = carro.Precio * carro.Cantidad;

                db.SaveChanges();
            }

            return Index();
        }

        public ActionResult Carro() 
        {
            var carros = db.Carros.Include(p => p.Producto).Where(p => p.UserId == 1);
            return View("Carro", carros.ToList());
        }
    }
}
