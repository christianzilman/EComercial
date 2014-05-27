using System;
using System.Collections.Generic;

namespace EComercial.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            this.SubCategorias = new List<SubCategoria>();
        }

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
    }
}
