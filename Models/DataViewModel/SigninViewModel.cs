using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SigninViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
