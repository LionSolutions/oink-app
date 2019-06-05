using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Views;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AccesoViewModel : ViewModelBase
    {
        UsuarioItemDataBase _usuarioItemDatabase;
        public IFileHelper _fileHelper;
        INavigation _navigationService;

        public AccesoViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _usuarioItemDatabase = new UsuarioItemDataBase(_fileHelper.GetLocalFilePath("UsuarioSQLite.db3"));

            Title = "Acceso";
        }

        async void NavegarAMain()
        {
            var value = await _usuarioItemDatabase.GetItemAsync(Usuario, Clave);
            if (value == null)
                await _navigationService.PushAsync(new BurgerMenuPage());
            else
                await App.Current.MainPage.DisplayAlert("Acceso", "Credenciales incorrectas, revise", "Ok");
        }

        private void NavegarARegistro() => _navigationService.PushAsync(new RegistroView());

        private ActionCommand _NavegarARegistroCommand;

        public ActionCommand NavegarARegistroCommand
        {
            get
            {
                if (_NavegarARegistroCommand == null)
                {
                    _NavegarARegistroCommand = new ActionCommand(NavegarARegistro);
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
    }
}