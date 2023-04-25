using Microsoft.EntityFrameworkCore;
using StudentAppHomework.DBContext;
using StudentAppHomework.Models;

namespace StudentAppHomework.Repositories
{
    public class ClassRepository : RepositoryBase
    {
        public ClassRepository(StudentAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddClass(Class newCLass)
        {
            var result = _dbContext.Add(newCLass);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id > -1;
        }

        public async Task<Class> GetClassById(int id)
        {
            return await _dbContext.Classes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Class>> GetAllWithStudentCount()
        {
            return await _dbContext.Classes
                .Include(c => c.Students)
                .Select(c => new Class
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
    }
}
