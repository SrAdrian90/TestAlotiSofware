using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aloti.Forms.Prims.ViewModels
{
    public class FixedRatePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public FixedRatePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

        }
    }
}
