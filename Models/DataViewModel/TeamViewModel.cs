using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Member")]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<CustomSelectList> lstArtist { get; set; }
        public List<TeamViewModel> lstTeam { get; set; }
    }
}
