namespace StudentAppHomework.DTOs
{
    public class AddGradeDto
    {
        public double Value { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public int StudentId { get; set; }
    }
}
