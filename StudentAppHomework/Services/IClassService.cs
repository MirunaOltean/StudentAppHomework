using StudentAppHomework.DTOs;
using StudentAppHomework.Models;

namespace StudentAppHomework.Services
{
    public interface IClassService
    {
        Task<bool> Create(Class newClass);
        Task<ClassViewDto> Get(int id);
        Task<List<ClassViewDto>> GetAll();
    }
}
