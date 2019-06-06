using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class SavingsPage : ContentPage
    {
        public SavingsPage()
        {
            InitializeComponent();
            BindingContext = new SavingsPageViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
