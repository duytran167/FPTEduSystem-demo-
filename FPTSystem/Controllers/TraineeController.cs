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
  [Authorize(Roles = "trainee")]
    public class TraineeController : Controller
    {
    private ApplicationUser _user;
    private ApplicationDbContext _context;
    private UserManager<ApplicationUser> _usermanager;
     public TraineeController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        // GET: Trainee
        public ActionResult Index()
        {
      var ftraineeId = User.Identity.GetUserId();
      var trainee = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == ftraineeId);
      return View(trainee);
    }
    }
}