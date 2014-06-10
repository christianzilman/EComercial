using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EComercial.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual int UserId { get; set; }
    }
}