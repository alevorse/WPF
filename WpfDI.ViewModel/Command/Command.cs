using System;
using System.Windows.Input;

namespace WpfDI.ViewModel.Command
{
    public static class Command
    {
        public static ICommand Create(Action action) => new RelayCommand(action);
        public static ICommand Create<T>(Action<T> action) => new RelayCommand(obj => action((T) obj));
        public static IIResultCommand<T> Create<T>(Func<T> func) => new ResultCommand<T>(func);
        public static IIResultCommand<TResult> Create<TInput, TResult>(Func<TInput, TResult> func) =>
            new ResultCommand<TResult>(obj => func((TInput) obj));
    }
}