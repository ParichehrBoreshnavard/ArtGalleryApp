using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class BlogUpdateViewModel : MasterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Article { get; set; }
        [Required]
        public DateTime WrittenDate { get; set; } = DateTime.Now;
        [Required]
        public string Author { get; set; }
        
        [Display(Name = "Upload Poster")]
        public IFormFile? UploadImgUrl { get; set; }
        public string ImgUrl { get; set; }

        
        [Display(Name = "Upload Blog Image")]
        public IFormFile? UploadDescriptionUrl { get; set; }
        public string ImgDescription { get; set; }
    }
}
