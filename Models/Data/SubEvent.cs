

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class SubEvent
    {
        [Key]
      public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public bool IsTicket { get; set; }=false;
        public string? UrlTicketStore { get; set; }
        public Event_ Events_ { get; set; }
        

    }
}
