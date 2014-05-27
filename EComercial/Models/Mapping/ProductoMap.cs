using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            this.Property(t => t.Imagen)
                .IsFixedLength()
                .HasMaxLength(8000);

            // Table & Column Mappings
            this.ToTable("Producto");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.PrecioCompra).HasColumnName("PrecioCompra");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.FechaActualizacion).HasColumnName("FechaActualizacion");
            this.Property(t => t.Imagen).HasColumnName("Imagen");
            this.Property(t => t.SubCategoriaId).HasColumnName("SubCategoriaId");
            this.Property(t => t.NegocioId).HasColumnName("NegocioId");
            this.Property(t => t.PrecioVenta).HasColumnName("PrecioVenta");

            // Relationships
            this.HasOptional(t => t.Negocio)
                .WithMany(t => t.Productoes)
                .HasForeignKey(d => d.NegocioId);
            this.HasRequired(t => t.SubCategoria)
                .WithMany(t => t.Productoes)
                .HasForeignKey(d => d.SubCategoriaId);

        }
    }
}
