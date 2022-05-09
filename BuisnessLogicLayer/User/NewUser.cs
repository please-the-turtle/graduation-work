namespace BuisnessLogicLayer
{
    public class NewUser
    {
        public NewUser(string login, string email, string passwordHash)
        {
            Login = login;
            Email = email;  
            PasswordHash = passwordHash;
        }

        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
