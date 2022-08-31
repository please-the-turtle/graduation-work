using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Tasks
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void Add(NewProjectTask newTask)
        {
            if (newTask is null)
            {
                throw new ArgumentNullException(nameof(newTask));
            }

            _repository.Add(newTask);
        }

        public void Update(ProjectTask task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _repository.Update(task);
        }

        public void Delete(ProjectTask task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _repository.Delete(task);
        }

        public ProjectTask GetById(int taskId)
        {
            if (taskId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(taskId), "Task id must be greater than zero.");
            }

            return _repository.GetById(taskId);
        }

        public void AssignUserToTask(UserAssignedToTask newAssignment)
        {
            if (newAssignment is null)
            {
                throw new ArgumentNullException(nameof(newAssignment));
            }

            _repository.AssignUserToTask(newAssignment);
        }

        public void RemoveUserFromTask(UserAssignedToTask assignmentInfo)
        {
            if (assignmentInfo is null)
            {
                throw new ArgumentNullException(nameof(assignmentInfo));
            }

            _repository.RemoveUserFromTask(assignmentInfo);
        }

        public IEnumerable<ProjectTask> GetProjectTasks(int projectId)
        {
            if (projectId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(projectId), "Project id must be greater than zero.");
            }

            return _repository.GetProjectTasks(projectId);
        }

        public IEnumerable<ProjectTask> GetTaskChildren(int taskId)
        {
            if (taskId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(taskId), "Task id must be greater than zero.");
            }

            return _repository.GetTaskChildren(taskId);
        }

        public IEnumerable<User> GetUsersAssignedToTask(int taskId)
        {
            if (taskId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(taskId), "Task id must be greater than zero.");
            }

            return _repository.GetUsersAssignedToTask(taskId);
        }

        public IEnumerable<ProjectTask> GetUserTasks(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "User id must be greater than zero.");
            }

            return _repository.GetTaskChildren(userId);
        }
    }
}
