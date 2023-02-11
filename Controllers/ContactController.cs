using ArtGalleryApp.Context;
using Microsoft.AspNetCore.Mvc;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
namespace ArtGalleryApp.Controllers
{
    public class ContactController : AdminMasterController
    {

        public ContactController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        //    public IActionResult Index()
        //    { 

        //    List<ContactViewModel> banners = db.Banners.Select(s => new ContactViewModel
        //    {
        //        Id = s.Id,
        //        Name = s.Name,
        //        Email= s.Email,
        //        Subject = s.Subject,
        //        Body = s.Body
        //        }).ToList();

        //        return View(contact);
        //}


        //[HttpPost]
        //public IActionResult Contact(ContactViewModel contactViewModel)
        //{
        //        //if (!ModelState.IsValid)
        //        //{
        //        //    ViewBag.Error = "There is an error in record information";
        //        //    return View();
        //        //}
        //    Contact newMessage = new Contact ();
        //    dbSarv.Contacts.Add(newMessage);
        //    newMessage.Name = contactViewModel.Name;
        //    newMessage.Email = contactViewModel.Email.ToString();
        //    newMessage.Subject= contactViewModel.Subject;
        //    newMessage.Body = contactViewModel.Body;
        //    Contact contact = new Contact();
        //    dbSarv.Contacts.Add(contact);
        //    dbSarv.SaveChanges();
        //    return Redirect("/AdminContact");

        //}
        public IActionResult Index()
        {
          

            var lst = db.Contacts.Select(c => new ContactViewModel
            {
                Body = c.Body,
                Email = c.Email,
                Id = c.Id,
                Name = c.Name,
                Subject = c.Subject,
                Response = c.Response
            }).ToList();
            return View(lst);

        }
        public IActionResult Delete(int Id)

        {
            var obj = db.Contacts.FirstOrDefault(c => c.Id == Id);
            if (obj != null)
            {
                db.Contacts.Remove(obj);
                db.SaveChanges();
            }
            return Redirect("/Contact");
        }

    }
}
