using Microsoft.EntityFrameworkCore;
using TestApi.Contexts;
using TestApi.Entities;

namespace TestApi.Services
{
    public interface IUserService
    {
        Task<User?> GetUser(int userId);
        Task<int?> CreateUser(User user);
        Task<int?> UpdateUser(User modifiedUser);
        Task<int?> DeleteUser(int userId);
    };

    public class UserService : IUserService
    {
        private UserContext _userContext;
        public UserService(UserContext userContext) {
            _userContext = userContext;
        }
        public async Task<List<User>?> GetUsers()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int userId)
        {
            return await _userContext.Users.FindAsync(userId);
        }

        public async Task<int?> CreateUser(User user)
        {
            try
            {
                _userContext.Users.Add(user);
                await _userContext.SaveChangesAsync();
                return user.Id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int?> UpdateUser(User modifiedUser)
        {
            try
            {
                _userContext.Entry(modifiedUser).State = EntityState.Modified;
                await _userContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return modifiedUser.Id;
        }

        public async Task<int?> DeleteUser(int userId)
        {
            try
            {
                var user = await GetUser(userId);

                if (user == null)
                {
                    return null;
                }

                _userContext.Users.Remove(user);
                await _userContext.SaveChangesAsync();
                return user.Id;
            }
            catch
            {
                return null;
            }
        }
    }
}
