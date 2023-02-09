using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class AboutViewModel
    {
        public int Id { get; set; }
        
        [Display(Name ="Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }
        [Display(Name = "Upload Image")]
        public IFormFile UploadImgUrl { get; set; }
    
   
    }
}
