using Microsoft.EntityFrameworkCore;

namespace demoTest.Domain
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=demoDB;Integrated Security=True;TrustServerCertificate=True");
        } 
    }
}
