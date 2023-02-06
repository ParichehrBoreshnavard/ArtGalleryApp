using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ContactViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "fULL Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter your message/request here.")]
        [Display(Name = "Message")]
        public string Body { get; set; }
    }
}
