using ArtGalleryApp.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//namespace ArtGalleryApp.Controllers
//{
//    public class SharedController : Controller
//    {
//        private readonly dbSarvContext db;
//        public SharedController(dbSarvContext db)
//        {
//            this.db = db;
//        }
//        [HttpPost]
//        public JsonResult EmailIsNotExist(string Email)
//        {
//            bool result=true;
//            if(db.Users.Any(s=>s.Email==Email)){
//                result=false;
//            }



//            return Json(result);


//        }
//    }
//}
