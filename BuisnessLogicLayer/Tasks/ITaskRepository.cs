namespace BuisnessLogicLayer.Tasks
{
    public interface ITaskRepository
    {
        void Create(NewTask newTask);

        void Delete(Task task);

        void Update(Task task);

        bool IsTaskExists(Task task);

        bool IsTaskHasChildren(Task task);

        IQueryable<Task> GetTaskChildren(Task task);

        IQueryable<Task> GetProjectTasks(int projectId);

        IQueryable<Task> GetUserTasks(int userId);

        IQueryable<Task> GetUsersAssignedToTask(int taskId);

        void ChangeTaskStatus(int taskId, TaskStatus status);
    }
}
