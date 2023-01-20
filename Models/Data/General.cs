using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class General
    {
        [Key]
        public int AboutId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public DateTime CreateDate { get; set;}
        [Required]
        public DateTime UpdateDate { get; set;}

    }
}
