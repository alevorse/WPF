using System;
using System.Windows.Input;
using WpfDI.ViewModel.Interface;

namespace WpfDI.ViewModel.ViewModels
{
    public class TextViewModel : ViewModelBase, IIModal, IIPane
    {
        private IINavigator Navigator { get; }

        public TextViewModel(IINavigator navigator)
        {
            Navigator = navigator;
            CloseWindowCommand = Command.Command.Create(CloseWindowCmd);
        }

        private string _text;
        
        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseWindowCommand { get; set; }
        public Action<IIPane> RemovePane { get; set; }
        public Action Close { get; set; }

        private void CloseWindowCmd()
        {
            RemovePane?.Invoke(this);
            Close?.Invoke();
        }
    }
}