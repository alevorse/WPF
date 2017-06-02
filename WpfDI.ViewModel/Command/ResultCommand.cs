using System;
using System.Windows.Input;

namespace WpfDI.ViewModel.Command
{
    public class ResultCommand<T> : IIResultCommand<T>
    {
        private Func<object, T> Func { get; }
        public T Result { get; private set; }

        public ResultCommand(Func<object, T> func)
        {
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public ResultCommand(Func<T> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            Func = _ => func();
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => Result = Func(parameter);

        public event EventHandler CanExecuteChanged;
    }
}