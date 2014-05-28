using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Item");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.SubCategoriaId).HasColumnName("SubCategoriaId");

            // Relationships
            this.HasRequired(t => t.SubCategoria)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.SubCategoriaId);

        }
    }
}
