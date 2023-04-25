using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;
using StudentAppHomework.Services;

namespace StudentAppHomework.Controllers
{
    [ApiController]
    [Route("api/classes")]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Add(ClassAddDto payload)
        {
            Class newClass = new Class() { Name = payload.Name};
            var result = await _classService.Create(newClass);

            if (!result)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<ClassViewDto>>> GetAll()
        {
            var result = await _classService.GetAll();

            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<ClassViewDto>> GetById([FromBody] int id)
        {
            var result = await _classService.Get(id);

            return Ok(result);
        }
    }
}
