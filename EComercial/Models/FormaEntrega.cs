using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class FormaEntrega
    {
        public int FormaEntregaId { get; set; }
        public Nullable<int> TipoEntregaId { get; set; }
        public Nullable<double> Costo { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual TipoEntrega TipoEntrega { get; set; }
    }
}
