using Prism.Navigation;
using Rg.Plugins.Popup.Contracts;

namespace Aloti.Forms.Prims.ViewModels
{
    public class PopupDialogueViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPopupNavigation _popupNavigation;


        public PopupDialogueViewModel(INavigationService navigationService, IPopupNavigation popupNavigation) : base(navigationService)
        {
            _navigationService = navigationService;
            _popupNavigation = popupNavigation;
        }
    }
}
