using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class ViewModelBase : NotificationEnabledObject
    {
        #region Variables

        public INavigation navigationService;

        #endregion Variables

        #region Properties

        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}