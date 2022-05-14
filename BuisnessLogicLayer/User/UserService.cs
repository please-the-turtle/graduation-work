using Cryptography = BCrypt.Net.BCrypt;

namespace BuisnessLogicLayer
{
    public class UserService : IDisposable
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void RegisterNewUser(NewUser newUser)
        {
            if (newUser == null) 
            {
                throw new ArgumentNullException("user"); 
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

        public IQueryable<User> Take(int count)
        {
            return _repository.Take(count);
        }

        public IQueryable<User> Take(Range range)
        {
            return _repository.Take(range);
        }

        public int GetId(User user)
        {
            return _repository.GetId(user);
        }

        public bool IsUserExists(string login)
        {
            User owner = _repository.GetByLogin(login);

            return owner != null;
        }

        public bool IsUserExists(string login, out User owner)
        {
            owner = _repository.GetByLogin(login);

            return owner != null;
        }

        public bool IsEmailTaken(string email)
        {
            User owner = _repository.GetByEmail(email);

            return owner != null;
        }

        public bool IsEmailTaken(string email, out User owner)
        {
            owner = _repository.GetByEmail(email);

            return owner != null;
        }

        public bool Authenticate(string login, string password)
        {
            User user;

            if (!IsUserExists(login, out user))
            {
                return false;
            }

            return Cryptography.Verify(password, user.PasswordHash);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
