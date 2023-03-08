using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class AdminMasterController : Controller
    {
        protected readonly dbSarvContext db;
        protected int CurrentUserId = 1;
        protected List<RoleUser> lstCurrentuserRoles ;


        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminMasterController(dbSarvContext _db, IWebHostEnvironment _webHostEnvironment)
        {
            db = _db;
            webHostEnvironment = _webHostEnvironment;
            //CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 1;
            lstCurrentuserRoles = new List<RoleUser>();
            if ( db.Users.Any(s => s.Id == CurrentUserId))
            {
                lstCurrentuserRoles = db.RoleUser
                    .Include(s => s.Role_)
                    .Where(s => s.User_.Id == CurrentUserId).ToList();
            }
        }
        public async Task<string> UploadImg(IFormFile formFile, string directoryName, string name = "")
        {
            
            string ImgUrl = "";
            string extention = Path.GetExtension(formFile.FileName);
            string filename = directoryName + name + DateTime.Now.ToString("yymmssfff") + extention;
            string path = Path.Combine(webHostEnvironment.WebRootPath + "/AdminAssessts/" + directoryName + "/", filename);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
                ImgUrl = "/AdminAssessts/" + directoryName + "/" + filename;
            }
            return ImgUrl;
        }
        public void LogoutUser()
        {
            HttpContext.Session.Remove("artGalleryuserid");
            //clear seassion
        }
        public void LoginUser(int userid)
        {
            HttpContext.Session.SetInt32("artGalleryuserid", userid);
            //sess[""] = userid;
            //clear seassion
        }
    }
}
