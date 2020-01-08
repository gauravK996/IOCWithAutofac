using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public RegStudent RegStudent { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
