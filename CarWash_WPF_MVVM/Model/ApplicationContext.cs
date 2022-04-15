using Microsoft.EntityFrameworkCore;
using CarWash_DB;

namespace CarWash_WPF_MVVM.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Box> Boxes => Set<Box>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarBody> CarBodies => Set<CarBody>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderService> OrderServices => Set<OrderService>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Status> Statuses => Set<Status>();


        public ApplicationContext() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<OrderService>().HasKey(table => new
            {
                table.IdOrder,
                table.IdService
            
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=GURREX\SQLEXPRESS;Database=CarWash;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
