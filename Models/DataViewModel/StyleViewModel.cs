using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class StyleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Art Style:")]
        public string Name { get; set; }
        public List<StyleViewModel> lstStyle { get; set;}
    }
}
