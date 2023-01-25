using ArtGalleryApp.Models.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Position")]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Country { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        public DateTime YearOfBirth { get; set; }

        public Field? Field_ { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Image file")]
        public string? ImgUrl { get; set; }
        [Required]
        [Display(Name = "Resume file")]
        public string? PortfolioUrl { get; set; }
    }
}
