using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class FormaEntregaMap : EntityTypeConfiguration<FormaEntrega>
    {
        public FormaEntregaMap()
        {
            // Primary Key
            this.HasKey(t => t.FormaEntregaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("FormaEntrega");
            this.Property(t => t.FormaEntregaId).HasColumnName("FormaEntregaId");
            this.Property(t => t.TipoEntregaId).HasColumnName("TipoEntregaId");
            this.Property(t => t.Costo).HasColumnName("Costo");
            this.Property(t => t.PedidoId).HasColumnName("PedidoId");

            // Relationships
            this.HasRequired(t => t.Pedido)
                .WithMany(t => t.FormaEntregas)
                .HasForeignKey(d => d.PedidoId);
            this.HasOptional(t => t.TipoEntrega)
                .WithMany(t => t.FormaEntregas)
                .HasForeignKey(d => d.TipoEntregaId);

        }
    }
}
