using Aloti.Forms.Prims.Helpers;
using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Repositories;
using Aloti.Forms.Prims.Services;
using Aloti.Forms.Prims.Storage;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Contracts;
using Shared.Common.Enums;
using Shared.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aloti.Forms.Prims.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IApiServices _apiService;
        private readonly ModalDialogue _modalDialogue;


        private string _username;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;

        private DelegateCommand _loginCommand;


        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }


        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(LoginAsync));


        public LoginPageViewModel(INavigationService navigationService, IPopupNavigation popupNavigation, IApiServices apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _popupNavigation = popupNavigation;
            _apiService = apiService;
            _modalDialogue = new ModalDialogue(_popupNavigation);

            IsEnabled = true;
            IsRunning = false;
        }

        private async void LoginAsync()
        {
            IsEnabled = false;

            bool Validate = await ValidationAsync();

            if (!Validate)
            {
                IsEnabled = true;
                return;
            }

            IsRunning = true;

            await Task.Delay(1500);

            User userResponse = new UserRepository().LoginUser(Username, Password);

            if (userResponse == null)
            {
                await _modalDialogue.SendDisplay("Atención", "Hubo un problema con la información del usuario.");
                Username = string.Empty;
                Password = string.Empty;
                IsRunning = false;
                IsEnabled = true;
                return;
            }



            Settings.User = JsonConvert.SerializeObject(userResponse);
            Username = string.Empty;
            Password = string.Empty;

            await _navigationService.NavigateAsync("/NavigationPage/LandingPage");
        }


        private async Task<bool> ValidationAsync()
        {
            if (string.IsNullOrEmpty(Username))
            {
                await _modalDialogue.SendDisplay("Atención", "Por favor, Ingresa un Usuario.");
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                await _modalDialogue.SendDisplay("Atención", "Por favor, Ingresa una contraseña.");
                return false;
            }

            return true;

        }
    }
}
