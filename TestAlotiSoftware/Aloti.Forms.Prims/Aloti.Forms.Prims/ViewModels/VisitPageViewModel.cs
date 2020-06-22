using Aloti.Forms.Prims.Helpers;
using Aloti.Forms.Prims.Services;
using Prism.Navigation;
using Rg.Plugins.Popup.Contracts;
using Shared.Common.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Aloti.Forms.Prims.ViewModels
{
    public class VisitPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiService;
        private readonly IPopupNavigation _popupNavigation;
        private ModalDialogue _modalDialogue;

        private List<RequestResponse> _requestResponses { get; set; }

        public ObservableCollection<RequestItemViewModel> _requestList;

        private bool _isRunning;
        private bool _isEnabled;
        private int _sa;




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

        public int SA
        {
            get => _sa;
            set => SetProperty(ref _sa, value);
        }

        public ObservableCollection<RequestItemViewModel> RequestList
        {
            get => _requestList;
            set => SetProperty(ref _requestList, value);
        }


        public VisitPageViewModel(INavigationService navigationService, IPopupNavigation popupNavigation, IApiServices apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _popupNavigation = popupNavigation;
            _modalDialogue = new ModalDialogue(_popupNavigation);
            LoadRequest();

        }

        public async void LoadRequest()
        {
            IsRunning = true;
            IsEnabled = false;

            string url = App.Current.Resources["Url"].ToString();
            string UrlApi = App.Current.Resources["UrlAPI"].ToString();

            bool connection = await _apiService.CheckConnectionAsync(url);

            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                await _modalDialogue.SendDisplay("Error", "Revisa tú conexión a internet.");
                return;
            }

            Shared.Common.Responses.Response response = await _apiService.GetListAsync<RequestResponse>(UrlApi,
                                                                                                        "Api",
                                                                                                        "/Requests");

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await _modalDialogue.SendDisplay("Error", "Problema al descargar los registros.");
                return;
            }

            _requestResponses = (List<RequestResponse>)response.Result;


            RequestList = new ObservableCollection<RequestItemViewModel>(_requestResponses.Select(u => new RequestItemViewModel(_navigationService)
            {
                Id = u.Id,
                Client = u.Client,
                DateEnd = u.DateEnd,
                DateInitial = u.DateInitial,
                FilingOffice = u.FilingOffice,
                StateRequest = u.StateRequest

            }).OrderBy(n => n.Client.FirstName).ToList());

            IsRunning = false;
            IsEnabled = true;

        }
    }
}
