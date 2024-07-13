using AriCoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace AriCoffeeShop.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Kahve> Kahve { get; set; }
        public DbSet<Fotograf> Fotograf { get; set; }
        public DbSet<Kategori> Kategori { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Job>(e => e.Property(a => a.Aciklama).HasColumnName("Description"));
        }


    }
}
