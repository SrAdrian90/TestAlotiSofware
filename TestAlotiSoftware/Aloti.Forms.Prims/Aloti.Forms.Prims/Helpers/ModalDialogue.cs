using Aloti.Forms.Prims.Views;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Enums;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aloti.Forms.Prims.Helpers
{
    public class ModalDialogue
    {
        private readonly IPopupNavigation _popupNavigation;
        public ModalDialogue(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;
        }


        public async Task SendDisplay(string Title, string Message)
        {
            PopupDialogue modal = new PopupDialogue();

            ScaleAnimation scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Top,
                PositionOut = MoveAnimationOptions.Bottom
            };


            Label LabelTitle = new Label
            {
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                Text = Title,
                Margin = new Thickness(10, 10, 10, 5),
                TextColor = Color.FromHex("#023e6f"),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };


            Label LabelMessaje = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.None,
                Text = Message,
                Margin = new Thickness(10, 5, 10, 10),
                TextColor = Color.FromHex("#090D1B"),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            modal.Content = new Frame
            {
                HeightRequest = 150,
                CornerRadius = 8,
                Margin = 20,
                Padding = 10,
                BackgroundColor = Color.FromHex("#ffffff"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        LabelTitle,
                        LabelMessaje
                    }

                }

            };

            modal.Animation = scaleAnimation;

            await _popupNavigation.PushAsync(modal, true);
        }


    }
}
