namespace StudentAppHomework.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
    }
}
