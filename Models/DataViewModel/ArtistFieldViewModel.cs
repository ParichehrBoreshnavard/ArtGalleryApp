using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ArtistFieldViewModel
    {
    
        public int Id { get; set; }
        [Required]
        [Display(Name ="Artist Field:")]
        public string Name { get; set; }
        public List<ArtistFieldViewModel> lstArtistField { get; set; }
    }
}
