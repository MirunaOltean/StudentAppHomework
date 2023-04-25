using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using StudentAppHomework.DBContext;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;
using User = StudentAppHomework.Models.User;

namespace StudentAppHomework.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(StudentAppContext dbContext) : base(dbContext) { }

        #region Public Methods
        public async Task<bool> AddUser(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByUsername(string username)
        {
            var user =  await _dbContext.Users.Include(e => e.Role).Include(e => e.Student).FirstOrDefaultAsync(s => s.Username == username);
        
            if(user == null)
            {
                return new User();
            }
            return user;
        }

        public async Task<Dictionary<string, List<UserDto>>> GetAllByRole()
        {
            return await _dbContext.Users
                .GroupBy(e => e.Role.Name)
                .Select(e => new
                {
                    Name = e.Key,
                    Users = e
                     .Select(e => new UserDto()
                     {
                         Username = e.Username
                     }).ToList()
                })
                .ToDictionaryAsync(e => e.Name, e => e.Users);
        }
        #endregion
    }
}
