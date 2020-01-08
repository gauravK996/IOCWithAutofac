using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autofaciocweb.Models;
using Autofaciocweb.Data;

namespace Autofaciocweb.Controllers
{
    public class HomeController : Controller
    {
         //SchoolDbContext _schoolDbContext=new SchoolDbContext();
         private readonly SchoolDbContext _schoolDbContext;
        //private IStudent _Student;
        //private ICourse _course;

        //public HomeController(SchoolDbContext schoolDbContext)
        //{
        //    //_Student = student;
        //    //_course = course;
        //    _schoolDbContext = schoolDbContext;
        //}
        public HomeController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {
            var v=_schoolDbContext.Database.EnsureCreated();
            if (v)
            {
                _schoolDbContext.CreateDatabasescri();
            }
            _schoolDbContext.Set<Course>().Add(new Course() {Coursename = "MCA" });
            _schoolDbContext.SaveChanges();
            //_schoolDbContext.BaseEntities
           //DbInitilizer.Initialize(_schoolDbContext);
            //ViewBag.aa = _Student.Getsomestring();
            //ViewBag.bb = _course.courses();
            //var STU=_schoolDbContext.RegStudents.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact(/*[FromServices] ICourse courseE,*/ [FromServices]IStudent studentE)
        {
            //ViewBag.aa = courseE.courses();
            ViewBag.bb = studentE.Getsomestring();
            ViewData["Message"] = "Your contact page.";
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
