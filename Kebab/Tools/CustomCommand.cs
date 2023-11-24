using System;
using System.Windows.Input;

namespace XamarinSQLiteMVVM.Tools
{
    public class CustomCommand : ICommand
    {

        Action action;
        public CustomCommand(Action action)
        {
            this.action = action;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            action();
        }
    }

    public class CustomCommand<T> : ICommand
    {
        Action<T> action;
        private readonly Func<T, bool> canExecute;

        public CustomCommand(Action<T> action, Func<T,bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return canExecute((T)parameter);
        }
        public void Execute(object parameter)
        {
            action((T)parameter);
        }
    }
}
