using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ArtworkFieldViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artwork Field:")]
        public string Name { get; set; }
        public List<ArtworkFieldViewModel> lstArtworkField { get; set; }
    }
}
