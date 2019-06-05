using System;
using System.Windows.Input;

namespace oinkapp.ViewModels
{
    public class ActionCommandT<T> : ICommand
    {
        readonly Action<T> action;
        public ActionCommandT(Action<T> action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => action((T)parameter);
    }
    public class ActionCommand : ICommand
    {
        readonly Action action;
        public ActionCommand(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => action();
    }
}