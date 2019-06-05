using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class AgregarCompraPage : ContentPage
    {

        public AgregarCompraPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AgregarCompraViewModel(Navigation);
        }
    }
}