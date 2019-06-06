using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class SavingsPage : ContentPage
    {
        public SavingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new SavingsPageViewModel(Navigation);
        }
    }
}
