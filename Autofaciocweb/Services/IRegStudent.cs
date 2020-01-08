using Autofaciocweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Services
{
    interface IRegStudent
    {
        string ADD(RegStudent regStudent);
        int Delete(int Id);
        IList<RegStudent> regStudents();
        RegStudent GetInfo(int Id);
        string Update(RegStudent regStudent);

    }
}
