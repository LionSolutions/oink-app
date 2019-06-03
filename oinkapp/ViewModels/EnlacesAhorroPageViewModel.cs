using Prism.Commands;
using System;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class EnlacesAhorroPageViewModel:ViewModelBase
    {
        public EnlacesAhorroPageViewModel()
        {
            NavigateToUrlCommand = new DelegateCommand<string>(NavigateToUrl);
            Title = "Enlaces";
        }

        private void NavigateToUrl(string uriString)
        {
            Device.OpenUri(new Uri(uriString, UriKind.Absolute));
        }

        public DelegateCommand<string> NavigateToUrlCommand { get; private set; }
    }
}