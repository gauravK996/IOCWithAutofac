using Autofaciocweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Data.Mapping
{
    public class StudentMap : Nopentityconfig<RegStudent>
    {
        public override  void Configure(EntityTypeBuilder<RegStudent> builder)
        {
            builder.ToTable("RegStudent");
        }
    }
}
