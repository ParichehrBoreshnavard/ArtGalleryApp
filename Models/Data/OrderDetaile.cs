using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class OrderDetaile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double price { get; set; } = 0;
        [Required]
        public Order order { get; set; }
        [Required]
        public Gallery gallery { get; set; }

        public DateTime orderDateTime { get; set; } = DateTime.Now;

    }
}
