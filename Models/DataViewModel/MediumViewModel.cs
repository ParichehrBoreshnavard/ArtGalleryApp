using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class MediumViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Art Medium:")]
        public string Name { get; set; }
        public List<MediumViewModel> lstMedium { get; set; }
    }
}
