using FPTSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTSystem.ViewModel
{
	public class AssignViewModel
	{
    public string TrainerId { get; set; }
    public string TraineeId { get; set; }
    public Course Course { get; set; }
    public List<TrainerCourse> TrainerCourses { get; set; }
    public List<TraineeCourse> TraineeCourses { get; set; }
    public IEnumerable<Trainee> Trainees { get; set; }
    public IEnumerable<Trainer> Trainers { get; set; }
  }
}