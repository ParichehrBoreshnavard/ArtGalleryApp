﻿using ArtGalleryApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class ArtistViewModel
    {
      
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Artist Statement ")]
        [StringLength(500)]
        public string? Description { get; set; }
        [Display(Name = "Country of Origin")]
       
        public string? Country { get; set; }
        [Required]
        [Display(Name = "Password")]
        [PasswordPropertyText]
        
        public string Password { get; set; }
        public DateTime YearOfBirth { get; set; }
        [Required]
        [Display(Name = "Field")]
     
        public Field? Field_ { get; set; }
        [Required(ErrorMessage ="enter an email format")]
        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Artist Image")]
        public string? ImgUrl { get; set; }
        [Required]
        [Display(Name ="Portfolio Link")]
        [Url]
        public string? PortfolioUrl { get; set; }
     
    }
}

