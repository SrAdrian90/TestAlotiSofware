using Prism.Commands;
using Prism.Navigation;
using Shared.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.ViewModels
{
    public class RequestItemViewModel : RequestResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _requestSelectCommand;

        public DelegateCommand RequestSelectCommand => _requestSelectCommand ?? (_requestSelectCommand = new DelegateCommand(RequestSelectAsync));


        public RequestItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        private async void RequestSelectAsync()
        {
            NavigationParameters navigationParams = new NavigationParameters
            {
                { "request", this }
            };

            await _navigationService.NavigateAsync("AssignedVisitsPage", navigationParams);
        }

    }
}
