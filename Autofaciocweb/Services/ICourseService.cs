using Autofaciocweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Services
{
    interface ICourseService
    {
        string AddCourse(Course course);
        IEnumerable<Course> GetCourses();
    }
}
