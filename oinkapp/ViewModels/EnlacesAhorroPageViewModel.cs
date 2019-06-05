using System;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class EnlacesAhorroPageViewModel : ViewModelBase
    {
        public EnlacesAhorroPageViewModel()
        {
            Title = "Enlaces";
        }

        private void NavigateToUrl(string uriString)
        {
            Device.OpenUri(new Uri(uriString, UriKind.Absolute));
        }

        private ActionCommandT<string> _NavigateToUrlCommand;

        public ActionCommandT<string> NavigateToUrlCommand
        {
            get
            {
                if (_NavigateToUrlCommand == null)
                {
                    _NavigateToUrlCommand = new ActionCommandT<string>(NavigateToUrl);
                }
                return _NavigateToUrlCommand;
            }
            set
            {
                _NavigateToUrlCommand = value;
                OnPropertyChanged();
            }
        }

    }
}