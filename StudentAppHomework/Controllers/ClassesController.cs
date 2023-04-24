using Microsoft.AspNetCore.Mvc;
using StudentAppHomework.Services;

namespace StudentAppHomework.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

    }
}
