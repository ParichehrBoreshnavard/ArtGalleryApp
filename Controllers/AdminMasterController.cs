using ArtGalleryApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class AdminMasterController: Controller
    {
        protected readonly dbSarvContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminMasterController(dbSarvContext _db,IWebHostEnvironment _webHostEnvironment) {
            db = _db;
            webHostEnvironment = _webHostEnvironment;
           
        }
        public async Task<string> UploadImg(IFormFile formFile,string directoryName) {
            string ImgUrl = "";
            string extention=Path.GetExtension(formFile.FileName);
            string filename = directoryName + DateTime.Now.ToString("yymmssfff") + extention;
            string path= Path.Combine(webHostEnvironment.WebRootPath+"/AdminAssessts/"+ directoryName+ "/",filename);
            using(var fileStream= new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
                ImgUrl = "/AdminAssessts/" + directoryName + "/"+filename;
            }
            return ImgUrl;
        }
    }
}
