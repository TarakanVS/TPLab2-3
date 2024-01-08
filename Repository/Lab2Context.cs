using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository
{
    public class Lab2Context : DbContext
    {
        public Lab2Context(DbContextOptions<Lab2Context> options) : base(options) { AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); }

        public DbSet<Product> Products { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<PromoCodeProduct> PromoCodesProducts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}