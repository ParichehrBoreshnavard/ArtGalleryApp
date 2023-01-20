

using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class RoleUser
    {
        [Key]
        public int Id { get; set; }
        
        public Role Role_ { get; set; }
       
        public User User_ { get; set; }

    }
}
