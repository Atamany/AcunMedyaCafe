using AcunMedyaCafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Context
{
    public class CafeContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YIGITATAMANPC;initial catalog=DbAcunMedyaCafe;integrated Security=true; TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
