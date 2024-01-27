using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        
        [Unicode(false)]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
