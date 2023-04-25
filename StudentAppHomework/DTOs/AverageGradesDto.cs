namespace StudentAppHomework.DTOs
{
    public class AverageGradesDto
    {
        public string FullName { get; set; } = string.Empty;
        public Dictionary<string, double> AverageGradePerCourse { get; set; } = new Dictionary<string, double>();
        public double AverageTotalGrade { get; set; }
    }
}
