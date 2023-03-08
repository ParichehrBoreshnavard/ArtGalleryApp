using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ArtGalleryApp.Controllers
{

    public class Event_Controller : AdminMasterController
    {
        public Event_Controller(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            //read data from Event_ViewModel Then make the information to event_ db in event_ViewModel Format
            //, and read From db and assign information to new list;

            List<Event_ViewModel> event_ = db.Events_.Select(s => new Event_ViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrlAbout = s.ImgUrlAbout,
                ImgUrlPoster = s.ImgUrlPoster,
                Description = s.Description,
                AboutDescription = s.AboutDescription,
                SubEvents = s.SubEvents,
                EndDate = s.EndDate,
                UrlTicketStore = s.UrlTicketStore,
                StartDate = s.StartDate


            }).ToList();

            return View(event_);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            Event_ViewModel event_ViewModel = new Event_ViewModel();
            return View(event_ViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Event_ViewModel event_ViewModel)
        {
            ViewBag.Role = setRole();
            if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            {
                ViewBag.Error = "Image File is mandatory";
                return View(event_ViewModel);
            }
            //   if (ModelState.IsValid)
            {
                Event_ newEvent = new Event_();
                db.Events_.Add(newEvent);
                newEvent.Title = event_ViewModel.Title;
                newEvent.Description = event_ViewModel.Description;
                newEvent.AboutDescription = event_ViewModel.AboutDescription;
                newEvent.SubEvents = event_ViewModel.SubEvents;
                newEvent.UrlTicketStore = event_ViewModel.UrlTicketStore??"";
                newEvent.StartDate = event_ViewModel.StartDate;
                newEvent.EndDate = event_ViewModel.EndDate;
                newEvent.ImgUrlAbout = await UploadImg(event_ViewModel.UploadAboutImgUrl, "Events", "about");
                newEvent.ImgUrlPoster = await UploadImg(event_ViewModel.UploadPosterImgUrl, "Events", "poster");
                db.SaveChanges();
                return Redirect("/Event_");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            Event_UpdateViewModel? event_ = db.Events_.Where(s => s.Id == Id).Select(s => new Event_UpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrlAbout = s.ImgUrlAbout,
                ImgUrlPoster = s.ImgUrlPoster,
                Description = s.Description,
                AboutDescription = s.AboutDescription,
                SubEvents = s.SubEvents,
                EndDate = s.EndDate,
                UrlTicketStore = s.UrlTicketStore,
                StartDate = s.StartDate



            }).ToList().FirstOrDefault();
            if (event_ == null)
                return Redirect("/Event_");

            return View(event_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Event_UpdateViewModel event_ViewModel)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                Event_? newEvent = db.Events_.FirstOrDefault(s => s.Id == event_ViewModel.Id);
                if (newEvent != null)
                {
                    newEvent.Title = event_ViewModel.Title;
                    newEvent.Description = event_ViewModel.Description;
                    newEvent.AboutDescription = event_ViewModel.AboutDescription;
                    newEvent.SubEvents = event_ViewModel.SubEvents;
                    newEvent.UrlTicketStore = event_ViewModel.UrlTicketStore??"";
                    newEvent.StartDate = event_ViewModel.StartDate;
                    newEvent.EndDate = event_ViewModel.EndDate;
                    if (event_ViewModel.UploadAboutImgUrl != null)
                        newEvent.ImgUrlAbout = await UploadImg(event_ViewModel.UploadAboutImgUrl, "Events", "about");
                    if (event_ViewModel.UploadPosterImgUrl != null)
                        newEvent.ImgUrlPoster = await UploadImg(event_ViewModel.UploadPosterImgUrl, "Events", "poster");
                    db.SaveChanges();
                }
                return Redirect("/Event_");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            var remove = db.Events_.First(s => s.Id == Id);
            if (remove != null)
            {
                db.Events_.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/Event_");
        }
    }
}

