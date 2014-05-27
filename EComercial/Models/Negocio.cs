using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Negocio
    {
        public Negocio()
        {
            this.Productoes = new List<Producto>();
        }

        public int NegocioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Cuit { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
