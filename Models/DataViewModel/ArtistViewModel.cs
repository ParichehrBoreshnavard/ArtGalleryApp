using ArtGalleryApp.Models.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ArtistViewModel
    {
      
        public int Id { get; set; }
        [Required]
        [Display(Name = "Parichehr")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string? Description { get; set; }

        public string? Country { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime YearOfBirth { get; set; }
        [Required]
        public Field? Field_ { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public string? ImgUrl { get; set; }
        [Required]
        public string? PortfolioUrl { get; set; }
     
    }
}

