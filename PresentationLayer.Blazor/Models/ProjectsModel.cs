using BuisnessLogicLayer.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using PresentationLayer.Blazor.Pages.Projects;

namespace PresentationLayer.Blazor.Models
{
    public class ProjectsModel : ComponentBase
    {
        [Inject] 
        AuthenticationStateProvider AuthenticationState { get; set; } = null!;

        [Inject] 
        IDialogService DialogService { get; set; } = null!;

        [Inject] 
        ProjectService ProjectService { get; set; } = null!;

        protected int CurrentUserId;
        protected IEnumerable<Project> Projects { get; set; } = null!;

        protected async override Task OnInitializedAsync()
        {
            await RefreshProjectsListAsync();
            await base.OnInitializedAsync();
        }

        protected async Task RefreshProjectsListAsync()
        {
            string userIdString;

            try
            {
                AuthenticationState state = await AuthenticationState.GetAuthenticationStateAsync();
                userIdString = state?.User?.FindFirst("Id")?.Value ?? string.Empty;
            }
            catch (InvalidOperationException)
            {
                await ShowErrorMessageAsync();
                return;
            }

            if (!int.TryParse(userIdString, out CurrentUserId))
            {
                await ShowErrorMessageAsync();
                return;
            }

            try
            {
                Projects = ProjectService.GetUserProjects(CurrentUserId);
            }
            catch (InvalidOperationException)
            {
                await ShowErrorMessageAsync();
            }
        }

        protected async Task AddProjectAsync()
        {
            var dialog = DialogService.Show<ProjectAdding_Dialog>();
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await RefreshProjectsListAsync();
            }
        }

        protected async Task ShowErrorMessageAsync()
        {
            string messageBoxTitle = "Failed to refresh users list.";
            string messageBoxText = "Try to update page.";
            await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
        }
    }
}
