using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Projects
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public void Add(NewProject newProject)
        {
            if (newProject is null)
            {
                throw new ArgumentNullException(nameof(newProject), "NewProject is null.");
            }

            _repository.Add(newProject);
        }

        public void AssignUserOnProject(UserRoleOnProject userRoleOnProject)
        {
            if (userRoleOnProject is null)
            {
                throw new ArgumentNullException(nameof(userRoleOnProject));
            }

            _repository.AssignUserToProject(userRoleOnProject);
        }

        public void ChangeUserRoleOnProject(UserRoleOnProject newUserRoleOnProject)
        {
            if (newUserRoleOnProject is null)
            {
                throw new ArgumentNullException(nameof(newUserRoleOnProject));
            }

            _repository.ChangeUserRoleOnProject(newUserRoleOnProject);
        }

        public void RemoveUserFromProject(UserRoleOnProject userRoleOnProjectToRemove)
        {
            if (userRoleOnProjectToRemove is null)
            {
                throw new ArgumentNullException(nameof(userRoleOnProjectToRemove));
            }

            _repository.RemoveUserFromProject(userRoleOnProjectToRemove);
        }

        public void Update(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project), "Project is null.");
            }

            if (!_repository.IsProjectExists(project.Id))
            {
                throw new InvalidOperationException("Project not exists.");
            }

            _repository.Update(project);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Project id must be greater than zero.");
            }

            _repository.Delete(id);
        }

        public IQueryable<Project> GetUserProjects(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "User id must be greater than zero.");
            }

            return _repository.GetUserProjects(userId);
        }

        public IQueryable<User> GetProjectUsers(int projectId)
        {
            if (projectId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(projectId), "Project id must be greater than zero.");
            }

            return _repository.GetProjectUsers(projectId);
        }

        /// <summary>
        /// Get role of specific user on project.
        /// </summary>
        /// <param name="userId">Id of a specific user.</param>
        /// <param name="projectId">Id of a specific project.</param>
        /// <returns>UserOnProject instance if user assigned to project or null.</returns>
        public UserRoleOnProject GetUserRoleOnProject(int userId, int projectId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "Project id must be greater than zero.");
            }

            if (projectId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(projectId), "Project id must be greater than zero.");
            }

            return _repository.GetUserRoleOnProject(userId, projectId);
        }

        public IQueryable<UserRole> GetUserRoles()
        {
            return _repository.GetAllUserRoles();
        }
    }
}
