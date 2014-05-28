using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Item
    {
        public Item()
        {
            this.Productoes = new List<Producto>();
        }

        public int ItemId { get; set; }
        public string Nombre { get; set; }
        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
