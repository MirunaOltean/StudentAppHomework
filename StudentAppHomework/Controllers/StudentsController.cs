using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;
using StudentAppHomework.Services;
using System.Security.Claims;

namespace StudentAppHomework.Controllers
{
    [ApiController]
    [Route("api/students")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        #region Public Methods 
        [HttpGet("/get-all")]
        public async Task<ActionResult<List<StudentDto>>> GetAll()
        {
            var results = await _studentService.GetAll();

            return Ok(results);
        }

        [HttpGet("/get/{studentId}")]
        public async Task<ActionResult<StudentDto>> GetById(int studentId)
        {
            var result = await _studentService.Get(studentId);

            if (result == null)
            {
                return BadRequest("Student not found");
            }

            return Ok(result);
        }

        [HttpPatch("edit-name")]
        public async Task<ActionResult<bool>> GetById([FromBody] StudentUpdateDto studentUpdateModel)
        {
            Student student = new Student() { 
                FirstName = studentUpdateModel.FirstName, 
                LastName = studentUpdateModel.LastName 
            };

            var result = await _studentService.Update(studentUpdateModel.Id, student);
            
            if (!result)
            {
                return BadRequest("Student could not be updated.");
            }

            return result;
        }

        [HttpPost("grades-by-course")]
        public async Task<ActionResult<GradesByStudent>> Get_CourseGrades_ByStudentId([FromBody] StudentGradesRequest request)
        {
            var result = await _studentService.GetCourseGradesForStudent(request.StudentId, request.CourseType);
            return Ok(result);
        }

        [HttpGet("{classId}/class-students")]
        public async Task<IActionResult> GetClassStudents([FromRoute] int classId)
        {
            var results = await _studentService.GetClassStudents(classId);

            return Ok(results);
        }

        [HttpGet("grouped-students")]
        public async Task<IActionResult> GetGroupedStudents()
        {
            var results = await _studentService.GetGroupedStudents();

            return Ok(results);
        }

        [HttpGet("grades-by-id")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAllGradesForStudent()
        {
            string? accessToken = Request.Headers[HeaderNames.Authorization];
            if(accessToken == null)
            {
                return BadRequest("Token is null");
            }
            var results =  await _studentService.GetAllGradesForStudent(accessToken);

            return Ok(results);
        }

        [HttpGet("grades-by-id-for-all")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllGradesForAllStudents()
        {
            string? accessToken = Request.Headers[HeaderNames.Authorization];
            if (accessToken == null)
            {
                return BadRequest("Token is null");
            }
            var results = await _studentService.GetAllGradesForAllStudents();

            return Ok(results);
        }

        #endregion
    }
}
