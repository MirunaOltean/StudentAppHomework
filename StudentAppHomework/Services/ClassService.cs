using Core.Services;
using StudentAppHomework.DBContext;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;

namespace StudentAppHomework.Services
{
    public class ClassService : IClassService
    {
        private readonly UnitOfWork _unitOfWork;


        public ClassService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Class model)
        {
            return await _unitOfWork.Classes.AddClass(model);
        }

        public async Task<ClassViewDto> Get(int id)
        {
            var newClass =  await _unitOfWork.Classes.GetClassById(id);

            return new ClassViewDto()
            {
                Id = id,
                Name = newClass.Name,
                StudentCount = newClass.Students.Count
            };
        }

        public async Task<List<ClassViewDto>> GetAll()
        {
            var classes = await _unitOfWork.Classes.GetAllWithStudentCount();

            return classes.Select(c => new ClassViewDto
            {
                Id = c.Id,
                Name = c.Name,
                StudentCount = c.Students.Count
            }).ToList();
        }
    }
}
