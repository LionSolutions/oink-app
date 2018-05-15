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

			Title = "Acceso";
		}

		private void NavegarARegistro()
		{
			_navigationService.NavigateAsync("Registro");
		}

		public DelegateCommand NavegarARegistroCommand { get; private set; }
	}
}
