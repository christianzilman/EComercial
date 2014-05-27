using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class DetallePedido
    {
        public int DetallePedidoId { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
