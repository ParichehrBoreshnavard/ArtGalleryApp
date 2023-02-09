

using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class UploadFileViewModel
    {
   
        [Display(Name ="Name")]
        public string Title { get; set; }
        
        [Display(Name = "Publish Date")]

        public DateTime? PublishDate { get; set; }
        [Required]
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Produce Date")]
        public DateTime ProduceDate { get; set; }
       
        [Display(Name = "Availability")]
        public bool Availability { get; set; } = false;

        [Display(Name = "Inventory")]
        public int Inventory { get; set; } = 0;
        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Artist name is required.")]
        [Display(Name = "Artist Name")]
        public User Artist_ { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Field")]
        public ArtworkField? ArtworkField_ { get; set; }
        [Required(ErrorMessage = "Style is required.")]
        [Display(Name = "Style")]
        public Style Style_ { get; set; }
        [Required(ErrorMessage = "Medium is required.")]
        [Display(Name = "Medium")]
        public Medium Medium_ { get; set; }
    
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Image File")]
        public string ImgUrl { get; set; }
     
        [Display(Name = "Sold Date")]
        public DateTime SoldDate { get; set; }
    
   
    }
}
