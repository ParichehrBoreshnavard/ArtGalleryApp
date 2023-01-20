using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class TagBlog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Tag Tag_ { get; set; }
        [Required]
        public Blog Blog_ { get; set; }
    }
}
