using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class SubCategoria
    {
        public SubCategoria()
        {
            this.Productoes = new List<Producto>();
        }

        public int SubCategoriaId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
