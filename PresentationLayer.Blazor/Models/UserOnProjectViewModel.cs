using BuisnessLogicLayer.Projects;
using BuisnessLogicLayer.Users;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Blazor.Models
{
    public class UserOnProjectViewModel
    {
        [Required(ErrorMessage = "User login is required.")]
        public string UserLogin { get; set; } = null!;

        public UserRoleOnProject UserRoleData { get; set; }

        public UserOnProjectViewModel(string userLogin, UserRoleOnProject role)
        {
            UserLogin = userLogin;
            UserRoleData = role;
        }

        public static UserOnProjectViewModel Empty
        {
            get
            {
                return new UserOnProjectViewModel(string.Empty, UserRoleOnProject.Empty);
            }
        }
    }
}
