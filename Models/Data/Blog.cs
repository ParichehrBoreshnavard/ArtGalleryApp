using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Article { get; set; }
        [Required]
        public DateTime WrittenDate { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string ImgDescription { get; set; }
        [Required]
        public Collection<TagBlog> TagBlogs { get; set; }
    }
}
