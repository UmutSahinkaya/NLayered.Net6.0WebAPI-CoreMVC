using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Seed Tarafından yaptıklarım buradan da yapılabilir fakat buradaki kod kalabalıgını azaltmak için Seeds oluşturduk.
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature
                {
                    Id = 1,
                    Color = "Kırmızı",
                    Height=100,
                    Width=200,
                    ProductId=1,
                }, new ProductFeature
                {
                    Id = 2,
                    Color = "Sarı",
                    Height = 300,
                    Width = 350,
                    ProductId = 2,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
