using ArtGalleryApp.Models.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SubEvent_ViewModel : MasterViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name:")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Start Date:")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "End Date:")]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Upload Image:")]
        public IFormFile UploadImgUrl { get; set; }
        [Required]
        [Display(Name = "Image Url:")]
        public string ImgUrl { get; set; }

        public List<Event_>? lst_events { get; set; }
        [Display(Name = "Ticket Store Url:")]
        public string? UrlTicketStore { get; set; }
        [Required(ErrorMessage = "select Event")]
        public int eventId { get; set; }
        public string? eventTitle { get; set; }
        
        
    }
}

