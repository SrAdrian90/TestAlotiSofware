using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aloti.Forms.Prims.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

        }
    }
}
