using ArtGalleryApp.Models.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel

{
 public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string? Description { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string? Country { get; set; }
        [Required]
        [Display(Name = "City")]
        public string? City { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [Required]
        [Display(Name = "Unit Number")]
        public string? UnitNumber { get; set; }
        [Required]
        [Display(Name = "Password")]
        [PasswordPropertyText]
        public string Password { get; set; }
        public DateTime YearOfBirth { get; set; }

        public ArtistField? ArtistField_ { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
      
        public string? ImgUrl { get; set; }

        public string? PortfolioUrl { get; set; }
    }
}
