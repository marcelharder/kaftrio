using System.Threading.Tasks;
using api.DAL.data;
using api.DAL.helpers;


namespace Cardiohelp.data.Interfaces
{
    public interface IUser
    {
        Task<User> getUserDetails(int id);
        Task<PagedList<User>> GetUsers(UserParams p);
        Task<PagedList<User>> GetUsersPerCenter(UserParams p);
        Task<bool> SaveAll();
        
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Add<T>(T entity) where T : class;
    }
}