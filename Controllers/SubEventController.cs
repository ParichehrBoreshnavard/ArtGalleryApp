using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class SubEventController : AdminMasterController
    {
        public SubEventController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
            //read data from Event_ViewModel Then make the information to event_ db in event_ViewModel Format
            //, and read From db and assign information to new list;

            List<SubEvent_UpdateViewModel> lst = db.SubEvents.Include(s => s.Events_).Select(s => new SubEvent_UpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrl = s.ImgUrl,
                eventId = s.Events_.Id,
                Description = s.Description,
                eventTitle = s.Events_.Title,
                EndDate = (s.EndDate.HasValue?s.EndDate.Value:DateTime.Now),
                UrlTicketStore = s.UrlTicketStore,
                StartDate = (s.StartDate.HasValue?s.StartDate.Value:DateTime.Now)


            }).ToList();

            return View(lst);
        }
        public IActionResult New()
        {
            SubEvent_ViewModel obj = new SubEvent_ViewModel();
            obj.lst_events = db.Events_.ToList();
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(SubEvent_ViewModel model)
        {
            if (model.UploadImgUrl == null)
            {
                model.statusOfPage = "error";
                model.ErrorMessagePage = "Image File is mandatory";
                return View(model);
            }
            //   if (ModelState.IsValid)
            {
                SubEvent obj = new SubEvent();

                db.SubEvents.Add(obj);
                obj.Title = model.Title;
                obj.Description = model.Description;
                obj.Events_ = db.Events_.First(s => s.Id == model.eventId);
                obj.IsTicket = !string.IsNullOrEmpty(model.UrlTicketStore);
                obj.UrlTicketStore = model.UrlTicketStore;
                obj.StartDate = model.StartDate;
                obj.EndDate = model.EndDate;
                obj.ImgUrl = await UploadImg(model.UploadImgUrl, "SubEvents", "SubEvent");

                db.SaveChanges();


            }
            return Redirect("/SubEvent");
            // return View(event_ViewModel);

        }
        public IActionResult Update(int Id)
        {
            SubEvent_UpdateViewModel? obj = db.SubEvents.Include(s => s.Events_).Where(s => s.Id == Id).Select(s => new SubEvent_UpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrl = s.ImgUrl,
                eventId = s.Events_.Id,
                Description = s.Description,
                eventTitle = s.Events_.Title,
                EndDate = (s.EndDate.HasValue ? s.EndDate.Value : DateTime.Now),
                UrlTicketStore = s.UrlTicketStore,
                StartDate = (s.StartDate.HasValue ? s.StartDate.Value : DateTime.Now)


            }).ToList().FirstOrDefault();
            if (obj == null)
                return Redirect("/SubEvent");
            obj.lst_events = db.Events_.ToList();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SubEvent_UpdateViewModel model)
        {

            //   if (ModelState.IsValid)
            {
                SubEvent? obj = db.SubEvents.FirstOrDefault(s => s.Id == model.Id);
                if (obj != null)
                {
                    obj.Title = model.Title;
                    obj.Description = model.Description;
                    obj.Events_ = db.Events_.First(s => s.Id == model.eventId);
                    obj.IsTicket = !string.IsNullOrEmpty(model.UrlTicketStore);
                    obj.UrlTicketStore = model.UrlTicketStore;
                    obj.StartDate = model.StartDate;
                    obj.EndDate = model.EndDate;
                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "SubEvents", "SubEvent");

                    db.SaveChanges();
                }
                return Redirect("/SubEvent");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Delete(int Id)
        {
            var remove = db.SubEvents.First(s => s.Id == Id);
            if (remove != null)
            {
                db.SubEvents.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/SubEvent");
        }
    }
}
