using System;
using Prism.Commands;
using Prism.Navigation;

namespace oinkapp.ViewModels
{
    public class MasterDetailAhorroViewModel
    {
        INavigationService _navigationService;
        public MasterDetailAhorroViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OnNavigateCommand = new DelegateCommand<string>(OnNavigate);
        }

        async void OnNavigate(string _page)
        {
            await _navigationService.NavigateAsync(new Uri(_page,UriKind.Relative));
        }

        public DelegateCommand<string> OnNavigateCommand { get; set; }
    }
}
