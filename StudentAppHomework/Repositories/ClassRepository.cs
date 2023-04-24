using StudentAppHomework.DBContext;
using StudentAppHomework.Models;

namespace StudentAppHomework.Repositories
{
    public class ClassRepository : RepositoryBase
    {
        public ClassRepository(StudentAppContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> AddClass(Class newCLass)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClass(Class classToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAllClasses()
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudentsForClass(int classId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetClassById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateClass(Class classToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
