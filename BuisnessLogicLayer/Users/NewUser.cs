namespace BuisnessLogicLayer.Users
{
    public class NewUser
    {
        public NewUser(string login, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            }

            Login = login;
            Email = email;
            Password = password;
        }

        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
