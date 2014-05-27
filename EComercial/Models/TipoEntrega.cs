using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class TipoEntrega
    {
        public TipoEntrega()
        {
            this.FormaEntregas = new List<FormaEntrega>();
        }

        public int TipoEntregaId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<FormaEntrega> FormaEntregas { get; set; }
    }
}
