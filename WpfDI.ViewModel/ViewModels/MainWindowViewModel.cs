using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfDI.Model.Interface.Model;
using WpfDI.ViewModel.Interface;

namespace WpfDI.ViewModel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Func<TextViewModel> textFactory, IINavigator navigator, IIAgencyDataAccess modelAgency)
        {
            TextFactory = textFactory;
            Navigator = navigator;
            ModelAgency = modelAgency;
            Panes = new ObservableCollection<IIPane>();
            NewPaneCommand = Command.Command.Create(NewPane);
            NewModalCommand = Command.Command.Create(NewModal);
        }

        private string _text;

        private IIAgencyDataAccess ModelAgency { get; }
        private Func<TextViewModel> TextFactory { get; }
        private IINavigator Navigator { get; }
        public ObservableCollection<IIPane> Panes { get; }

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

        public ICommand NewPaneCommand { get; }
        public ICommand NewModalCommand { get; }

        public void NewPane()
        {
            //get viewmodel from factory
            var viewModel = TextFactory();
            viewModel.Text = Text;
            Text = string.Empty;
            viewModel.RemovePane = RemovePane;
            ModelAgency.SearchAgencies("hjklfsda");
            //add to panes to create pane using panefactory
            Panes.Add(viewModel);
        }

        public void NewModal()
        {
            //get viewmodel from factory
            var viewModel = TextFactory();
            viewModel.Text = Text;
            Text = string.Empty;

            //use navigator to open modal //viewmodel must be of type IIModal
            Navigator.OpenModal(viewModel);
        }

        private void RemovePane(IIPane vmPane)
        {
            Panes.Remove(vmPane);
        }
    }
}