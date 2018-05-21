using System;
using Prism.Mvvm;

namespace oinkapp.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public ViewModelBase()
        {
        }
        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }
    }
}
