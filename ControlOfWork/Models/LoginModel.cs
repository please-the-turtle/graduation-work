﻿using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BuisnessLogicLayer;
using ControlOfWork.Infrastructure;
using Microsoft.AspNetCore.Components;
using Task = System.Threading.Tasks.Task;
using MudBlazor;

namespace ControlOfWork.Models
{
    public class LoginModel : ComponentBase
    {
        [Inject] ProtectedLocalStorage LocalStorage { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] UserService UserService { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;
        public LoginViewModel LoginData { get; set; }

        private const string EnabledLoginDataText = "Log in";
        private const string DisabledLoginButtonText = "Loading...";

        protected bool _authenticated = true;
        protected bool _isLoginButtonDisabled = false;
        protected string _loginButtonText = EnabledLoginDataText;

        public LoginModel()
        {
            LoginData = new LoginViewModel();
        }

        protected async Task OnLoginClick()
        {
            await ChangeLoginButtonStateAsync();
            await TryToAuthenticateAsync();
            await ChangeLoginButtonStateAsync();
        }

        private async Task TryToAuthenticateAsync()
        {
            try
            {
                _authenticated = UserService.Authenticate(LoginData.Login!, LoginData.Password!);

                if (_authenticated)
                {
                    var token = new SecurityToken
                    {
                        Login = LoginData.Login!,
                        AccessToken = LoginData.Password!,
                        ExpiredAt = DateTime.UtcNow.AddDays(1f)
                    };
                    await LocalStorage.SetAsync(nameof(SecurityToken), token);
                    NavigationManager.NavigateTo("/", true);
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
            string messageBoxText = "Try to update page.";
            await DialogService.ShowMessageBox(messageBoxTitle, messageBoxText);
        }

        private async Task ChangeLoginButtonStateAsync()
        {
            await Task.Run(() => _isLoginButtonDisabled = !_isLoginButtonDisabled);

            if (_isLoginButtonDisabled)
            {
                _loginButtonText = DisabledLoginButtonText;
            }
            else
            {
                _loginButtonText = EnabledLoginDataText;
            }

            StateHasChanged();
        }
    }
}