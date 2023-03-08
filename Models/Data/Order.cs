using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public User? user { get; set; }

        public double orderPrice { get; set; } = 0;
        public DateTime? buyDate { get; set; }

        public string? PortfolioUrl { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }
        public string? State { get; set; }

        public string? UnitNumber { get; set; }

        public bool isBuy { get; set; } = false;
        public Collection<OrderDetaile> OrderDetailes { get; set; }
    }
}
