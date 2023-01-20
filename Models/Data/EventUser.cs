﻿using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.Data
{
    public class EventUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Event_ Event_ { get; set; }
        [Required]
        public User User_ { get; set; }
       
    }
}
