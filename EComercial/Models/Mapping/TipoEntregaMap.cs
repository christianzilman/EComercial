using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EComercial.Models.Mapping
{
    public class TipoEntregaMap : EntityTypeConfiguration<TipoEntrega>
    {
        public TipoEntregaMap()
        {
            // Primary Key
            this.HasKey(t => t.TipoEntregaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("TipoEntrega");
            this.Property(t => t.TipoEntregaId).HasColumnName("TipoEntregaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
