using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Comprador
    {
        public Comprador()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int CompradorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
