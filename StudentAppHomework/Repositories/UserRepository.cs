using Microsoft.EntityFrameworkCore;
using StudentAppHomework.DBContext;
using StudentAppHomework.Models;

namespace StudentAppHomework.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(StudentAppContext dbContext) : base(dbContext) { }

        public async Task<bool> AddUser(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _dbContext.Users.Include(e => e.Role).Include(e => e.Student).FirstOrDefaultAsync(s => s.Username == username);
        }
    }
}
