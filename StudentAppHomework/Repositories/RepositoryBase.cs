
using Microsoft.EntityFrameworkCore;
using StudentAppHomework.DBContext;

namespace StudentAppHomework.Repositories
{
    public class RepositoryBase
    {
        protected readonly StudentAppContext _dbContext;

        public RepositoryBase(StudentAppContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
