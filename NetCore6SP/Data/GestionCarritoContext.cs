using Microsoft.EntityFrameworkCore;
using NetCore6SP.Models.Entity;


namespace NetCore6SP.Data
{
    public class GestionCarritoContext : DbContext
    {

        protected readonly IConfiguration Configuration;
        public GestionCarritoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Connection"));
        }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
