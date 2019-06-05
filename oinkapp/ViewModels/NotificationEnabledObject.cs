using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace oinkapp.ViewModels
{
    public class NotificationEnabledObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}