using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public User Artist { get; set; }
        public  ArtworkField artworkField { get; set; }
        public Medium medium { get; set; }
        public string Image { get; set; }
        public Style  style{ get; set; }
        public string Size { get; set; }
        public DateTime ProduceYear { get; set; }
        public string Price { get; set;}
        public DateTime SoldDate { get; set; }
        [Required]
        public bool Availability { get; set; } = false;
        public DateTime? PublishDate { get; set; }
        [Required]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ProduceDate { get; set; }
     
        public int Inventory { get; set; } = 0;
     
        public string ImgUrl { get; internal set; }
        public ICollection<LikeGallery> likeGalleries { get; set; }

        public ICollection<OrderDetaile> OrderDetailes { get; set; }

    }
}
