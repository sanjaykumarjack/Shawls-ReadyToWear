using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Shawls_ReadyToWear.Models
{
    public class Shawl
    {
        public int Id { get; set; }
        public string? Title { get; set; }
     
        public string? Material { get; set; }

        public string? Colour { get; set; }
        public string? Size { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

