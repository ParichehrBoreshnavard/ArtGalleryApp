using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class TeamController : AdminMasterController
    {
        public TeamController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {

            TeamViewModel teamViewModel = new TeamViewModel();

            teamViewModel.lstTeam = db.Teams.Include(s => s.User_).Select(s => new TeamViewModel
            {
                Id = s.Id,
                ArtistName = s.Title,
                ArtistId =s.User_.Id
            }).ToList();
            teamViewModel.lstArtist= db.Users
                .Include(s => s.RoleUsers)
                .Include(s => s.TeamMembers)
                .Where(s =>!s.TeamMembers.Any(t=>t.User_.Id==s.Id) &&s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
                .Select(s => new CustomSelectList() { Id = s.Id, Name = s.FirstName + " " + s.LastName }).ToList();
            return View(teamViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TeamViewModel model)
        {

            //   if (ModelState.IsValid)
            {
                TeamMember team = new TeamMember();
                db.Teams.Add(team);
                team.User_ = db.Users.First(s => s.Id == model.ArtistId);
                team.Title = team.User_.FirstName+" "+ team.User_.LastName;
               
                db.SaveChanges();
                return Redirect("/Team");

            }
            // return View(bannersViewModel);

        }

        public IActionResult Delete(int Id)
        {
            var remove = db.Teams.FirstOrDefault(s => s.Id == Id);
            if (remove != null)
            {
                db.Teams.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/Team");
        }
    }
}
