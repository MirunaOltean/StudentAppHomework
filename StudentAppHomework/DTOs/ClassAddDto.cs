using System.ComponentModel.DataAnnotations;

namespace StudentAppHomework.DTOs
{
    public class ClassAddDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
