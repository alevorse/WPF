using System.Windows.Input;

namespace WpfDI.ViewModel.Command
{
    public interface IIResultCommand<out T> : ICommand
    {
        T Result { get; }
    }
}