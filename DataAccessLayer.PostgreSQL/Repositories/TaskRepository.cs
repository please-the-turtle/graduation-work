using BuisnessLogicLayer.Tasks;
using BuisnessLogicLayer.Users;

namespace DataAccessLayer.PostgreSQL.Repositories
{
    internal class TaskRepository : ITaskRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(NewProjectTask newProjectTask)
        {
            if (newProjectTask is null)
            {
                throw new ArgumentNullException(nameof(newProjectTask));
            }

            ProjectTask task = new()
            {
                Name = newProjectTask.Name,
                LeadTime = newProjectTask.LeadTime
            };

            _context.SaveChanges();
        }

        public void Update(ProjectTask task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Update(task);

            _context.SaveChanges();
        }

        public void Delete(ProjectTask task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public ProjectTask GetById(int taskId)
        {
            return _context.Tasks.FirstOrDefault(p => p.Id == taskId)!;
        }

        public void AssignUserToTask(UserAssignedToTask newAssignment)
        {
            if (newAssignment is null)
            {
                throw new ArgumentNullException(nameof(newAssignment));
            }

            _context.UserAssignedToTasks.Add(newAssignment);

            _context.SaveChanges();
        }   

        public void RemoveUserFromTask(UserAssignedToTask assignmentInfo)
        {
            if (assignmentInfo is null)
            {
                throw new ArgumentNullException(nameof(assignmentInfo));
            }

            _context.UserAssignedToTasks.Remove(assignmentInfo);

            _context.SaveChanges();
        }

        public IEnumerable<ProjectTask> GetProjectTasks(int projectId)
        {
            return _context.Tasks.Where(p => p.ProjectId == projectId);
        }

        public IEnumerable<ProjectTask> GetTaskChildren(int taskId)
        {
            return _context.Tasks.Where(p => p.Parent == taskId);
        }

        public IEnumerable<User> GetUsersAssignedToTask(int taskId)
        {
            return _context.Users.Where(
                u => _context.UserAssignedToTasks
                .Where(x => x.TaskId == taskId)
                .Select(t => t.UserId)
                .Contains(u.Id));
        }

        public IEnumerable<ProjectTask> GetUserTasks(int userId)
        {
            return _context.Tasks.Where(
                u => _context.UserAssignedToTasks
                .Where(x => x.UserId == userId)
                .Select(t => t.TaskId)
                .Contains(u.Id));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
