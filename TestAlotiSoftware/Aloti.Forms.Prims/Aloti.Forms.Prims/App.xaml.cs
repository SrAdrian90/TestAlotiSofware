using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Repositories;
using Aloti.Forms.Prims.Storage;
using Aloti.Forms.Prims.ViewModels;
using Aloti.Forms.Prims.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using System;
using System.Collections.Generic;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aloti.Forms.Prims
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            LoadDataBase();

            LoadUser();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");


        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();

            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterPopupDialogService();
            containerRegistry.RegisterForNavigation<PopupDialogue, PopupDialogueViewModel>();
        }

        void LoadDataBase()
        {
            DBContext.Add("Database.db3", new List<Type>()
            {
                typeof(User),
            });
        }

        void LoadUser()
        {
            var User1 = new User
            {
                FirstName = "Juan Alberto",
                LastName = "Cárdenas Trellez",
                Address = "Calle 65 # 1-45 Urbanización el Nogal",
                Document = "105245788",
                Gender = Shared.Common.Enums.Gender.Men,
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Client

            };

            var User2 = new User
            {
                FirstName = "Maria Clara",
                LastName = "Tina Meliz",
                Address = "Av 5 # 85-78 Barrio Americas",
                Document = "78965412",
                Gender = Shared.Common.Enums.Gender.Female,
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Admin

            };

            var User3 = new User
            {
                FirstName = "Miguel Angel",
                LastName = "Florez Ortiz",
                Address = "Ciuda de Dios # 1-54 Colpatria",
                Document = "58254252",
                Gender = Shared.Common.Enums.Gender.Men,
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Anonymous

            };

            var x = new UserRepository();
            x.Save(User2);

           


        }


    }
}
