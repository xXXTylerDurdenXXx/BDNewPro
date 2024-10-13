using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDNewPro.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shop>().HasData(GetShops());
            base.OnModelCreating(modelBuilder);
        }
        private Product[] GetProducts()
        {
            return new Product[]
            {
                new Product {Id = 1 , Name = "Негр", Description="Черный", Price = 5200.99, Uint = 52 },
                new Product {Id = 2 , Name = "Банан", Description="Жельый", Price = 52.99, Uint = 100 },
                new Product {Id = 3 , Name = "Флаг России", Description="Бело-Сине-Красный", Price = 999.99, Uint = 12}
            };
        }

        private Shop[] GetShops() 
        {
            return new Shop[]
            {
                new Shop {Id = 1 ,Name = "Престиж", Adress= "Комсомольская 12" },
                new Shop {Id = 2 ,Name = "Роза", Adress= "Терешкова 121" },
                 new Shop {Id = 3 ,Name = "Негры Оптом", Adress= "Уральская 8" }
            };
        }

    }
}
