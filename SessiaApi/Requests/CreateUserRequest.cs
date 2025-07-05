namespace SessiaApi.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
} 