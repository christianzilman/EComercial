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
       /*  [RegularExpression( ,
            ErrorMessage = "CUIT INVÁLIDO")]*/
        /*[RegularExpression( [0-9]{1,9}(\.[0-9]{0,2})?$, ErrorMessage = "E-mail Inválido")]*/
       
        /*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* */
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
