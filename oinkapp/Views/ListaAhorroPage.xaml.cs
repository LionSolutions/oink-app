using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class ListaAhorroPage : ContentPage
    {
        public ListaAhorroPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ListaAhorroPageViewModel(Navigation);
        }
    }
}