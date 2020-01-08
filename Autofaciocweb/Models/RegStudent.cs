using Autofaciocweb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autofaciocweb.Models
{ 
    [Table("RegStudent")]
    public class RegStudent:BaseEntity
    {
        //public int Id { get; set; }
        //[Key]
        [Column("name",Order =2)]
        [MaxLength(20)]
        [MinLength(12)]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [NotMapped]
        public int? age { get; set; }
        [ForeignKey("CurrentCourse")]
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course CurrentCourse { get; set; }
        //public IList<StudentCourse> studentCourses { get; set; }
    }
}
