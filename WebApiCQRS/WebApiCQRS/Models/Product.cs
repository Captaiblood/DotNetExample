using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCQRS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }       
        public Guid UUID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Barcode { get; set; } 
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BuyingPrice { get; set; }
        public string? ConfidentialData { get; set; }
    }
}
