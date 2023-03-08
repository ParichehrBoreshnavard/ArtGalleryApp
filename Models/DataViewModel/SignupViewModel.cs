using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SignupViewModel : SiteMasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        //[Remote(action:"EmailIsNotExist", controller:"Shared", ErrorMessage = "this emails is already existed.", HttpMethod ="Post")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6)]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$", ErrorMessage = "Use at least 6 character,at least one numbers and one capitals.")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}

