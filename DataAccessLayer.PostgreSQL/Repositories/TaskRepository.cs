using BuisnessLogicLayer.Tasks;

namespace DataAccessLayer.PostgreSQL.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        public void ChangeTaskStatus(int taskId, BuisnessLogicLayer.Tasks.TaskStatus status)
        {
            throw new NotImplementedException();
        }

        public void Create(NewTask newTask)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task task)
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

        public bool IsTaskExists(Task task)
        {
            throw new NotImplementedException();
        }

        public bool IsTaskHasChildren(Task task)
        {
            throw new NotImplementedException();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
