﻿using StudentAppHomework.DTOs;
using StudentAppHomework.Models;

namespace StudentAppHomework.Mappings
{
    public static class GradesMapping
    {
        public static List<GradeDto> ToGradeDtos(this List<Grade> grades)
        {
            if (grades == null)
            {
                return null;
            }

            var results = grades.Select(e => e.ToGradeDto()).ToList();

            return results;
        }

        public static GradeDto ToGradeDto(this Grade grade)
        {
            if (grade == null) return null;

            var result = new GradeDto
            {
                Value = grade.Value,
                CourseType = grade.CourseType.Name
            };

            return result;
        }
    }
}
