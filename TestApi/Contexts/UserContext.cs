using Microsoft.EntityFrameworkCore;
using TestApi.Entities;

namespace TestApi.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
