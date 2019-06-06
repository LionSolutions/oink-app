using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class MisComprasPage : ContentPage
    {
        public MisComprasPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = new MisComprasViewModel(Navigation);
        }
    }
}