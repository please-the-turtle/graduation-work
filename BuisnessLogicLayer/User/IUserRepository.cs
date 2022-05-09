namespace BuisnessLogicLayer
{
    public interface IUserRepository : IDisposable
    {
        void Add(NewUser newUser);

        void Update(User user);

        IEnumerable<User> Take(int count);

        IEnumerable<User> Take(Range range);

        User GetById(int id);

        int GetId(User user);

        void Delete(int id);
    }
}
