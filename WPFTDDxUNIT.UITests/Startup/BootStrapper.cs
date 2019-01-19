using Autofac;
using WPFTDDxUNIT.UI.DataProvider;
using WPFTDDxUNIT.UI.ViewModel;
using WPFTDDxUNIT.UITests.ViewModel;

namespace WPFTDDxUNIT.UITests.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationViewModel>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
