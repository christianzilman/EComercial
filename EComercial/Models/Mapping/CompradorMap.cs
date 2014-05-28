using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class CompradorMap : EntityTypeConfiguration<Comprador>
    {
        public CompradorMap()
        {
            // Primary Key
            this.HasKey(t => t.CompradorId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            this.Property(t => t.Apellido)
                .HasMaxLength(250);

            this.Property(t => t.Email)
                .HasMaxLength(250);

            this.Property(t => t.Telefono)
                .HasMaxLength(250);

            this.Property(t => t.Direccion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Comprador");
            this.Property(t => t.CompradorId).HasColumnName("CompradorId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Apellido).HasColumnName("Apellido");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefono).HasColumnName("Telefono");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Direccion).HasColumnName("Direccion");
        }
    }
}
