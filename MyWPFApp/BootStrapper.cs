using System;
using System.Windows;
using MyPresentation.Views;
using Prism.Regions;
using Prism.Unity;
namespace MyWPFApp
{
    [Obsolete]
    public class BootStrapper : UnityBootstrapper
    {
        IRegionManager regionManager;      
       
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
            regionManager = new RegionManager();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeForNavigation<Screen2>("Screen2");
            Container.RegisterTypeForNavigation<WelcomePageView>("WelcomePageView");
        }
        /// <summary>      
        /// Add view(module) from other assemblies and begins with modularity      
        /// </summary>      
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            Type ModuleLocatorType = typeof(MyPresentation.ModuleLocators);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo
            {
                ModuleName = ModuleLocatorType.Name,
                ModuleType = ModuleLocatorType.AssemblyQualifiedName
            });
        }
    }
}
