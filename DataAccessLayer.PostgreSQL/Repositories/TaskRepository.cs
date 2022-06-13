using BuisnessLogicLayer.Tasks;

namespace DataAccessLayer.PostgreSQL.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(NewTask newTask)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task task)
        {
            throw new NotImplementedException();
        }

        public Task Get(Task task)
        {
            throw new NotImplementedException();
        }

        public void AssignUserToTask(int userId, int taskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromTask(int userId, int taskId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> GetProjectTasks(int projectId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> GetTaskChildren(Task task)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> GetUsersAssignedToTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> GetUserTasks(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
