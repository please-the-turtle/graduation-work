using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace PresentationLayer.Blazor.Models
{
    public class AssigningUserOnProjectModel : ComponentBase
    {
        [Parameter]
        [EditorRequired]
        public Project Project { get; set; } = null!;

        [Parameter]
        public EventCallback OnUserAssigned { get; set; }

        [Inject]
        public ProjectService ProjectService { get; set; } = null!;

        [Inject]
        public UserService UserService { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        protected UserOnProjectViewModel AssignUserInfo { get; set; } = null!;

        private UserRoleName _selectedUserRole = UserRoleName.User;

        protected UserRoleName SelectedUserRole
        {
            get => _selectedUserRole;
            set
            {
                _selectedUserRole = value;
            }
        }

        protected bool IsAssignButtonDisabled = false;

        protected override void OnInitialized()
        {
            AssignUserInfo = UserOnProjectViewModel.Empty;
            base.OnInitialized();
        }

        protected async Task TryAssignUserToProjectAsync()
        {
            IsAssignButtonDisabled = true;

            try
            {
                User assignUser = null!;

                if (!UserService.IsUserExists(AssignUserInfo.UserLogin, out assignUser))
                {
                    string title = "Assigning user";
                    string message = "User not exists.";
                    await DialogService.ShowMessageBox(title, message);
                }
                else if (ProjectService.GetUserRoleOnProject(assignUser.Id, Project.Id) != null)
                {
                    string title = "Assigning user";
                    string message = "User already on the project.";
                    await DialogService.ShowMessageBox(title, message);
                }
                else
                {
                    UserRoleOnProject role = new(assignUser.Id, Project.Id, SelectedUserRole);
                    ProjectService.AssignUserToProject(role);
                    await OnUserAssigned.InvokeAsync();
                }
            }
            catch (InvalidOperationException)
            {
                string title = "Assigning user";
                string message = "Failed to assign user to project. Try later.";
                await DialogService.ShowMessageBox(title, message);
            }

            IsAssignButtonDisabled = false;
        }
    }
}
