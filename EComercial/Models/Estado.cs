using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EComercial.Models
{
    public partial class Estado
    {
        public Estado()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int EstadoId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
