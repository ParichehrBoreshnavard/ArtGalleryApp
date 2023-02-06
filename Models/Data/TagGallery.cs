using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class TagGallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Tag Tag_ { get; set; }
        [Required]
        public Gallery Gallery_ { get; set; }
    }
}
