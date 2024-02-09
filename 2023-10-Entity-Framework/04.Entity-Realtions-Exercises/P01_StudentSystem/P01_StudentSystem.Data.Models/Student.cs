using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Unicode(false)]
        [MaxLength(100)]
        public string Name { get; set;}

        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        public DateTime RegisterOn { get; set; }
        public DateTime Birthday { get; set;}

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
