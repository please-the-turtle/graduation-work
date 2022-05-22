namespace BuisnessLogicLayer.Users
{
    public class NewUser
    {
        private string _login = null!;
        private string _email = null!;
        private string _password = null!;

        public NewUser(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }

        public string Email
        {
            get => _email;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }

                _email = value;
            }
        }
        public string Login
        {
            get => _login;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }
                
                _login = value;
            }
            
        }
        public string Password
        {
            get => _password;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }

                _password = value;
            }
        }
    }
}
