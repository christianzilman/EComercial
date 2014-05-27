using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class NegocioMap : EntityTypeConfiguration<Negocio>
    {
        public NegocioMap()
        {
            // Primary Key
            this.HasKey(t => t.NegocioId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            this.Property(t => t.Direccion)
                .HasMaxLength(250);

            this.Property(t => t.Cuit)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Negocio");
            this.Property(t => t.NegocioId).HasColumnName("NegocioId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Direccion).HasColumnName("Direccion");
            this.Property(t => t.Cuit).HasColumnName("Cuit");
        }
    }
}
