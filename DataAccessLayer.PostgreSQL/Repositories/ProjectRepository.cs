﻿using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;

namespace DataAccessLayer.PostgreSQL.Repositories
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(NewProject newProject)
        {
            if (newProject is null)
            {
                throw new ArgumentNullException(nameof(newProject), "NewProject is null.");
            }

            Project project = new Project
            {
                Name = newProject.Name,
                Description = newProject.Description
            };
            _context.Projects.AddAsync(project);

            _context.SaveChanges();
        }

        public void Update(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project), "Project is null.");
            }

            _context.Projects.Update(project);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Project id must be greater than zero.");
            }

            Project project = _context.Projects.First(p => p.Id == id);
            _context.Projects.Remove(project);

            _context.SaveChanges();
        }

        public bool IsProjectExists(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Project id must be greater than zero.");
            }

            return _context.Projects.Any(p => p.Id == id);
        }

        public void AssignUserToProject(UserRoleOnProject userRoleOnProject)
        {
            _context.UserRoleOnProjects.Add(userRoleOnProject);

            _context.SaveChanges();
        }

        public void ChangeUserRoleOnProject(UserRoleOnProject userRoleOnProject)
        {
            _context.UserRoleOnProjects.Update(userRoleOnProject);

            _context.SaveChanges();
        }

        public void RemoveUserFromProject(UserRoleOnProject userRoleOnProject)
        {
            _context.UserRoleOnProjects.Remove(userRoleOnProject);

            _context.SaveChanges();
        }

        public IQueryable<User> GetProjectUsers(int projectId)
        {
            if (projectId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(projectId), "Project id must be greater than zero.");
            }

            return _context.Users.Where(
                u => _context.UserRoleOnProjects
                .Where(x => x.ProjectId == projectId)
                .Select(t => t.UserId)
                .Contains(u.Id));
        }

        public IQueryable<Project> GetUserProjects(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "Project id must be greater than zero.");
            }

            return _context.Projects.Where(
                u => _context.UserRoleOnProjects
                .Where(x => x.UserId == userId)
                .Select(t => t.ProjectId)
                .Contains(u.Id));
        }

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

            return _context.UserRoleOnProjects.Find(userId, projectId)!;
        }

        public IQueryable<UserRole> GetAllUserRoles()
        {
            return _context.UserRoles.AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}