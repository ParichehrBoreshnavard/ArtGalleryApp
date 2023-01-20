

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace ArtGalleryApp.Models.Data
{
    public class Event_
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AboutDescription { get; set; }
        [Required]
        public string ImgUrlPoster { get; set; }
        [Required]
        public string ImgUrlAbout { get; set; }

        public Collection<SubEvent> SubEvents { get; set; }
        public string UrlTicketStore { get; set; }

        public Collection<EventUser> EventUsers { get; set; }  
    }
}
