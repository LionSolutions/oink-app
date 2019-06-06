using oinkapp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oinkapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavingItemPage : ContentPage
    {
        public SavingItemPage(int _SavingId)
        {
            InitializeComponent();
            BindingContext = new SavingItemPageViewModel(Navigation, _SavingId);
        }
    }
}