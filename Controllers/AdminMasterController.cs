using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.Enum;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminMasterController(dbSarvContext _db, IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {
            db = _db;
            httpContextAccessor = _httpContextAccessor;
            webHostEnvironment = _webHostEnvironment;
            CurrentUserId = httpContextAccessor.HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;

            lstCurrentuserRoles = new List<RoleUser>();
            if (db.Users.Any(s => s.Id == CurrentUserId))
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
            httpContextAccessor.HttpContext.Session.Remove("artGalleryuserid");
            httpContextAccessor.HttpContext.Session.Remove("RoleartGalleryuser");
            //clear seassion
        }
        public void LoginUser(int userid)
        {
            httpContextAccessor.HttpContext.Session.SetInt32("artGalleryuserid", userid);
            //sess[""] = userid;
            //clear seassion
        }
        public string? setRole()
        {

            if (db.Users.Any(s => s.Id == CurrentUserId))
            {

                return lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) ? "Admin" :
                    (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist) ? "Artist" :
                    (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Customer) ? "Customer" : null));
            }
            return null;
          
        }
    }
}
