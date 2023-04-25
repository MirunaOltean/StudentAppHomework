using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using StudentAppHomework.DTOs;
using StudentAppHomework.Services;

namespace StudentAppHomework.Controllers
{
    [ApiController]
    [Route("grades")]
    [Authorize]
    public class GradesController: ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        #region Public Methods
        [HttpPost("/add-grade")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddGradeForStudentAtCourse([FromBody] AddGradeDto addGradeDto)
        {
            if(addGradeDto == null)
            {
                return BadRequest("Input is null!");
            }
            var results = await _gradeService.AddGrade(addGradeDto);

            return Ok(results);
        }

        [HttpPost("/grades-by-course/{studentId}")]
        public async Task<IActionResult> GetGroupedGradesForStudent(int studentId)
        {
            if (studentId < -1)
            {
                return BadRequest("Input is not valid!");
            }
            var results = await _gradeService.GetGroupedGradesForStudent(studentId);

            return Ok(results);
        }

        [HttpPost("/average-grades/{studentId}")]
        public async Task<IActionResult> GetAverageGradesForStudent(int studentId)
        {
            if (studentId < -1)
            {
                return BadRequest("Input is not valid!");
            }
            var results = await _gradeService.GetAverageGradesForStudent(studentId);

            return Ok(results);
        }
        #endregion
    }
}
