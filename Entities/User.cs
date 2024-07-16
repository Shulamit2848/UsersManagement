namespace UsersManagement.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
    }
}
