using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Views;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AccesoViewModel : ViewModelBase
    {
        #region Variables

        UsuarioItemDataBase _usuarioItemDatabase;
        public IFileHelper _fileHelper;
        INavigation _navigationService;

        #endregion Variables

        #region Constructor

        public AccesoViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _usuarioItemDatabase = new UsuarioItemDataBase(_fileHelper.GetLocalFilePath("UsuarioSQLite.db3"));

            Title = "Acceso";
        }

        #endregion Constructor

        #region Constructor

        async void NavegarAMain()
        {
            var value = await _usuarioItemDatabase.GetItemAsync(Usuario, Clave);
            if (value == null)
                await _navigationService.PushAsync(new BurgerMenuPage());
            else
                await App.Current.MainPage.DisplayAlert("Acceso", "Credenciales incorrectas, revise", "Ok");
        }

        #endregion Constructor

        #region Properties

        private ActionCommand _NavegarARegistroCommand;

        public ActionCommand NavegarARegistroCommand
        {
            get
            {
                if (_NavegarARegistroCommand == null)
                {
                    _NavegarARegistroCommand = new ActionCommand(() => _navigationService.PushAsync(new RegistroView());
                }
                return _NavegarARegistroCommand;
            }
            set
            {
                _NavegarARegistroCommand = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _NavegarAMainCommand;

        public ActionCommand NavegarAMainCommand
        {
            get
            {
                if (_NavegarAMainCommand == null)
                {
                    _NavegarAMainCommand = new ActionCommand(NavegarAMain);
                }
                return _NavegarAMainCommand;
            }
            set
            {
                _NavegarAMainCommand = value;
                OnPropertyChanged();
            }
        }


        private string _Usuario;
        public string Usuario
        {
            get => _Usuario;
            set
            {
                _Usuario = value;
                OnPropertyChanged();
            }
        }

        private string _Clave;
        public string Clave
        {
            get => _Clave;
            set
            {
                _Clave = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}