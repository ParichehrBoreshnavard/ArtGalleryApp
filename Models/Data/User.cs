using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string? Description { get; set; }
   
        public string? Country { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? YearOfBirth { get; set; }
       
        public Field? Field_ { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? FullAddress { get; set; }
        public string? PostalCode { get; set; }


        public string? ImgUrl { get; set; }
        
        public string? PortfolioUrl { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }
        public string? State { get; set; }

        public string? UnitNumber { get; set; }
        public Collection<Artwork> Artworks { get; set; }
 
        [Required]
        public Collection<EventUser> EventUsers { get; set; }
        
        public Collection<RoleUser> RoleUsers { get; set; }
        [Required]
        public Collection<TeamMember> TeamMembers { get; set; }

    }
}
