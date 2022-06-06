namespace BuisnessLogicLayer.Users
{
    public interface IUserRepository : IDisposable
    {
        void Add(User user);

        void Update(User user);

        /// <summary>
        /// Returns specified number of users from the start. 
        /// </summary>
        /// <param name="count">Count of the returned users.</param>
        /// <returns>Specified number of users from the start.</returns>
        IEnumerable<User> Take(int count);

        IEnumerable<User> Take(Range range);

        User GetByLogin(string login);

        User GetByEmail(string email);

        User GetById(int id);

        /// <summary>
        /// Gets Id by User data.
        /// </summary>
        /// <param name="user">User data.</param>
        /// <returns>User id if user exists or -1 otherwise.</returns>
        int GetId(User user);

        void Delete(int id);
    }
}
