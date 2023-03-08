using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class GalleryViewModel:MasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artwork Name:")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Artwork Name:")]
        public string Subject { get; set; }
        [Required]
        [Display (Name= "Description")]
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Artist:")]

        public string Artist { get; set; }
        [Required]
        [Display(Name = "Artwork Field:")]
        public string ArtworkField { get; set; }
        [Required]
        [Display(Name = "Medium:")]

        public string Medium { get; set; }

        public IFormFile UploadImgUrl { get; set; }
        [Required]
        [Display(Name = "Upload Image")]
        public string ImgUrl { get;  set; }
        [Required]
        [Display(Name = "Style:")]

        public string Style { get; set; }
        [Display(Name = "Size:")]

        public string Size { get; set; }
        [Display(Name = "Produce Year:")]

        public DateTime ProduceYear { get; set; }
        [Required]
        [Display(Name = "Price:")]
        public string Price { get; set; }
        [Display(Name = "Sold Date:")]
        public DateTime? SoldDate { get; set; }
        [Required]

        [Display(Name = "Publish Date:")]
        public DateTime? PublishDate { get; set; }
        [Required]
        [Display(Name = "Upload Date:")]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Produce Date:")]
        public DateTime ProduceDate { get; set; }
        [Display(Name = "Inventory")]
        public int? Inventory { get; set; } = 0;
        public List<ArtworkField> lstArtworkField { get; set; }
        [Display(Name = "Artwork Field:")]
        public int? ArtworkFieldId { get; set; }
        public string ArtworkFieldName { get; set; }
        public List<Style> lstStyle { get; set; }
        [Display(Name = "Artwork Style:")]
        public int? StyleId { get; set; }
        public string StyleName { get; set; }
        [Display(Name = "Artwork Medium:")]
        public List<Medium> lstMedium { get; set; }
        public int? MediumId { get; set; }
        public string MediumName { get; set; }
        [Required]
        [Display(Name = "Artist:")]
        public int artistid { get; set; }
        public List<CustomSelectList> lstArtist { get; set; }
   

    }
}
