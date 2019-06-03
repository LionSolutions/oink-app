using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;

namespace oinkapp.ViewModels
{
    public class RegistroViewModel : ViewModelBase
    {
        UsuarioItemDataBase _usuarioItemDatabase;
        public IFileHelper _fileHelper;
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        public RegistroViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        {
            _navigationService = navigationService;
            _fileHelper = Xamarin.Forms.DependencyService.Get<IFileHelper>();
            _pageDialogService = pageDialog;

            _usuarioItemDatabase = new UsuarioItemDataBase(_fileHelper.GetLocalFilePath("UsuarioSQLite.db3"));

            Title = "Registro";

            RegistrarseCommand = new DelegateCommand(Registrarse);
        }

        async void Registrarse()
        {
            if (String.IsNullOrEmpty(Nombre)
                || String.IsNullOrEmpty(Correo)
                || String.IsNullOrEmpty(Clave))
            {
                await _pageDialogService.DisplayAlertAsync("Registro", "Algunos campos estan vacios, revise", "Ok");
            }
            else
            {
                var usuarioAInsertar = new Usuario();
                usuarioAInsertar.Nombre = Nombre;
                usuarioAInsertar.Correo = Correo;
                usuarioAInsertar.Clave = Clave;

                await _usuarioItemDatabase.SaveItemAsync(usuarioAInsertar);
                await _navigationService.NavigateAsync("Acceso");
            }
        }

        public DelegateCommand RegistrarseCommand { get; private set; }
        private string _Nombre;
        public string Nombre
        {
            get => _Nombre;
            set => SetProperty(ref _Nombre, value);
        }
        private string _Correo;
        public string Correo
        {
            get => _Correo;
            set => SetProperty(ref _Correo, value);
        }
        private string _Clave;
        public string Clave
        {
            get => _Clave;
            set => SetProperty(ref _Clave, value);
        }
    }
}