using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public User User_ { get; set; }
    }
}
