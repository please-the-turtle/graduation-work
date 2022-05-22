﻿using BuisnessLogicLayer.Users;

namespace BuisnessLogicLayer.Projects
{
    public interface IProjectRepository
    {
        void Add(NewProject newProject);

        void Delete(int id);

        void Update(Project project);

        bool IsProjectExists(int id);

        /// <summary>
        /// Gets the projects of a specific user.
        /// </summary>
        /// <param name="userId">Id of a specific user.</param>
        /// <returns>Projects of a specific user.</returns>
        IQueryable<Project> GetUserProjects(int userId);

        /// <summary>
        /// Gets all required project roles for users.
        /// </summary>
        /// <returns>All required project roles for users.</returns>
        IQueryable<UserRole> GetAllUserRoles();

        /// <summary>
        /// Get role of specific user on project.
        /// </summary>
        /// <param name="userId">Id of a specific user.</param>
        /// <param name="projectId">Id of a specific project.</param>
        /// <returns>UserOnProject instance if user assigned to project or null.</returns>
        UserRoleOnProject GetUserRoleOnProject(int userId, int projectId);

        /// <summary>
        /// Get the users assingned to a specific project.
        /// </summary>
        /// <param name="projectId">Id of a specific project.</param>
        /// <returns>Users assingned to a specific project.</returns>
        IQueryable<User> GetProjectUsers(int projectId);

        void AssignUserToProject(UserRoleOnProject userRoleOnProject);

        void ChangeUserRoleOnProject(UserRoleOnProject userRoleOnProject);

        void RemoveUserFromProject(UserRoleOnProject userRoleOnProject);
    }
}
