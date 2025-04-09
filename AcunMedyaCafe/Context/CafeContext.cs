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
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
