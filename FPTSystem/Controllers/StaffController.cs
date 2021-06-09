using FPTSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTSystem.Controllers
{
  [Authorize(Roles ="staff")]
    public class StaffController : Controller

    {
    private ApplicationUser _user;
    private ApplicationDbContext _context;
    private UserManager<ApplicationUser> _usermanager;
    public StaffController()
    {
      _user = new ApplicationUser();
      _context = new ApplicationDbContext();
      _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    }
    // GET: Staff

    public ActionResult Index()
        {
            return View();
        }
    public ActionResult TraineeManagement(string searchString)
    {

      var trainee = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "4")).ToList();
      if (!String.IsNullOrEmpty(searchString))
      {
        trainee = _context.Users
            .Where(t => t.Roles.Any(r => r.RoleId == "4") && t.UserName.Contains(searchString) == true)
            .ToList();
      }
      return View(trainee);
    }
    public ActionResult DeleteTrainee(string id)
    {
      var removeTrainee = _context.Users.SingleOrDefault(t => t.Id == id);
      _context.Users.Remove(removeTrainee);
      _context.SaveChanges();
      return RedirectToAction("TraineeManagement");
    }
    [HttpGet]
    public ActionResult UpdateTrainee (string id)
		{
      var trainee = _context.Users
               .OfType<Trainee>()
               .SingleOrDefault(t => t.Id == id);
      var updateTrainee = new Trainee()
      {
        Id = trainee.Id,
        Email = trainee.Email,
        UserName = trainee.UserName,
        Age = trainee.Age,
        DateofBirth = trainee.DateofBirth,
        Education = trainee.Education,
        MainProgrammingLang = trainee.MainProgrammingLang,
        ToeicScore = trainee.ToeicScore,
        ExpDetail = trainee.ExpDetail,
        Department = trainee.Department,
        Location = trainee.Location

      };
      return View(updateTrainee);
    }
    [HttpPost]
    public ActionResult UpdateTrainee(Trainee detailsTrainee)
    {
      var traineesearch = _context.Users.OfType<Trainee>().FirstOrDefault(t => t.Id == detailsTrainee.Id);
      traineesearch.UserName = detailsTrainee.UserName;
      traineesearch.Age = detailsTrainee.Age;
      traineesearch.DateofBirth = detailsTrainee.DateofBirth;
      traineesearch.Education = detailsTrainee.Education;
      traineesearch.MainProgrammingLang = detailsTrainee.MainProgrammingLang;
      traineesearch.ToeicScore = detailsTrainee.ToeicScore;
      traineesearch.ExpDetail = detailsTrainee.ExpDetail;
      traineesearch.Department = detailsTrainee.Department;
      traineesearch.Location = detailsTrainee.Location;
      _context.SaveChanges();
      return RedirectToAction("TraineeManagement");
    }
    public ActionResult DetailsTrainee(string id)
    {
      var trainee = _context.Users.SingleOrDefault(t => t.Id == id);
      return View(trainee);
    }

  }
}