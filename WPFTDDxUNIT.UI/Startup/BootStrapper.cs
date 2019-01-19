using Autofac;
using WPFTDDxUNIT.DataAccess;
using WPFTDDxUNIT.UI.DataProvider;
using WPFTDDxUNIT.UI.View;
using WPFTDDxUNIT.UI.ViewModel;
using Prism.Events;

namespace WPFTDDxUNIT.UI.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();

            builder.RegisterType<FriendEditViewModel>()
                .As<IFriendEditViewModel>();

            builder.RegisterType<FriendDataProvider>()
                .As<IFriendDataProvider>();

            builder.RegisterType<NavigationDataProvider>()
                .As<INavigationDataProvider>();

            // worth noting: although the NavigationDataProvider ctor takes *Func*<IDataService>
            // as a param, Autofac can inject the correct dep even though the Func is not being
            // registered here...
            builder.RegisterType<FileDataService>()
                .As<IDataService>();

            return builder.Build();
        }
    }
}
