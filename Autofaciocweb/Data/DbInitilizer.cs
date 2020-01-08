using Autofaciocweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Data
{
    public static class DbInitilizer
    {

        public static void Initialize(SchoolDbContext context)
        {
            //if (context.RegStudents.Any())
            //{
            //    return;

            //}
            var course = new List<Course>()
            {
                new Course(){Coursename="MCA" }

            };
            var Students = new RegStudent[]
                {
                    new RegStudent(){ Name="Gaurav"}
                    //new RegStudent() {Name="gauarv",CourseId=1 },
                    //new RegStudent() {Name="gauarvkumaya",CourseId=1 },
                    //new RegStudent() {Name="sanju",CourseId=1 }
                };
            context.AddRange(Students);
            context.AddRange(course);
            context.SaveChanges();
        }
    }
}
