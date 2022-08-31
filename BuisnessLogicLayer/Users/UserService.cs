using Cryptography = BCrypt.Net.BCrypt;

namespace BuisnessLogicLayer.Users
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void RegisterNewUser(NewUser newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException("user");
            }

            if (IsUserExists(newUser.Login))
            {
                throw new InvalidOperationException("User with same login alredy exists.");
            }

            if (IsEmailTaken(newUser.Email))
            {
                throw new InvalidOperationException("Email already taken.");
            }

            User user = new User
            {
                Login = newUser.Login,
                Email = newUser.Email,
                PasswordHash = Cryptography.HashPassword(newUser.Password)
            };

            _repository.Add(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return _repository.GetByLogin(login);
        }

        public IEnumerable<User> Take(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");
            }

            return _repository.Take(count);
        }

        public IEnumerable<User> Take(Range range)
        {
            return _repository.Take(range);
        }

        public int GetId(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User is null.");
            }

            return _repository.GetId(user);
        }

        public bool IsUserExists(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            User owner = _repository.GetByLogin(login);

            return owner != null;
        }

        public bool IsUserExists(string login, out User owner)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            owner = _repository.GetByLogin(login);

            return owner != null;
        }

        public bool IsEmailTaken(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email), "Email is null.");
            }

            User owner = _repository.GetByEmail(email);

            return owner != null;
        }

        public bool IsEmailTaken(string email, out User owner)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            owner = _repository.GetByEmail(email);

            return owner != null;
        }

        public bool Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            }

            User user;

            if (!IsUserExists(login, out user))
            {
                return false;
            }

            return Cryptography.Verify(password, user.PasswordHash);
        }
    }
}
