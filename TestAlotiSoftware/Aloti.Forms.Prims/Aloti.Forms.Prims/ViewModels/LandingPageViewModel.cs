using Aloti.Forms.Prims.Helpers;
using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Services;
using Aloti.Forms.Prims.Storage;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace Aloti.Forms.Prims.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private User _user { get; set; }

        private bool _isRunning;
        private bool _isEnabled;

        private bool _isVisibleSimulator;
        private bool _isVisibleVisit;
        private bool _isVisibleRequest;


        private DelegateCommand _fixedRateCommand;
        private DelegateCommand _variableRateCommand;
        private DelegateCommand _visitCommand;
        private DelegateCommand _requestCommand;


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsVisibleSimulator
        {
            get => _isVisibleSimulator;
            set => SetProperty(ref _isVisibleSimulator, value);
        }

        public bool IsVisibleVisit
        {
            get => _isVisibleVisit;
            set => SetProperty(ref _isVisibleVisit, value);
        }

        public bool IsVisibleRequest
        {
            get => _isVisibleRequest;
            set => SetProperty(ref _isVisibleRequest, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }



        public DelegateCommand FixedRateCommand => _fixedRateCommand ?? (_fixedRateCommand = new DelegateCommand(FixedRateAsync));

        public DelegateCommand VariableRateCommand => _variableRateCommand ?? (_variableRateCommand = new DelegateCommand(VariableRateAsync));

        public DelegateCommand VisitCommand => _visitCommand ?? (_visitCommand = new DelegateCommand(VisitAsync));

        public DelegateCommand RequestCommand => _requestCommand ?? (_requestCommand = new DelegateCommand(RequestAsync));


        public LandingPageViewModel(INavigationService navigationService, IApiServices apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _user = JsonConvert.DeserializeObject<User>(Settings.User);
            LoadPermission();

        }

        private void LoadPermission()
        {
            switch (_user.Rule)
            {
                case Shared.Common.Enums.Rules.Admin:
                    IsVisibleRequest = true;
                    IsVisibleSimulator = true;
                    IsVisibleVisit = true;
                    break;

                case Shared.Common.Enums.Rules.Anonymous:
                    IsVisibleRequest = false;
                    IsVisibleSimulator = true;
                    IsVisibleVisit = false;
                    break;

                case Shared.Common.Enums.Rules.Client:
                    IsVisibleRequest = true;
                    IsVisibleSimulator = true;
                    IsVisibleVisit = false;
                    break;
                default:
                    break;
            }

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
