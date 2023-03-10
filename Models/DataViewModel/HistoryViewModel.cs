using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class HistoryViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Artist")]
        public string ArtistName { get; set; }
        [Display(Name = "Gallery Image")]
        public string imgurl { get; set; }
        [Display(Name = "Customer")]
        public string customerName { get; set; }
        [Display(Name = "Title")]
        public string galleryTitle { get; set; }
        public int galleryid { get; set; }
        [Display(Name = "Date")]
        public DateTime? soldDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Unit Number")]
        public string unitNumber { get; set; }
        public string State { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string postalCode { get; set; }
        public int customerId { get; set; }
        public int Artistid { get; set; }
        public string ArtWork { get; set; } = "";
        public string style { get; set; } = "";
        public string artistField { get; set; } = "";
        public string Medium { get; set; } = "";
        public string artworkField { get; set; } = "";
        
    }
}