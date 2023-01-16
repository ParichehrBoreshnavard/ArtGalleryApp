using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Field
    {
        [Key]
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
