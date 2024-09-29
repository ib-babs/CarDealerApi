using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealerApi.Models
{
    public class CarItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Manufaturer prop is required")]
        public string Manufacturer { get; set; } = String.Empty;
        [Required(ErrorMessage = "Color prop is required")]
        public string Color { get; set; } = String.Empty;
        [Required(ErrorMessage = "Model prop is required")]
        public string Model { get; set; } = String.Empty;
        [Required(ErrorMessage = "WheelQuantity prop is required")]
        public int WheelQuantity { get; set; }
        [Required(ErrorMessage = "Year prop is required")]
        public int Year { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        [Required(ErrorMessage = "Price prop is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Features prop is required")]
        public string Features { get; set; } = String.Empty;
        [Required(ErrorMessage = "ImagePath prop is required")]
        public string? ImagePath { get; set; }
    }
}
