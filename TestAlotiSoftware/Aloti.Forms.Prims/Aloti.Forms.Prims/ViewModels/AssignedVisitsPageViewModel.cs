using Prism.Navigation;
using Shared.Common.Responses;
using System.Linq;

namespace Aloti.Forms.Prims.ViewModels
{
    public class AssignedVisitsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _fullName;
        private string _idType;
        private int _idRequest;
        private string _state;
        private string _address;
        private string _phone;
        private string _office;
        private string _cc;
        private string _rol;
        private string _namebussines;
        private string _barrio;
        private string _ciudad;
        private string _dateinitial;
        private string _dateend;


        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string IdType
        {
            get => _idType;
            set => SetProperty(ref _idType, value);
        }

        public int IdRequest
        {
            get => _idRequest;
            set => SetProperty(ref _idRequest, value);
        }

        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Office
        {
            get => _office;
            set => SetProperty(ref _office, value);
        }

        public string CC
        {
            get => _cc;
            set => SetProperty(ref _cc, value);
        }

        public string Rol
        {
            get => _rol;
            set => SetProperty(ref _rol, value);
        }

        public string Namebussines
        {
            get => _namebussines;
            set => SetProperty(ref _namebussines, value);
        }

        public string Barrio
        {
            get => _barrio;
            set => SetProperty(ref _barrio, value);
        }

        public string Ciudad
        {
            get => _ciudad;
            set => SetProperty(ref _ciudad, value);
        }

        public string Dateinitial
        {
            get => _dateinitial;
            set => SetProperty(ref _dateinitial, value);
        }

        public string Dateend
        {
            get => _dateend;
            set => SetProperty(ref _dateend, value);
        }


        public AssignedVisitsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            RequestResponse requestResponse = new RequestResponse();

            if (parameters.ContainsKey("request"))
            {
                requestResponse = parameters.GetValue<RequestResponse>("request");
            }

            FullName = requestResponse.Client.FullName;
            IdRequest = requestResponse.Id;

            switch (requestResponse.Client.IDType)
            {
                case Shared.Common.Enums.IDType.CC:
                    IdType = "Cédula de Ciudadania";
                    break;

                case Shared.Common.Enums.IDType.CE:
                    IdType = "Cédula de Extranjeria";
                    break;

                case Shared.Common.Enums.IDType.PA:
                    IdType = "Pasaporte";
                    break;

                default:
                    break;
            }


            switch (requestResponse.StateRequest)
            {
                case Shared.Common.Enums.StateRequest.NoEfectuado:
                    State = "No Efectuado";
                    break;

                case Shared.Common.Enums.StateRequest.EnAnalisis:
                    State = "En Analisis";
                    break;
                default:
                    break;
            }

            switch (requestResponse.Client.Rule)
            {
                case Shared.Common.Enums.Rules.Admin:
                    Rol = "Administrador";
                    break;

                case Shared.Common.Enums.Rules.Anonymous:
                    Rol = "Anonimo";
                    break;

                case Shared.Common.Enums.Rules.Client:
                    Rol = "Cliente";
                    break;
                default:
                    break;
            }

            Address = requestResponse.Client.BusinessUnits.FirstOrDefault().Address;
            Phone = requestResponse.Client.BusinessUnits.FirstOrDefault().Phone;
            Office = requestResponse.FilingOffice;
            CC = requestResponse.Client.Document;
            Namebussines = requestResponse.Client.BusinessUnits.FirstOrDefault().Name;
            Barrio = requestResponse.Client.BusinessUnits.FirstOrDefault().Barrio;
            Ciudad = requestResponse.Client.BusinessUnits.FirstOrDefault().Ciudad;
            Dateinitial = requestResponse.DateInitial.Value.ToShortDateString();
            Dateend = requestResponse.DateEnd.Value.ToShortDateString();
            return;
        }
    }
}
