using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        INavigation _navigationService;
        public SplashViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
        }
        void NavegarAAcceso()
        {
            //Chacar si funciona
            //App.Current.MainPage.NavigateAsync("http://www.erecap_forms/NavigationPage/Acceso");
        }
        private ActionCommand _IrAAccesoCommand;

        public ActionCommand IrAAccesoCommand
        {
            get
            {
                if (IrAAccesoCommand == null)
                {
                    IrAAccesoCommand = new ActionCommand(NavegarAAcceso);
                }
                return _IrAAccesoCommand;
            }
            set
            {
                _IrAAccesoCommand = value;
                OnPropertyChanged();
            }
        }
    }
}