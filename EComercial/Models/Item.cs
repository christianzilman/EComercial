using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EComercial.Models
{
    public partial class Item
    {
        public Item()
        {
            this.Productoes = new List<Producto>();
        }

        public int ItemId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la SubCategoria")]
        public int SubCategoriaId { get; set; }
        
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
