using Aloti.Forms.Prims.CustomRender;
using Aloti.Forms.Prims.Droid.CustomRender;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace Aloti.Forms.Prims.Droid.CustomRender
{
    public class CustomEntryRender : EntryRenderer
    {

        public CustomEntryRender(Context context) : base(context)
        {

        }
        public CustomEntry ElementV2 => Element as CustomEntry;

        protected override FormsEditText CreateNativeControl()
        {
            FormsEditText control = base.CreateNativeControl();
            control.Elevation = 9;
            UpdateBackground(control);

            return control;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomEntry.CornerRadiusProperty.PropertyName)
            {
                UpdateBackground();
            }
            else if (e.PropertyName == CustomEntry.BorderThicknessProperty.PropertyName)
            {
                UpdateBackground();
            }
            else if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
            {
                UpdateBackground();
            }

            base.OnElementPropertyChanged(sender, e);
        }

        protected override void UpdateBackgroundColor()
        {
            UpdateBackground();
        }


        protected void UpdateBackground(FormsEditText control)
        {
            if (control == null)
            {
                return;
            }

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            control.SetBackground(gd);

            int padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
            int padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
            int padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
            int padRight = (int)Context.ToPixels(ElementV2.Padding.Right);

            control.SetPadding(padLeft, padTop, padRight, padBottom);
        }


        protected void UpdateBackground()
        {
            UpdateBackground(Control);
        }
    }
}