using Aloti.Forms.Prims.Helpers;
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
            containerRegistry.RegisterForNavigation<LandingPage, LandingPageViewModel>();
        }

        private void LoadDataBase()
        {
            DBContext.Add("Database.db3", new List<Type>()
            {
                typeof(User),

            });
        }

        private void LoadUser()
        {
            List<User> Users = new List<User>();

            User User1 = new User
            {
                FirstName = "Juan Alberto",
                LastName = "Cárdenas Trellez",
                Username = "Juan01",
                Address = "Calle 65 # 1-45 Urbanización el Nogal",
                Document = "105245788",
                Gender = Shared.Common.Enums.Gender.Men,
                Password = Encrypt.GetSHA256("123456"),
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Client

            };

            Users.Add(User1);

            User User2 = new User
            {
                FirstName = "Maria Clara",
                LastName = "Tina Meliz",
                Username = "Maria02",
                Address = "Av 5 # 85-78 Barrio Americas",
                Document = "78965412",
                Gender = Shared.Common.Enums.Gender.Female,
                Password = Encrypt.GetSHA256("Maria25"),
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Admin

            };

            Users.Add(User2);

            User User3 = new User
            {
                FirstName = "Miguel Angel",
                LastName = "Florez Ortiz",
                Username = "Miguel03",
                Address = "Ciuda de Dios # 1-54 Colpatria",
                Document = "58254252",
                Gender = Shared.Common.Enums.Gender.Men,
                Password = Encrypt.GetSHA256("Miguel2020"),
                Id = new Guid(),
                Rule = Shared.Common.Enums.Rules.Anonymous
            };

            Users.Add(User3);

            UserRepository userRepo = new UserRepository();
                      

            foreach (User user in Users)
            {
                bool ExistUser = userRepo.ExisteDocument(user);

                if (!ExistUser)
                {
                    userRepo.Save(user);
                }

            }

        }

    }
}
