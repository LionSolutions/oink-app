namespace oinkapp.ViewModels
{
    public class ViewModelBase : NotificationEnabledObject
    {
        public ViewModelBase()
        {
        }
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
    }
}