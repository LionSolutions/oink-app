using oinkapp.ViewModels;
using oinkapp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oinkapp
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new BurgerMenuPage();
        }
    }
}