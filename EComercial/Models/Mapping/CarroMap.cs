using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            // Primary Key
            this.HasKey(t => t.CarroId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Carro");
            this.Property(t => t.CarroId).HasColumnName("CarroId");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.UserId).HasColumnName("UserId");
          
            // Relationships            
            this.HasRequired(t => t.Producto)
                .WithMany(t => t.Carros)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
