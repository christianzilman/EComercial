using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class DetallePedidoMap : EntityTypeConfiguration<DetallePedido>
    {
        public DetallePedidoMap()
        {
            // Primary Key
            this.HasKey(t => t.DetallePedidoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetallePedido");
            this.Property(t => t.DetallePedidoId).HasColumnName("DetallePedidoId");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.PedidoId).HasColumnName("PedidoId");

            // Relationships
            this.HasRequired(t => t.Pedido)
                .WithMany(t => t.DetallePedidoes)
                .HasForeignKey(d => d.PedidoId);
            this.HasRequired(t => t.Producto)
                .WithMany(t => t.DetallePedidoes)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
