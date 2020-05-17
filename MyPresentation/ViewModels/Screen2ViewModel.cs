using CommonServiceLocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;

namespace MyPresentation.ViewModels
{

    public class Screen2ViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;


        public DelegateCommand<string> BillButtonClicked { get; private set; }
        public DelegateCommand LineRechargeButton { get; private set; }
        public DelegateCommand SimReplace { get; private set; }
        public Screen2ViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            BillButtonClicked = new DelegateCommand<string>(BillButton);
            LineRechargeButton = new DelegateCommand(LineRechargeButtonClicked);
            SimReplace = new DelegateCommand(SimReplaceButtonClicked);
        }
        private void BillButton(string navigatepath)
        {
            if (navigatepath != null)
                _regionManager.RequestNavigate("Shell", navigatepath);

        }
        private void LineRechargeButtonClicked()
        {
            MessageBox.Show("Line recharge module coming soon");
        }
        private void SimReplaceButtonClicked()
        {
            MessageBox.Show("Sim Replacement module is coming soon");
        }

    }
}
