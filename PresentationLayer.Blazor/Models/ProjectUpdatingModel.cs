using BuisnessLogicLayer.Projects;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace PresentationLayer.Blazor.Models
{
    public class ProjectUpdatingModel : ComponentBase
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;
        [Inject] ProjectService ProjectService { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;

        [Parameter]
        [EditorRequired]
        public Project Project { get; set; } = null!;

        private const string EnabledUpdateButtonText = "Update";
        private const string DisabledCreateButtonText = "Updating...";

        protected bool IsUpdateButtonDisabled = false;

        protected ProjectUpdatingViewModel ProjectData { get; set; } = null!;
        protected string UpdateButtonText = EnabledUpdateButtonText;

        protected override void OnInitialized()
        {
            ProjectData = new(Project.Name!, Project.Description!);

            base.OnInitialized();
        }

        protected async Task OnUpdateClickedAsync()
        {
            await ChangeUpdateButtonStateAsync();
            await TryUpdateProjectAsync();

            MudDialog.Close(DialogResult.Ok(true));
        }

        protected void Cancel() => MudDialog.Cancel();

        private async Task ChangeUpdateButtonStateAsync()
        {
            await Task.Run(() => IsUpdateButtonDisabled = !IsUpdateButtonDisabled);

            if (IsUpdateButtonDisabled)
            {
                UpdateButtonText = DisabledCreateButtonText;
            }
            else
            {
                UpdateButtonText = EnabledUpdateButtonText;
            }

            StateHasChanged();
        }

        private async Task TryUpdateProjectAsync()
        {
            try
            {
                Project.Name = ProjectData.Name;
                Project.Description = ProjectData.Description;
                ProjectService.Update(Project);
            }
            catch (InvalidOperationException)
            {
                await ShowErrorMessageBox();
            }
        }

        private async Task ShowErrorMessageBox()
        {
            string messageBoxTitle = "Something wrong...";
            string messageBoxText = "Failed to update project.";
            await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
        }
    }
}
