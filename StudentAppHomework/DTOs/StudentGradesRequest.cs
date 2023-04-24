using StudentAppHomework.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentAppHomework.DTOs
{
    public class StudentGradesRequest
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string CourseType { get; set; } = string.Empty;
    }
}
