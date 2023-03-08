using ArtGalleryApp.Models.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class Event_UpdateViewModel : MasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Name:")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Event Start Date:")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Event End Date:")]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Event Description:")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Event About Description")]
        public string AboutDescription { get; set; }
        [Required]
        [Display(Name = "Poster Image Url Poster Url:")]
        public string ImgUrlPoster { get; set; }
        [Display(Name = "Upload Poster Event Image Url:")]
        public IFormFile? UploadPosterImgUrl { get; set; }
        [Required]
        [Display(Name = "About Event Image Url:")]
        public string ImgUrlAbout { get; set; }
        [Display(Name = "Upload About Event Image Url:")]
        public IFormFile? UploadAboutImgUrl { get; set; }
        [Display(Name = "Sub Event:")]
        public Collection<SubEvent> SubEvents { get; set; }
        [Display(Name = "Event Ticket Store Url:")]
        public string? UrlTicketStore { get; set; }
        [Display(Name = "Event Users:")]
        public Collection<EventUser> EventUsers { get; set; }
        
        
    }
}

