namespace TestApi.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public required string UserName { get; set; }
        public required string Password {  get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsAdmin { get; set; }
    }
}
