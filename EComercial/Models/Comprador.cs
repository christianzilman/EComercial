using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EComercial.Models
{
    public partial class Comprador
    {
        public Comprador()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int CompradorId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
         [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        public string Apellido { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "El e-mail ingresado es inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el teléfono")]
        public string Telefono { get; set; }
        public Nullable<int> UserId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la dirección")]
        public string Direccion { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
