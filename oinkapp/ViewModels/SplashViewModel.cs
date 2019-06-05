using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        #region Variables

        INavigation _navigationService;

        #endregion Variables

        #region Constructor

        public SplashViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion Constructor

        #region Methods

        void NavegarAAcceso()
        {
            //Chacar si funciona
            //App.Current.MainPage.NavigateAsync("http://www.erecap_forms/NavigationPage/Acceso");
        }

        #endregion Methods

        #region Properties

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

        #endregion Properties
    }
}