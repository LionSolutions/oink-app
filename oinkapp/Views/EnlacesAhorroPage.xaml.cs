using Xamarin.Forms;
using oinkapp.ViewModels;

namespace oinkapp.Views
{
    public partial class EnlacesAhorroPage : ContentPage
    {
        public EnlacesAhorroPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new EnlacesAhorroPageViewModel();
        }
    }
}