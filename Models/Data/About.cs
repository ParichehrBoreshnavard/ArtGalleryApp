using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? ImgUrl { get; set; }

        public string? Team_ { get; set; }
    }
}