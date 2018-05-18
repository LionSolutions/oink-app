using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace oinkapp.ViewModels
{
	public class AccesoViewModel : ViewModelBase
	{
		INavigationService _navigationService;
		public AccesoViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavegarARegistroCommand = new DelegateCommand(NavegarARegistro);
            NavegarAMainCommand = new DelegateCommand(NavegarAMain);

			Title = "Acceso";
		}

        private void NavegarAMain()
        {
            _navigationService.NavigateAsync(new Uri("/MasterDetail/NavigationPage/ListaAhorro", UriKind.Absolute));
        }

        private void NavegarARegistro()
		{
			_navigationService.NavigateAsync("Registro");
		}

        public DelegateCommand NavegarARegistroCommand { get; private set; }
        public DelegateCommand NavegarAMainCommand { get; private set; }
	}
}
