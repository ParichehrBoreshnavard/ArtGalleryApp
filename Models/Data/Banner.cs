using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Event_? Event_ { get; set; }
        public string? SubDescription { get; set; }
        public DateTime PublishStartDate { get; set; }
        public DateTime? PublishEndDate { get; set; }
        [Required]

        public string ImgUrl { get; set; }
    }
}
