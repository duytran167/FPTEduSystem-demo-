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
  [Authorize(Roles = "trainer")]
  public class TrainerController : Controller
    {
    
    // GET: Trainer
    private ApplicationUser _user;
    private ApplicationDbContext _context;
    private UserManager<ApplicationUser> _usermanager;
    public TrainerController()
    {
      _user = new ApplicationUser();
      _context = new ApplicationDbContext();
      _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    }
    public ActionResult Index()
        {
      var ftrainerId = User.Identity.GetUserId();
      var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == ftrainerId);
      return View(trainer);
    }
    }
}