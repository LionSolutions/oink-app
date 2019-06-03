using oinkapp.ViewModels;
using oinkapp.Views;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oinkapp
{
    public partial class App : PrismApplication
    {
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("BurgerMenu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SplashView, SplashViewModel>("Splash");
            containerRegistry.RegisterForNavigation<AccesoView, AccesoViewModel>("Acceso");
            containerRegistry.RegisterForNavigation<RegistroView, RegistroViewModel>("Registro");
            containerRegistry.RegisterForNavigation<ListaAhorroPage, ListaAhorroPageViewModel>("ListaAhorro");
            containerRegistry.RegisterForNavigation<MisComprasPage, MisComprasViewModel>("MisCompras");
            containerRegistry.RegisterForNavigation<EnlacesAhorroPage, EnlacesAhorroPageViewModel>("EnlacesAhorro");
            containerRegistry.RegisterForNavigation<AgregarCompraPage, AgregarCompraViewModel>("AgregarCompra");
            containerRegistry.RegisterForNavigation<BurgerMenuPage>("BurgerMenu");
        }
    }
}