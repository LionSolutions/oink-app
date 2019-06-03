using oinkapp.Data;
using oinkapp.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;

namespace oinkapp.ViewModels
{
    public class AccesoViewModel : ViewModelBase
    {
        UsuarioItemDataBase _usuarioItemDatabase;
        public IFileHelper _fileHelper;
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        public AccesoViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            _navigationService = navigationService;
            _fileHelper = Xamarin.Forms.DependencyService.Get<IFileHelper>();
            _pageDialogService = pageDialog;

            _usuarioItemDatabase = new UsuarioItemDataBase(_fileHelper.GetLocalFilePath("UsuarioSQLite.db3"));

            NavegarARegistroCommand = new DelegateCommand(NavegarARegistro);
            NavegarAMainCommand = new DelegateCommand(NavegarAMain);

            Title = "Acceso";
        }

        async void NavegarAMain()
        {
            var value = await _usuarioItemDatabase.GetItemAsync(Usuario, Clave);
            if (value != null)
                await _navigationService.NavigateAsync(new Uri("/MasterDetail/NavigationPage/ListaAhorro", UriKind.Absolute));
            else
                await _pageDialogService.DisplayAlertAsync("Acceso", "Credenciales incorrectas, revise", "Ok");
        }

        private void NavegarARegistro() => _navigationService.NavigateAsync("Registro");

        public DelegateCommand NavegarARegistroCommand { get; private set; }
        public DelegateCommand NavegarAMainCommand { get; private set; }

        private string _Usuario;
        public string Usuario
        {
            get => _Usuario;
            set => SetProperty(ref _Usuario, value);
        }
        private string _Clave;
        public string Clave
        {
            get => _Clave;
            set => SetProperty(ref _Clave, value);
        }
    }
}