using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS_EFCodeFirst.Models
{
    public class Category
    {
        [Key] // Primary Identity Key
        public int CatrgoryUniqueId { get; set; }
        [Required]
        [StringLength(200)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string? CategorName { get; set; }
        [Required]
        [StringLength(200)]
        public string? Manufacturere { get; set; }
        public int BasePrice { get; set; }
        // One-to-Many Relationship
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        [Key] // Primary Identity Key
        public int ProductUniqueId { get; set; }
        [Required]
        [StringLength(200)]
        public string? ProductId { get; set; }
        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int CatrgoryUniqueId { get; set; } // Expected as Foreign Key
        public Category? Category { get; set; } // Expected to be a REferential Integrity

    }
}
