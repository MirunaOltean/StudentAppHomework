using StudentAppHomework.DBContext;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;

namespace StudentAppHomework.Services
{
    public class GradeService : IGradeService
    {
        private readonly UnitOfWork _unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Public Methods

        public async Task<bool> AddGrade(AddGradeDto gradeDto)
        {
            return await _unitOfWork.Grades.AddGrade(gradeDto);
        }

        public async Task<AverageGradesDto> GetAverageGradesForStudent(int studentId)
        {
            var student = await _unitOfWork.Students.GetStudentById(studentId);

            if (student == null)
            {
                return new AverageGradesDto();
            }
            return await _unitOfWork.Grades.GetAverageGradesForStudent(student);
        }

        public async Task<Dictionary<string, List<double>>> GetGroupedGradesForStudent(int studentId)
        {
            var student = await _unitOfWork.Students.GetStudentById(studentId);

            if(student == null)
            {
                return new Dictionary<string, List<double>>();
            }
            return await _unitOfWork.Grades.GetGroupedGradesForStudent(student);
        }
        #endregion
    }
}
