using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class SubCategoriaMap : EntityTypeConfiguration<SubCategoria>
    {
        public SubCategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.SubCategoriaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SubCategoria");
            this.Property(t => t.SubCategoriaId).HasColumnName("SubCategoriaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");

            // Relationships
            this.HasRequired(t => t.Categoria)
                .WithMany(t => t.SubCategorias)
                .HasForeignKey(d => d.CategoriaId);

        }
    }
}
