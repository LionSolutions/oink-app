using Prism.Commands;
using Prism.Navigation;

namespace oinkapp.ViewModels
{
    public class SplashViewModel : ViewModelBase
	{
		INavigationService _navigationService;
		public SplashViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;

			IrAAccesoCommand = new DelegateCommand(NavegarAAcceso);
		}
		void NavegarAAcceso()
		{
			_navigationService.NavigateAsync("http://www.erecap_forms/NavigationPage/Acceso");
		}
		public DelegateCommand IrAAccesoCommand { get; private set; }
	}
}