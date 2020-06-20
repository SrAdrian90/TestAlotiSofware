using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Aloti.Forms.Prims.Storage
{
    public static class Settings
    {

        private const string _user = "user";

        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;
        private static readonly int _intDefault = 0;
        private static readonly decimal _decimalDefault = 0;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string User
        {
            get => AppSettings.GetValueOrDefault(_user, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_user, value);
        }
    }
}
