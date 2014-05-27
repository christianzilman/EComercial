using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoriaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Categoria");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
