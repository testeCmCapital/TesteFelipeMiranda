using CMCapital.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Adicione este using para IConfiguration
using System; // Adicione esta linha

namespace CMCapital.Server.Data
{
    public class DataContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; } 
        public DbSet<Fees> Fees { get; set; }
        public DbSet<Login> Logins { get; set; }   
        public DbSet<SecurityPass> SecurityPass { get; set; }

        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("sqlite");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
