using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Producto
    {
        public Producto()
        {
            this.DetallePedidoes = new List<DetallePedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> PrecioCompra { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public byte[] Imagen { get; set; }
        public int SubCategoriaId { get; set; }
        public Nullable<int> NegocioId { get; set; }
        public Nullable<double> PrecioVenta { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Negocio Negocio { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
    }
}
