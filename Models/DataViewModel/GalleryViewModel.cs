using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class GalleryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artwork Name:")]

        public string Title { get; set; }
        [Required]
        [Display (Name="Statement")]
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
        [Required]
        [Display(Name = "Imsge File")]
        [FileExtensions]
        public string ImgUrl { get; internal set; }
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
        [Display(Name = "Produce Year:")]
        public DateTime? SoldDate { get; set; }
        [Required]
        [Display(Name = "Produce Year:")]
        public bool Availability { get; set; } = false;
        [Display(Name = "Produce Year:")]
        public DateTime? PublishDate { get; set; }
        [Required]
        [Display(Name = "Produce Year:")]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Produce Year:")]
        public DateTime ProduceDate { get; set; }
        [Display(Name = "Produce Year:")]
        public int? Inventory { get; set; } = 0;
       
    }
}
