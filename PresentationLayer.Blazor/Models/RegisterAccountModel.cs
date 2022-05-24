using BuisnessLogicLayer.Users;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.RegularExpressions;

namespace PresentationLayer.Blazor.Models
{
    public class RegisterAccountModel : ComponentBase
    {
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private UserService UserService { get; set; } = null!;
        [Inject] private IDialogService DialogService { get; set; } = null!;
        public RegisterAccountViewModel RegistrationData { get; set; }

        private const string EnabledSignUpDataText = "Sign Up";
        private const string DisabledSignUpButtonText = "Loading...";

        protected bool _isLoginTaken = false;
        protected bool _isEmailTaken = false;
        protected bool _isSignUpButtonDisabled = false;
        protected string _signUpButtonText = EnabledSignUpDataText;

        public RegisterAccountModel()
        {
            RegistrationData = new RegisterAccountViewModel();
        }

        protected async Task OnSignUpClick()
        {
            await ChangeSignUpButtonStateAsync();
            await TryToRegisterNewUserAsync();
            await ChangeSignUpButtonStateAsync();
        }

        protected IEnumerable<string> PasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                yield return "Password is required!";
                yield break;
            }

            if (password.Length < 8)
                yield return "Password must be at least of length 8";
            
            if (!Regex.IsMatch(password, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            
            if (!Regex.IsMatch(password, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            
            if (!Regex.IsMatch(password, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        private async Task TryToRegisterNewUserAsync()
        {
            try
            {
                _isLoginTaken = UserService.IsUserExists(RegistrationData.Login!);
                _isEmailTaken = UserService.IsEmailTaken(RegistrationData.Email!);

                if (!_isLoginTaken && !_isEmailTaken)
                {
                    NewUser newUser = new NewUser
                    (
                        login: RegistrationData.Login!,
                        email: RegistrationData.Email!,
                        password: RegistrationData.Password!
                    );
                    UserService.RegisterNewUser(newUser);

                    NavigationManager.NavigateTo("/login");
                }
            }
            catch (InvalidOperationException)
            {
                await ShowErrorMessageBox();
            }
        }

        private async Task ChangeSignUpButtonStateAsync()
        {
            await Task.Run(() => _isSignUpButtonDisabled = !_isSignUpButtonDisabled);

            if (_isSignUpButtonDisabled)
            {
                _signUpButtonText = DisabledSignUpButtonText;
            }
            else
            {
                _signUpButtonText = EnabledSignUpDataText;
            }

            StateHasChanged();
        }

        private async Task ShowErrorMessageBox()
        {
            string messageBoxTitle = "Something wrong...";
            string messageBoxText = "Try to update page.";
            await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
        }
    }
}
