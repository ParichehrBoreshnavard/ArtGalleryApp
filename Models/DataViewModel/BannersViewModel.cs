using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class BannersViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Banner Name")]
        public string Titel { get; set; }
        [Display(Name = "Description")]
        public string? SubDescription { get; set; }
        [Required]
        [Display(Name = "Publish Start Date")]
        public DateTime PublishStartDate { get; set; }
        [Display(Name = "Publish End Date")]
        public DateTime? PublishEndDate { get; set; }
        [Display(Name = "Upload Image")]
        public IFormFile UploadImgUrl { get; set; }
        
        public string ImgUrl { get; set; }
    }
}
