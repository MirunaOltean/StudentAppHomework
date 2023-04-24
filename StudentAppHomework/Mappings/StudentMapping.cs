using StudentAppHomework.DTOs;
using StudentAppHomework.Models;

namespace StudentAppHomework.Mappings
{
    public static class StudentMapping
    {
        public static List<StudentDto> ToStudentDtos(this List<Student> students)
        {
            var results = students.Select(e => e.ToStudentDto()).ToList();

            return results;
        }

        public static StudentDto ToStudentDto(this Student student)
        {
            if (student == null) return null;

            var result = new StudentDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                ClassId = student.ClassId,
                ClassName = student.Class.Name,
                Grades = student.Grades.ToList().ToGradeDtos()
            };

            return result;
        }
    }

}
