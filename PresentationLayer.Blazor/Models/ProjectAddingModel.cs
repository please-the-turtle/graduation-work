using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace PresentationLayer.Blazor.Models
{
    public class ProjectAddingModel : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;
        [Inject] ProjectService ProjectService { get; set; } = null!;
        [Inject] UserService UserService { get; set; } = null!;
        [Inject] AuthenticationStateProvider AuthenticationState { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;

        private const string EnabledCreateButtonText = "Create";
        private const string DisabledCreateButtonText = "Creating...";

        protected bool IsCreateButtonDisabled = false;

        protected ProjectAddingViewModel NewProjectData { get; set; }
        protected string CreateButtonText = EnabledCreateButtonText;

        public ProjectAddingModel()
        {
            NewProjectData = new();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MudDialog.Title = "New project";
        }

        protected async Task OnCreateClickedAsync()
        {
            await ChangeCreateButtonStateAsync();
            await TryCreateProjectAsync();

            MudDialog.Close(DialogResult.Ok(true));
        }

        protected void Cancel() => MudDialog.Cancel();

        private async Task ChangeCreateButtonStateAsync()
        {
            await Task.Run(() => IsCreateButtonDisabled = !IsCreateButtonDisabled);

            if (IsCreateButtonDisabled)
            {
                CreateButtonText = DisabledCreateButtonText;
            }
            else
            {
                CreateButtonText = EnabledCreateButtonText;
            }

            StateHasChanged();
        }

        private async Task TryCreateProjectAsync()
        {
            try
            {
                NewProject newProject = new(NewProjectData.Name, NewProjectData.Description);

                var state = await AuthenticationState.GetAuthenticationStateAsync();
                string userIdString = state?.User?.FindFirst("Id")?.Value ?? string.Empty;

                if (!int.TryParse(userIdString, out int userId))
                {
                    await ShowErrorMessageBox();
                }
                else
                {
                    User currentUser = UserService.GetById(userId);
                    ProjectService.Create(newProject, currentUser);
                }

            }
            catch (InvalidOperationException)
            {
                await ShowErrorMessageBox();
            }
        }

        private async Task ShowErrorMessageBox()
        {
            string messageBoxTitle = "Something wrong...";
            string messageBoxText = "Failed to create project.";
            await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
        }
    }
}
