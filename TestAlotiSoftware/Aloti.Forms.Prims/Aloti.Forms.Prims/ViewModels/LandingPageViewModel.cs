using Prism.Commands;
using Prism.Navigation;

namespace Aloti.Forms.Prims.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private DelegateCommand _fixedRateCommand;
        private DelegateCommand _variableRateCommand;
        private DelegateCommand _visitCommand;
        private DelegateCommand _requestCommand;

        public DelegateCommand FixedRateCommand => _fixedRateCommand ?? (_fixedRateCommand = new DelegateCommand(FixedRateAsync));

        public DelegateCommand VariableRateCommand => _variableRateCommand ?? (_variableRateCommand = new DelegateCommand(VariableRateAsync));

        public DelegateCommand VisitCommand => _visitCommand ?? (_visitCommand = new DelegateCommand(VisitAsync));

        public DelegateCommand RequestCommand => _requestCommand ?? (_requestCommand = new DelegateCommand(RequestAsync));


        public LandingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        private async void FixedRateAsync()
        {
            await _navigationService.NavigateAsync("FixedRatePage");
        }

        private async void VariableRateAsync()
        {
            await _navigationService.NavigateAsync("VariableRatePage");
        }

        private async void VisitAsync()
        {
            await _navigationService.NavigateAsync("VisitPage");
        }

        private async void RequestAsync()
        {
            await _navigationService.NavigateAsync("RequestPage");
        }


    }
}
