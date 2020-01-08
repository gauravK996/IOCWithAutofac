using Autofaciocweb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Models
{
    public class Course:BaseEntity
    {
        //public string courses() {
        //    return "MCA";
        //}
        //public int CourseId { get; set; }
        public string Coursename { get; set; }
        public ICollection<RegStudent> regStudents { get; set; } 
    }
}
