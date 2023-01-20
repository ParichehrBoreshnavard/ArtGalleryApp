using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ArtGalleryApp.Models.Data
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        
        public DateTime? PublishDate { get; set; }
        [Required]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ProduceDate { get; set; }
        [Required]
        public bool Availability { get; set; } = false;
        [Required]
        public string Description { get; set; }
        [Required]
        public double price { get; set; }
        public User? Artist_ { get; set; }
        public string ImgUrl { get; set; }
        public Collection<Field> Fields { get; set; }
        public Collection<Medium> Mediums { get; set; }
        public Collection<Style> Styles { get; set; }
        public Collection<Size> Sizes { get; set; }
    }
}

