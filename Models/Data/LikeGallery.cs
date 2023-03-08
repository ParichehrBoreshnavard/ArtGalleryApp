using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGalleryApp.Models.Data
{
    public class LikeGallery
    {
        [Key]
        public int Id { get; set; }
     
        public User? user { get; set; }
        [ForeignKey("user")]
        public int? userId { get; set; }
        [Required]
        public Gallery gallery { get; set; }
        [Required]
        [ForeignKey("gallery")]
        public int galleryId { get; set; }
    }
}