using CommonServiceLocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;

namespace MyPresentation.ViewModels
{

    public class Screen1ViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;


        public DelegateCommand<string> EnglishButton { get; private set; }
        public DelegateCommand ArabicButton { get; set; }
        public Screen1ViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            EnglishButton = new DelegateCommand<string>(EnglishButtonClicked);
            ArabicButton = new DelegateCommand(ArabicButtonClicked);
        }
        private void EnglishButtonClicked(string navigatepath)
        {
            if (navigatepath != null)
                _regionManager.RequestNavigate("Shell", navigatepath);

        }
        private void ArabicButtonClicked()
        {
            MessageBox.Show("Arabic modile coming soon");
        }
        
    }
}
