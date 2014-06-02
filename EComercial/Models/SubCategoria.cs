using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EComercial.Models
{
    public partial class SubCategoria
    {
        public SubCategoria()
        {
            this.Items = new List<Item>();
        }

        public int SubCategoriaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
