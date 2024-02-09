using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int  ResourceID { get; set; }

        [Required]
        [Unicode(false)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Url { get; set; }
        
        public ResourceType ResourseType { get; set; }
        
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}