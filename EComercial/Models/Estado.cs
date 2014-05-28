using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Estado
    {
        public Estado()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
