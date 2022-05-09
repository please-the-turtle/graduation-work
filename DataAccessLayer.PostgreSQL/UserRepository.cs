using BuisnessLogicLayer;

namespace DataAccessLayer.PostgreSQL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(NewUser newUser)
        {
            User user = new User
            {
                Login = newUser.Login,
                PasswordHash = newUser.PasswordHash,
                Email = newUser.Email
            };

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
            User user = _context.Users.Find(id)!;

            return user;
        }

        public int GetId(User user)
        {
            int id = _context.Users.FirstOrDefault(x => x.Id == user.Id)!.Id;

            return id;
        }

        public IEnumerable<User> Take(int count)
        {
            IEnumerable<User> users = _context.Users.Take(count);

            return users;
        }

        public IEnumerable<User> Take(Range range)
        {
            IEnumerable<User> users = _context.Users.Take(range);

            return users;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
