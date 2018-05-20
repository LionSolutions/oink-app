using System;
using Prism;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using oinkapp.ViewModels;
using oinkapp.Views;
using Prism.Ioc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oinkapp
{
	public partial class App : PrismApplication
	{
		protected override void OnInitialized()
		{
            InitializeComponent();
            //NavigationService.NavigateAsync("Splash");
            NavigationService.NavigateAsync(new Uri("/MasterDetail/NavigationPage/ListaAhorro", UriKind.Absolute));
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<SplashView, SplashViewModel>("Splash");
            containerRegistry.RegisterForNavigation<AccesoView, AccesoViewModel>("Acceso");
            containerRegistry.RegisterForNavigation<RegistroView, RegistroViewModel>("Registro");

            containerRegistry.RegisterForNavigation<MasterDetailAhorro, MasterDetailAhorroViewModel>("MasterDetail");
            containerRegistry.RegisterForNavigation<ListaAhorroPage, ListaAhorroPageViewModel>("ListaAhorro");
            containerRegistry.RegisterForNavigation<NuevoAhorroPage, NuevoAhorroPageViewModel>("NuevoAhorro");
            containerRegistry.RegisterForNavigation<EnlacesAhorroPage, EnlacesAhorroPageViewModel>("EnlacesAhorro");


		}
	}
}