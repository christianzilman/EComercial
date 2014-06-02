using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EComercial.Models
{
    public partial class TipoEntrega
    {
        public TipoEntrega()
        {
            this.FormaEntregas = new List<FormaEntrega>();
        }

        public int TipoEntregaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<FormaEntrega> FormaEntregas { get; set; }
    }
}
