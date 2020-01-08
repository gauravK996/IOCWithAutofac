using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autofaciocweb.Data
{
    public abstract class Nopentityconfig<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
            modelBuilder.ApplyConfiguration(this);
        }


        //protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        //{
        //}
        //public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(this);
        //}

        public abstract void Configure(EntityTypeBuilder<TEntity> builder);
       
}
}
