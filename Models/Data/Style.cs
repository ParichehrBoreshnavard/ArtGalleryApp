using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Style
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<Gallery> galleries { get; set; }
       
    }
}
