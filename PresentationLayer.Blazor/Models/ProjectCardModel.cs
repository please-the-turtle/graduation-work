using BuisnessLogicLayer.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using BuisnessLogicLayer.Users;
using PresentationLayer.Blazor.Pages.Projects;

namespace PresentationLayer.Blazor.Models
{
    public class ProjectCardModel : ComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationState { get; set; } = null!;

        [Inject]
        protected ProjectService ProjectService { get; set; } = null!;

        [Inject]
        protected IDialogService DialogService { get; set; } = null!;

        [Parameter]
        //[EditorRequired]
        public Project Project { get; set; } = null!;

        [Parameter]
        public EventCallback OnProjectDeleted { get; set; }

        [Parameter]
        public EventCallback OnProjectUpdated { get; set; }

        protected UserRoleName[] RolesCapableDelete { get; set; }
            = new[] { UserRoleName.Creator };
        protected UserRoleName[] RolesCapableUpdate { get; set; }
            = new[] { UserRoleName.Creator, UserRoleName.Moderator };

        protected int UserId;
        protected UserRoleOnProject CurrentUserRole = null!;
        protected IEnumerable<User> ProjectUsers = null!;

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState state = await AuthenticationState.GetAuthenticationStateAsync();
            string userIdString = state?.User?.FindFirst("Id")?.Value ?? string.Empty;

            int.TryParse(userIdString, out UserId);
            CurrentUserRole = TryGetUserRoleOnProject();
            ProjectUsers = TryGetProjectUsers();
        }

        private UserRoleOnProject TryGetUserRoleOnProject()
        {
            try
            {
                return ProjectService.GetUserRoleOnProject(UserId, Project.Id);
            }
            catch (InvalidOperationException)
            {
                return null!;
            }
        }

        private IEnumerable<User> TryGetProjectUsers()
        {
            try
            {
                return ProjectService.GetProjectUsers(Project.Id);
            }
            catch (InvalidOperationException)
            {
                return null!;
            }
        }

        protected async void OnDeleteClickAsync()
        {
            var dialog = DialogService.Show<ProjectDeletingConfirmation_Dialog>();
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                try
                {
                    ProjectService.Delete(Project.Id);
                    await OnProjectDeleted.InvokeAsync();
                }
                catch (InvalidOperationException)
                {
                    string messageBoxTitle = "Something wrong...";
                    string messageBoxText = "Try to update page.";
                    await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
                }
            }
        }

        protected async Task OnUpdateClickAsync()
        {
            var parameters = new DialogParameters();
            parameters.Add("Project", Project);
            var dialog = DialogService.Show<ProjectUpdating_Dialog>(Project.Name, parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await OnProjectUpdated.InvokeAsync();
            }
        }

        protected void OnUsersClick()
        {
            var parameters = new DialogParameters();
            parameters.Add(nameof(UsersOnProjectModel.Project), Project);
            DialogService.Show<UsersOnProject_Dialog>("Project participants", parameters);
        }

        protected char GetFirstLetter(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 'U';
            }

            return char.ToUpper(str[0]);
        }
    }
}
