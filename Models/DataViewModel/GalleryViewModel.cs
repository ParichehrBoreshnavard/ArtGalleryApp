

using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class GalleryViewModel
    {
   
        [Display(Name ="Name")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Publish Date")]

        public DateTime? PublishDate { get; set; }
        [Required]
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Produce Date")]
        public DateTime ProduceDate { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public bool Availability { get; set; } = false;

        [Required]
        [Display(Name = "Inventory")]
        public int Inventory { get; set; } = 0;
        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public User? Artist_ { get; set; }

        [Required]
        [Display(Name = "Image File")]
        public string ImgUrl { get; set; }
     
        [Display(Name = "Sold Date")]
        public DateTime? SoldDate { get; set; }
    }
}
