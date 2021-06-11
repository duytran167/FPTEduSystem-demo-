﻿using FPTSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
      var staff = User.Identity.GetUserId();
      var viewstaff = _context.Users.OfType<Staff>().SingleOrDefault(t => t.Id == staff);
      return View(viewstaff);
    }

   //trainee manage
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
    //trainer manage
    public ActionResult TrainerManagement(string searchString)
    {

      var trainer = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "3")).ToList();
      if (!String.IsNullOrEmpty(searchString))
      {
        trainer = _context.Users
            .Where(t => t.Roles.Any(r => r.RoleId == "3") && t.UserName.Contains(searchString) == true)
            .ToList();
      }
      return View(trainer);
    }
    [HttpGet]
    public ActionResult UpdateTrainer(string id)
    {
      var trainer = _context.Users
               .OfType<Trainer>()
               .SingleOrDefault(t => t.Id == id);
      var updateTrainer = new Trainer()
      {
        Id = trainer.Id,
        Email = trainer.Email,
        UserName = trainer.UserName,
        Education = trainer.Education,
        WorkPlace = trainer.WorkPlace,
        Telephone = trainer.Telephone,
        Type = trainer.Type

      };
      return View(updateTrainer);
    }
    [HttpPost]
    public ActionResult UpdateTrainer(Trainer detailsTrainer)
    {
      var traineesearch = _context.Users.OfType<Trainer>().FirstOrDefault(t => t.Id == detailsTrainer.Id);
      traineesearch.UserName = detailsTrainer.UserName;
      traineesearch.Education = detailsTrainer.Education;
      traineesearch.WorkPlace = detailsTrainer.WorkPlace;
      traineesearch.Telephone = detailsTrainer.Telephone;
      traineesearch.Type = detailsTrainer.Type;
      _context.SaveChanges();
      return RedirectToAction("TraineeManagement");
    }
    public ActionResult DetailsTrainer(string id)
    {
      var trainer = _context.Users.SingleOrDefault(t => t.Id == id);
      return View(trainer);
    }
    //course manage
    public ActionResult CourseManagement(string searchString)
    {
      var courses = _context.Courses.Include(t => t.Category).ToList();
      if (!String.IsNullOrWhiteSpace(searchString))
      {
        courses = _context.Courses
        .Where(t => t.CourseName.Contains(searchString))
        .Include(t => t.Category)
        .ToList();
      }
      return View(courses);
    }
    public ActionResult CategoryView(string searchString)
    {
      var categories = _context.Categories.ToList();
      if (!String.IsNullOrWhiteSpace(searchString))
      {
        categories = _context.Categories
       .Where(t => t.CategoryName.Contains(searchString))
       .ToList();
      }
      return View(categories);
    }
    [HttpGet]
    public ActionResult CreateCategory()
    {
      return View();
    }
    [HttpPost]
    public ActionResult CreateCategory(Category category)
    {
      var create_category = new Category() { CategoryName = category.CategoryName };
      _context.Categories.Add(create_category);
      _context.SaveChanges();
      return RedirectToAction("CategoryView");
    }
    public ActionResult DeleteCategory(int id)
    {
      var removeCategory = _context.Categories.SingleOrDefault(t => t.Id == id);
      _context.Categories.Remove(removeCategory);
      _context.SaveChanges();
      return RedirectToAction("CategoryView");
    }

  }
}