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
  }
}