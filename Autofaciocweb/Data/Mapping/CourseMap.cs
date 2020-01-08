using Autofaciocweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Data.Mapping
{
    public class CourseMap : Nopentityconfig<Course>
    {
        public override  void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
        }
    }
}
