namespace BuisnessLogicLayer
{
    public class UserService : IDisposable
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(NewUser newUser)
        {
            if (newUser == null) 
            {
                throw new ArgumentNullException("user"); 
            }

            _repository.Add(newUser);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> Take(int count)
        {
            var users = _repository.Take(count);

            return users;
        }

        public IEnumerable<User> Take(Range range)
        {
            var users = _repository.Take(range);

            return users;
        }

        public int GetId(User user)
        {
            return _repository.GetId(user);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
