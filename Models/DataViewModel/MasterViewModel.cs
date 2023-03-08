namespace ArtGalleryApp.Models.DataViewModel
{
    public class MasterViewModel
    {
        private string _messageOfPage="";
        public string ErrorMessagePage = "";
        public string messageOfPage
        {
            get { 
                if(statusOfPage=="success")
                {
                    _messageOfPage = "Save information has been successfully.";
                }
                else
                {
                    _messageOfPage = "";
                }
                return _messageOfPage;
            }
        }
        public string statusOfPage="";
    }
}