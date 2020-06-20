using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aloti.Forms.Prims.ViewModels
{
    public class VariableRatePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public VariableRatePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
