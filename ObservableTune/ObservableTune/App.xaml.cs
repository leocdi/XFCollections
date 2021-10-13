using ObservableTune.ViewModels;
using ObservableTune.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ObservableTune
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ObsList1Page, ObsList1PageViewModel>();
            containerRegistry.RegisterForNavigation<ObsList2Page, ObsList2PageViewModel>();
            containerRegistry.RegisterForNavigation<ObsListComplexUiPage, ObsListComplexUiPageViewModel>();
        }
    }
}
