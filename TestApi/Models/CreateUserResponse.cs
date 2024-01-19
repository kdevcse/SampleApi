using TestApi.Entities;

namespace TestApi.Models
{
    public class CrudUserResponse : BaseResponse
    {
        public int Id { get; set; }
    }

    public class GetUserResponse : BaseResponse
    {
        public User? User { get; set; }
    }
    public class GetUsersResponse : BaseResponse
    {
        public List<User>? Users { get; set; }
    }
}
