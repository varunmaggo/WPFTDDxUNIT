using Autofac;
using WPFTDDxUNIT.DataAccess;
using WPFTDDxUNIT.UI.DataProvider;
using WPFTDDxUNIT.UI.Startup;
using WPFTDDxUNIT.UI.View;
using WPFTDDxUNIT.UI.ViewModel;
using System.Windows;

namespace WPFTDDxUNIT.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootStrapper = new BootStrapper();
            var container = bootStrapper.BootStrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
