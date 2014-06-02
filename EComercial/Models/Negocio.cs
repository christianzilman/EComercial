using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EComercial.Models
{
    public partial class Negocio
    {
        public Negocio()
        {
            this.Productoes = new List<Producto>();
        }
        
        
        public int NegocioId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la Dirección")]
        public string Direccion { get; set; }
         [Required(ErrorMessage = "Debe Ingresar el CUIT")]
         [RegularExpression(@"\d{2}-\d{7}-\d",
             ErrorMessage = "CUIT INVÁLIDO")]
        public string Cuit { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
