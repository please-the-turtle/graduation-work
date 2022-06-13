using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace PresentationLayer.Blazor.Models
{
    public class UserOnProjectModel : ComponentBase
    {
        [Parameter]
        [EditorRequired]
        public UserOnProjectViewModel Item { get; set; } = null!;

        [CascadingParameter(Name = "RoleOnProject")]
        private UserRoleOnProject RoleOnProject { get; set; } = null!;

        [Inject]
        public ProjectService ProjectService { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Parameter]
        public EventCallback OnUserRemovedFromProject { get; set; }

        protected UserRoleName[] RolesCapableUpdate
            = new[] { UserRoleName.Creator, UserRoleName.Moderator };

        protected UserRoleName[] RolesCapableDelete
            = new[] { UserRoleName.Creator, UserRoleName.Moderator };

        protected bool IsCapableUpdate = false;
        protected bool IsCapableDelete = false;

        protected UserRoleName SelectedRole
        {
            get => Item.UserRoleData.Role;
            set
            {
                Item.UserRoleData.Role = value;
                Task.Run(ChangeUserRoleAsync);
            }
        }

        protected override void OnParametersSet()
        {
            IsCapableUpdate = GetUpdatingCapability();
            IsCapableDelete = GetDeletingCapability();
            base.OnParametersSet();
        }

        protected async Task ChangeUserRoleAsync()
        {
            IsCapableUpdate = false;

            try
            {
                ProjectService.ChangeUserRoleOnProject(Item.UserRoleData);
            }
            catch (InvalidOperationException)
            {
                string title = "Something wrong...";
                string message = "Failed to change user role. Try later.";
                await DialogService.ShowMessageBox(title, message);
            }
            
            IsCapableUpdate = GetUpdatingCapability();
        }

        protected async Task RemoveUserFromProjectAsync()
        {
            IsCapableDelete = false;

            try
            {
                ProjectService.RemoveUserFromProject(Item.UserRoleData);
            }
            catch (InvalidOperationException)
            {
                string title = "Something wrong...";
                string message = "Failed to change user role. Try later.";
                await DialogService.ShowMessageBox(title, message);
            }

            await OnUserRemovedFromProject.InvokeAsync();
        }

        private bool GetUpdatingCapability()
        {
            bool isCapableUpdate = RolesCapableUpdate.Contains<UserRoleName>(RoleOnProject.Role) &&
                SelectedRole != UserRoleName.Creator;

            return isCapableUpdate;
        }

        private bool GetDeletingCapability()
        {
            bool isCapableDelete = RolesCapableDelete.Contains<UserRoleName>(RoleOnProject.Role) &&
                SelectedRole != UserRoleName.Creator;

            return isCapableDelete;
        }
    }
}
