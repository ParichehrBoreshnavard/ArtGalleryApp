using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Artist { get; set; }
        public string Field { get; set; }
        public string Medium { get; set; }
        public string Image { get; set; }
        public string Style { get; set; }
        public Size Size { get; set; }
        public DateTime ProduceYear { get; set; }
        public string Price { get; set;}
        public DateTime AddDate { get; set; }
        public DateTime SoldDate { get; set; }
        [Required]
        public bool Availability { get; set; } = false;
        public DateTime? PublishDate { get; set; }
        [Required]
        public DateTime UploadDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ProduceDate { get; set; }
        public Collection<Field> Fields { get; set; }
        public Collection<Medium> Mediums { get; set; }
        public Collection<Style> Styles { get; set; }
        public Collection<Size> Sizes { get; set; }

        public int Inventory { get; set; } = 0;




    }
}
