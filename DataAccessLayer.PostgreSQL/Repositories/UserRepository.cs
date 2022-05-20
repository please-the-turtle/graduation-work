using BuisnessLogicLayer.Users;

namespace DataAccessLayer.PostgreSQL.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            _context.Users.Remove(user);

            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id)!;
        }

        public User GetByLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            return _context.Users.FirstOrDefault(u => u.Login == login)!;
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            return _context.Users.FirstOrDefault(u => u.Email == email)!;
        }

        public int GetId(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            User userData = _context.Users.FirstOrDefault(x => x.Id == user.Id)!;

            if (userData == null)
            {
                return -1;
            }

            return userData.Id;
        }

        public IQueryable<User> Take(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");
            }

            return _context.Users.Take(count);
        }

        public IQueryable<User> Take(Range range)
        {
            return _context.Users.Take(range);
        }

        public void Update(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
