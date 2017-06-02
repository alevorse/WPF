using System;
using System.Windows.Input;

namespace WpfDI.ViewModel.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> Action { get; }

        public RelayCommand(Action<object> action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public RelayCommand(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            Action = _ => action();
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => Action(parameter);

        public event EventHandler CanExecuteChanged;
    }
}