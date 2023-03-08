using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class BannersUpdateViewModel:MasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Banner Name")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string? SubDescription { get; set; }
        [Required]
        [Display(Name = "Publish Start Date")]
        public DateTime PublishStartDate { get; set; }=DateTime.Now;
        [Display(Name = "Publish End Date")]
        public DateTime? PublishEndDate { get; set; }
        [Display(Name = "Upload Image")]
        public IFormFile? UploadImgUrl { get; set; }
        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }

        public List<Event_>? lstEvent { get; set; } = null;
        [Display(Name ="Event:")]
        public int? EventId { get; set; }
        public string? EventTitle { get; set; }
    }
}
