using TestApi.Entities;

namespace TestApi.Services
{
    public interface IUserService
    {
        User GetUser(int userId);
        int? CreateUser(User user);
        int? UpdateUser(User modifiedUser);
        int? DeleteUser(int userId);

    };

    public class UserService : IUserService
    {
        public User GetUser(int userId)
        {
            return new User { 
                Id = userId,
                UserName = "TestUser",
                Password = "Password", 
                CreateTime = DateTime.Now,
                IsAdmin = true,
            };
        }

        public int? CreateUser(User user)
        {
            return user.Id;
        }

        public int? UpdateUser(User modifiedUser)
        {
            var originalUser = GetUser(modifiedUser.Id);

            return modifiedUser.Id;
        }

        public int? DeleteUser(int userId)
        {
            var user = GetUser(userId);

            return user.Id;
        }
    }
}
