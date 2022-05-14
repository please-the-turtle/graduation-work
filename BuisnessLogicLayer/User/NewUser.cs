namespace BuisnessLogicLayer
{
    public class NewUser
    {
        public NewUser(string login, string email, string password)
        {
            Login = login;
            Email = email;  
            Password = password;
        }

        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
