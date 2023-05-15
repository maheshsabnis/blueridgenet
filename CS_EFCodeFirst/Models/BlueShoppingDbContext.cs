using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCodeFirst.Models
{
    public class BlueShoppingDbContext : DbContext
    {
        public BlueShoppingDbContext()
        {
            
        }

        /// <summary>
        /// Defining DbSet Mapping so that Tabless wil be generated and mapped
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Manage Connection String to Database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BlueShopping;Integrated Security=SSPI");
        }

        /// <summary>
        /// Contain Code that will define how the entity class will map to Database Table
        /// There exists a default where each Property of an entity class will map to
        /// the the matched Table olumns
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining UNique
            modelBuilder.Entity<Category>()
                .HasIndex(p=>p.CategoryId).IsUnique();

            modelBuilder.Entity<Product>()
               .HasIndex(p => p.ProductId).IsUnique();

            // Adding One-to-Many Relatioship across
            // Category and Product
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category) // Prouct has One Category (One-to-One)
                        .WithMany(p => p.Products) // One Cateogry has Multiple Products One-to-Many
                        .HasForeignKey(p => p.CatrgoryUniqueId) // The Foreign-Key
                        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
