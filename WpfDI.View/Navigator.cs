using System.Windows;
using WpfDI.ViewModel.Interface;

namespace WpfDI.View
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Navigator : IINavigator
    {
        public void OpenModal(IIModal viewModel)
        {
            var window = new Window {Content = ViewMapper.CreateView(viewModel)};

            viewModel.Close = window.Close;

            window.ShowDialog();
        }
    }
}