using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.Data
{
    public class Artists
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string? FirstName { get; set; }
        [Required]
      
        public string? LastName { get; set; }
        [Required]
      
        public string? Description { get; set; }
       public string? Country { get; set; }
        [Required]
       public string? Password { get; set; }
        [Required]
      
        public string? ConfirmPassword { get; set; }
        public DateTime YearOfBirth { get; set; }
        [Required]
       
        public ArtistField? ArtistField_ { get; set; }
        [Required]
       public string? Email { get; set; }
        [Required]
       
        public string? Phone { get; set; }
       
        public string? ImgUrl { get; set; }
        [Required]
        public string? PortfolioUrl { get; set; }
       
    }
}