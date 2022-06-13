using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace PresentationLayer.Blazor.Models
{
    public class UsersOnProjectModel : ComponentBase
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; } = null!;

        [Parameter]
        [EditorRequired]
        public Project Project { get; set; } = null!;

        [Inject]
        public ProjectService ProjectService { get; set; } = null!;

        [Inject]
        protected AuthenticationStateProvider AuthenticationState { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        protected IEnumerable<UserOnProjectViewModel> UsersInfo { get; set; } = null!;

        protected UserRoleName[] RolesCapableAssign 
            = new UserRoleName[] { UserRoleName.Creator, UserRoleName.Moderator };

        protected UserRoleOnProject RoleOnProject { get; set; } = null!;

        protected async override Task OnInitializedAsync()
        {
            await UpdateUsersInfoAsync();
            await base.OnInitializedAsync();
        }

        protected async Task UpdateUsersInfoAsync()
        {
            RoleOnProject = await GetRoleOnProjectAsync();
            UsersInfo = await TryGetUsersInfoAsync();
        }

        private async Task<UserRoleOnProject> GetRoleOnProjectAsync()
        {
            try
            {
                AuthenticationState state = await AuthenticationState.GetAuthenticationStateAsync();
                string userIdString = state?.User?.FindFirst("Id")?.Value ?? string.Empty;
                int.TryParse(userIdString, out int userId);
                if (userId > 0 && Project is not null)
                {
                    return ProjectService.GetUserRoleOnProject(userId, Project.Id);
                }
            }
            catch (InvalidOperationException)
            {
                string title = "Something wrong...";
                string message = "Failed to load user role on project. Try later.";
                await DialogService.ShowMessageBox(title, message);
            }

            return null!;
        }

        private async Task<IEnumerable<UserOnProjectViewModel>> TryGetUsersInfoAsync()
        {
            List<UserOnProjectViewModel> usersInfo = null!;

            try
            {
                var users = ProjectService.GetProjectUsers(Project.Id).ToArray();
                usersInfo = new List<UserOnProjectViewModel>();

                foreach (var user in users)
                {
                    var roleData = ProjectService.GetUserRoleOnProject(user.Id, Project.Id);
                    var userInfo = new UserOnProjectViewModel(user.Login, roleData);
                    usersInfo.Add(userInfo);
                }
            }
            catch (InvalidOperationException)
            {
                string title = "Something wrong...";
                string message = "Failed to load users list. Try later.";
                await DialogService.ShowMessageBox(title, message);
            }

            return usersInfo;
        }

        protected void Close() => MudDialog.Close();
    }
}
