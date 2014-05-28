using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            // Primary Key
            this.HasKey(t => t.EstadoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Estado");
            this.Property(t => t.EstadoId).HasColumnName("EstadoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
