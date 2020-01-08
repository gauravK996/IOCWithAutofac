using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Models
{
    public class Student : IStudent
    {
        public Student() : this(Guid.NewGuid())
        {

        }
        public Student(Guid id)
        {
            iD = id;
        }
        public static Guid iD { get; set; }
        public string Getsomestring()
        {
            //iD=request

            Random random = new Random();

            return "Hello gaurav Sir " + random.Next(11) + "" + iD;
        }
    }
}
