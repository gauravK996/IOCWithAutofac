using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofaciocweb.Data
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);

    }
}
