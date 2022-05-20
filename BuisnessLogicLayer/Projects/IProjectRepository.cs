using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Projects
{
    public interface IProjectRepository
    {
        void Add(NewProject newProject);

        void Delete(int id);

        void Update(Project project);

        IQueryable<Project> GetUserProjects(int userId);

        UserRoleOnProject GetUserRoleOnProject(int userId, int projectId);

        IQueryable<User> GetProjectUsers(int projectId);
    }
}
