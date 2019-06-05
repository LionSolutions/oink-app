using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using oinkapp.Views;
using System;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class RegistroViewModel : ViewModelBase
    {
        #region Variables

        UsuarioItemDataBase _usuarioItemDatabase;
        public IFileHelper _fileHelper;
        INavigation _navigationService;

        #endregion Variables

        #region Constructor

        public RegistroViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();
            _usuarioItemDatabase = new UsuarioItemDataBase(_fileHelper.GetLocalFilePath("UsuarioSQLite.db3"));

            Title = "Registro";
        }

        #endregion Constructor

        #region Methods

        async void Registrarse()
        {
            if (String.IsNullOrEmpty(Nombre)
                || String.IsNullOrEmpty(Correo)
                || String.IsNullOrEmpty(Clave))
            {
                await App.Current.MainPage.DisplayAlert("Registro", "Algunos campos estan vacios, revise", "Ok");
            }
            else
            {
                var usuarioAInsertar = new Usuario();
                usuarioAInsertar.Nombre = Nombre;
                usuarioAInsertar.Correo = Correo;
                usuarioAInsertar.Clave = Clave;

                await _usuarioItemDatabase.SaveItemAsync(usuarioAInsertar);
                await _navigationService.PushAsync(new AccesoView());
            }
        }

        #endregion Methods

        #region Properties

        private ActionCommand _RegistrarseCommand;

        public ActionCommand RegistrarseCommand
        {
            get
            {
                if (_RegistrarseCommand == null)
                {
                    _RegistrarseCommand = new ActionCommand(Registrarse);
                }
                return _RegistrarseCommand;
            }
            set { _RegistrarseCommand = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get => _Nombre;
            set
            {
                _Nombre = value;
                OnPropertyChanged();
            }
        }

        private string _Correo;
        public string Correo
        {
            get => _Correo;
            set
            {
                _Correo = value;
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