using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EComercial.Models.Mapping;

namespace EComercial.Models
{
    public partial class EComercialContext : DbContext
    {
        static EComercialContext()
        {
            Database.SetInitializer<EComercialContext>(null);
        }

        public EComercialContext()
            : base("Name=EComercialContext")
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Comprador> Compradors { get; set; }
        public DbSet<DetallePedido> DetallePedidoes { get; set; }
        public DbSet<FormaEntrega> FormaEntregas { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Pedido> Pedidoes { get; set; }
        public DbSet<Producto> Productoes { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<TipoEntrega> TipoEntregas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new CompradorMap());
            modelBuilder.Configurations.Add(new DetallePedidoMap());
            modelBuilder.Configurations.Add(new FormaEntregaMap());
            modelBuilder.Configurations.Add(new NegocioMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new SubCategoriaMap());            
        }
    }
}
