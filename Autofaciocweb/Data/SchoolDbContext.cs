using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofaciocweb.Models;
using Microsoft.EntityFrameworkCore;
namespace Autofaciocweb.Data
{
    public class SchoolDbContext:DbContext
    {
        //public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions):base(dbContextOptions)
        //{
        //}
        //public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions) : base(dbContextOptions)
        //{

        //}
        public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions):base(dbContextOptions)
        {
            
            //DbInitilizer.Initialize(schoolDbContext);
        }
        public virtual DbSet<BaseEntity> BaseEntities { get; set; }
        
        //public virtual DbSet<RegStudent> RegStudents { get; set; }
        //public virtual DbSet<Course> Courses { get; set; }
        //public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        //public virtual DbSet<BaseEntity> BaseEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
                //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog = Schooldbforcore; Integrated Security=true");
            //}
        }
        //public new DbSet<T> Set<T>() where T : BaseEntity
        //{
        //    return base.Set<T>();
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //modelBuilder.Entity<RegStudent>().ToTable("RegStudent");
            //modelBuilder.Entity<Course>().ToTable("Course");
            //.Property(p => p.Name)

            //.HasColumnName("Name");
            //modelBuilder.Entity<RegStudent>()
            //    //.HasMany(c => c.)
            //.HasOne<Course>(c => c.CurrentCourse)
            //// .WithMany(g => g.regStudents)
            //// .HasForeignKey(p => p.CourseId);
            //.WithMany(o => o.regStudents)
            //.HasForeignKey<RegStudent>(f => f.CourseId);

            //modelBuilder.Entity<Course>()
            //.HasMany<RegStudent>(r => r.regStudents)
            //.WithOne(o => o.CurrentCourse)
            //.HasForeignKey(f => f.CourseId)
            //.OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<StudentCourse>()
            //    .HasKey(p => new { p.CourseId, p.StudentId });

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne<RegStudent>(s => s.RegStudent)
            //    .WithMany(m => m.studentCourses)
            //    .HasForeignKey(f => f.StudentId)
            //   .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne<Course>(s => s.Course)
            //    .WithMany(m => m.studentCourses)
            //    .HasForeignKey(f => f.CourseId).OnDelete(DeleteBehavior.Restrict);
            //.OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<RegStudent>().HasData(new RegStudent() {Name = "Guarav" });
            //modelBuilder.Entity<Course>().HasData(new Course() {Id=1,Coursename = "MCA" });
            //modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse() { StudentId = 1, CourseId = 1 });

            //        var find = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
            ///*(type.BaseType?.IsGenericType ?? false)*/ type.BaseType.IsInterface && type.BaseType.GetInterface()==typeof(IEntityTypeConfiguration<>));
            //&& (type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
            // return;
            //var find = Assembly.GetExecutingAssembly().GetTypes()
            //     .Where(type => string.IsNullOrEmpty(type.Namespace))
            //     .Where(type => type.BaseType != null && type.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            var find = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
              (type.BaseType?.IsGenericType ?? false)
              && (type.BaseType.GetGenericTypeDefinition() == typeof(Nopentityconfig<>))
            );
            foreach (var v in find)
            {
                
                //dynamic instance = Activator.CreateInstance(v);
                //modelBuilder.ApplyConfiguration(instance);
               // dynamic configuration = Activator.CreateInstance(v);
                var config = (IMappingConfiguration)Activator.CreateInstance(v);
                //configuration.ApplyConfiguration(modelBuilder);
                //modelBuilder.ApplyConfiguration(config);
                config.ApplyConfiguration(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }

        //public string CreateDatabaseScript()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        //    objectContext
        //}

        public string CreateDatabasescri()
        {
            return this.Database.GenerateCreateScript();
           // return this.Database.
        }

        public new DbSet<Tentity> Set<Tentity>() where Tentity : BaseEntity
        {
            return base.Set<Tentity>();
        }


    }
}
