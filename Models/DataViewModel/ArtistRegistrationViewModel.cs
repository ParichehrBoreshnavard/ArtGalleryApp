using ArtGalleryApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ArtistRegistrationViewModel:SiteMasterViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Artist Statement ")]
        [StringLength(500)]
        public string? Description { get; set; }
        [Display(Name = "Country of Origin")]

        public string? Country { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6)]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$", ErrorMessage = "Use at least 6 character,at least one numbers and one capitals.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public DateTime? YearOfBirth { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        //[Remote(action: "EmailIsNotExist", controller: "Shared", ErrorMessage = "this emails is already existed.", HttpMethod = "Post")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string? Phone { get; set; }
        [Display(Name = "Artist Image")]
        public string? ImgUrl { get; set; }

        [Display(Name = "Portfolio Link")]
        public string? PortfolioUrl { get; set; }
        [Display(Name = "Upload Photo")]
        public IFormFile UploadImgUrl { get; set; }
        public List<ArtistField>? lstArtistField { get; set; }

        [Required]
        [Display(Name = "Artist Field")]
        public int? ArtistFieldId { get; set; }
        public string? ArtistFieldName { get; set; }

    }
}
