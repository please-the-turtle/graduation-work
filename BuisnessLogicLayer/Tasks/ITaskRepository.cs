using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Tasks
{
    public interface ITaskRepository
    {
        void Add(NewProjectTask newTask);

        void Delete(ProjectTask task);

        void Update(ProjectTask task);

        ProjectTask GetById(int taskId);

        void AssignUserToTask(UserAssignedToTask newAssignment);

        void RemoveUserFromTask(UserAssignedToTask assignmentInfo);

        IEnumerable<ProjectTask> GetTaskChildren(int taskId);

        IEnumerable<ProjectTask> GetProjectTasks(int projectId);

        IEnumerable<ProjectTask> GetUserTasks(int userId);

        IEnumerable<User> GetUsersAssignedToTask(int taskId);
    }
}
