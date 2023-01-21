using System.Linq;
using System.Threading.Tasks;
using api.DAL;
using api.DAL.data;
using api.DAL.helpers;
using Cardiohelp.data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cardiohelp.data.Implementations
{
    public class UserRepository : IUser
    {
        private dataContext _context;

        public UserRepository(dataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<User> getUserDetails(int id)
        {
             return await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<User>> GetUsers(UserParams p)
        {
            var users = _context.Users.OrderByDescending(u => u.username).AsQueryable();
           // messages = messages.Where(m => m.center_id == p.center_id);
            return await PagedList<User>.CreateAsync(users, p.PageNumber, p.PageSize);
        }
        public async Task<PagedList<User>> GetUsersPerCenter(UserParams p)
        {
            var users = _context.Users.OrderByDescending(u => u.username).AsQueryable();
            users = users.Where(m => m.center_id == p.center_id);
            return await PagedList<User>.CreateAsync(users, p.PageNumber, p.PageSize);
        }

        public async Task<bool> SaveAll()
        {
             return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}