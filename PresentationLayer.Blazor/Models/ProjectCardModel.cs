using BuisnessLogicLayer.Projects;
using PresentationLayer.Blazor.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using BuisnessLogicLayer.Users;

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
        [EditorRequired]
        public Project Project { get; set; } = null!;

        [Parameter]
        public EventCallback OnProjectDeleted { get; set; }

        protected int _userId;
        // TODO field name
        protected UserRoleOnProject _currentUserRole = null!;
        protected IEnumerable<User> _projectUsers = null!;

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState state = await AuthenticationState.GetAuthenticationStateAsync();
            string userIdString = state?.User?.FindFirst("Id")?.Value ?? string.Empty;

            int.TryParse(userIdString, out _userId);
            _currentUserRole = TryGetUserRoleOnProject();
            _projectUsers = TryGetProjectUsers();
        }

        private UserRoleOnProject TryGetUserRoleOnProject()
        {
            try
            {
                return ProjectService.GetUserRoleOnProject(_userId, Project.Id);
            }
            catch (InvalidOperationException)
            {
                //  TODO
            }

            return null!;
        }

        private IEnumerable<User> TryGetProjectUsers()
        {
            try
            {
                return ProjectService.GetProjectUsers(Project.Id);
            }
            catch (InvalidOperationException)
            {
                // sorry
            }

            return null!;
        }

        protected async void OnDeleteClickAsync()
        {
            var options = new DialogOptions() { MaxWidth = MaxWidth.False };

            var dialog = DialogService.Show<ProjectDeletingConfirmation_Dialog>("Confirm deletion", options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                try
                {
                    ProjectService.RemoveUserFromProject(_currentUserRole);
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
