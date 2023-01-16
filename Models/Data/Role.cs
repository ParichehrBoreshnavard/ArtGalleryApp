using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
