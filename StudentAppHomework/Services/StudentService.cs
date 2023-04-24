using Azure.Core;
using Microsoft.Net.Http.Headers;
using StudentAppHomework.DBContext;
using StudentAppHomework.DTOs;
using StudentAppHomework.Mappings;
using StudentAppHomework.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace StudentAppHomework.Services
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Public Methods

        public async Task<bool> Update(int id, Student student)
        {
            if (student == null || student.FirstName == null || student.LastName == null)
            {
                return false;
            }

            var result = await _unitOfWork.Students.GetStudentById(student.Id);
            if (result == null)
            {
                return false;
            }
            result.FirstName = student.FirstName;
            result.LastName = student.LastName;

            await _unitOfWork.Students.UpdateStudent(result);

            return true;
        }

        public async Task<StudentDto> Get(int id)
        {
            return (await _unitOfWork.Students.GetStudentById(id)).ToStudentDto();
        }

        public async Task<List<StudentDto>> GetAll()
        {
            return (await _unitOfWork.Students.GetAllStudents()).ToStudentDtos();
        }

        public async Task<List<string>> GetClassStudents(int classId)
        {
            return await _unitOfWork.Students.GetClassStudents(classId);
        }

        public async Task<GradesByStudent> GetCourseGradesForStudent(int studentId, string courseType)
        {
            var student = await _unitOfWork.Students.GetCourseGradesForStudent(studentId, courseType);

            return new GradesByStudent(student);
        }

        public async Task<Dictionary<int, List<Student>>> GetGroupedStudents()
        {
            var results = await _unitOfWork.Students.GetGroupedStudents();

            return results;
        }

        public async Task<List<GradeDto>> GetAllGradesForStudent(string accessToken)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new();
            var result = jwtTokenHandler.ReadJwtToken(accessToken.Replace("Bearer ", string.Empty));
            var userId = result.Claims.FirstOrDefault(claim => claim.Type == "userId")?.Value;

            if(userId == null)
            {
                throw new Exception("Error in reading the token!");
            }

            var student = await _unitOfWork.Students.GetStudentById(int.Parse(userId));

            if(student == null)
            {
                return new List<GradeDto>();
            }

            return student.Grades.ToList().ToGradeDtos();
        }

        public async Task<List<GradesByStudent>> GetAllGradesForAllStudents()
        {
            var result = await _unitOfWork.Students.GetAllGradesForAllStudents();

            if (result == null)
            {
                return new List<GradesByStudent>();
            }

            return result;
        }

        #endregion
    }
}
