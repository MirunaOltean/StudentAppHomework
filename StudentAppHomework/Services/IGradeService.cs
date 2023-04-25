using StudentAppHomework.DTOs;

namespace StudentAppHomework.Services
{
    public interface IGradeService
    {
        Task<bool> AddGrade(AddGradeDto gradeDto);
        Task<Dictionary<string, List<double>>> GetGroupedGradesForStudent(int studentId);
        Task<AverageGradesDto> GetAverageGradesForStudent(int studentId);
    }
}
