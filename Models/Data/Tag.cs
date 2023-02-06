using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Collection<TagBlog> TagBlogs { get; set; }
        [Required]
        public Collection<TagGallery> TagGallery { get; set; }
    }
}

