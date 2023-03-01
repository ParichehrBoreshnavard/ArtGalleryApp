﻿using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class ArtworkField
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Gallery> galleries { get; set; }
    }
}
