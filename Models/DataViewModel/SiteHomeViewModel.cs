namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteHomeViewModel : SiteMasterViewModel
    {
        public List<BannersUpdateViewModel> lstBanners { get; set; }
        public List<CustomerUpdateViewModel> lstTeam { get; set; }
        public List<GalleryUpdateViewModel> lstGallery { get; set; }
        public AboutViewModel about { get; set; }
    }
}
