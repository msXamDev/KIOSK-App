using CommonServiceLocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace MyPresentation.ViewModels
{
    class WelcomePageViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> Screen3BackButton { get; private set; }
        public DelegateCommand<string> One { get; private set; }
        public DelegateCommand<string> Two { get; private set; }
        public DelegateCommand<string> Three { get; private set; }
        public DelegateCommand<string> Four { get; private set; }
        public DelegateCommand<string> Five { get; private set; }
        public DelegateCommand<string> Six { get; private set; }
        public DelegateCommand<string> Seven { get; private set; }
        public DelegateCommand<string> Eight { get; private set; }
        public DelegateCommand<string> Nine { get; private set; }
        public DelegateCommand<string> Zero { get; private set; }

        public DelegateCommand<string> ClearText { get; private set; }
        private string displayWordInTextbox;
        public string DisplayWordInTextbox
        {
            get
            {
                return displayWordInTextbox;
            }
            set
            {
                displayWordInTextbox += value;
                NotifyPropertyChanged("DisplayWordInTextbox");
            }
        }
        public string ClearWordInTextbox
        {
            get
            {
                return displayWordInTextbox;
            }
            set
            {
                displayWordInTextbox = string.Empty;
                NotifyPropertyChanged("DisplayWordInTextbox");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public WelcomePageViewModel( IRegionManager regionManager)
        {
            _regionManager = regionManager;
            One = new DelegateCommand<string>(Get_Command);
            Two = new DelegateCommand<string>(Get_Command);
            Three = new DelegateCommand<string>(Get_Command);
            Four = new DelegateCommand<string>(Get_Command);
            Five = new DelegateCommand<string>(Get_Command);
            Six = new DelegateCommand<string>(Get_Command);
            Seven = new DelegateCommand<string>(Get_Command);
            Eight = new DelegateCommand<string>(Get_Command);
            Nine = new DelegateCommand<string>(Get_Command);
            Zero = new DelegateCommand<string>(Get_Command);
            ClearText = new DelegateCommand<string>(Clear_Command);
            Screen3BackButton = new DelegateCommand<string>(BackButtonClicked);
        }
        private void Get_Command(string value)
        {
            DisplayWordInTextbox = value;
        }
        private void Clear_Command(string value)
        {
            value = string.Empty;
            ClearWordInTextbox = value;
        }
        private void BackButtonClicked(string NavigateToBackPage)
        {
            if (NavigateToBackPage != null)
            {
                _regionManager.RequestNavigate("Shell", NavigateToBackPage);
            }
        }
    }
}
