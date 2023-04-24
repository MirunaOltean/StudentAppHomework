using StudentAppHomework.DTOs;
using StudentAppHomework.Models;
using System.Security.Claims;

namespace StudentAppHomework.Services
{
    public interface IStudentService
    {
        Task<bool> Update(int id, Student student);
        Task<StudentDto> Get(int id);
        Task<List<StudentDto>> GetAll();
        Task<GradesByStudent> GetCourseGradesForStudent(int studentId, string courseType);
        Task<List<string>> GetClassStudents(int classId);
        Task<Dictionary<int, List<Student>>> GetGroupedStudents();
        Task<List<GradeDto>> GetAllGradesForStudent(string accessToken);
        Task<List<GradesByStudent>> GetAllGradesForAllStudents();
    }
}
