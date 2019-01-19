using Autofac;
using WPFTDDxUNIT.Model;
using WPFTDDxUNIT.UI.DataProvider;
using WPFTDDxUNIT.UI.ViewModel;
using WPFTDDxUNIT.UITests.Startup;
using Moq;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WPFTDDxUNIT.UITests.ViewModel
{
    public class DependencyFixture
    {
        public IContainer Container { get; private set; }

        public DependencyFixture()
        {
            Container = new BootStrapper().BootStrap();
        }
    }

    public class NavigationViewModelTests : IClassFixture<DependencyFixture>
    {
        private NavigationViewModel _navViewModel;
        private DependencyFixture _depFixture;

        public NavigationViewModelTests(DependencyFixture depFixture)
        {
            this._depFixture = depFixture;

            var navDataProviderMock = new Mock<INavigationDataProvider>();
            navDataProviderMock.Setup(m => m.GetAllFriends()).Returns(
                new List<LookupItem>
                {
                    new LookupItem { Id = 2, DisplayMember = "Thomas" },
                    new LookupItem { Id = 1, DisplayMember = "Julia" }
                }
            );

            var eventAggregatorMock = new Mock<IEventAggregator>();

            _navViewModel = this._depFixture.Container.Resolve<NavigationViewModel>(
                new NamedParameter("dataProvider", navDataProviderMock.Object),
                new NamedParameter("eventAggregator", eventAggregatorMock.Object)
            );
        }

        [Fact]
        public void ShouldLoadFriends()
        {
            _navViewModel.Load();

            Assert.Equal(2, _navViewModel.Friends.Count);

            var friend = _navViewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal("Julia", friend.DisplayMember);

            friend = _navViewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Thomas", friend.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            _navViewModel.Load();
            _navViewModel.Load();

            Assert.Equal(2, _navViewModel.Friends.Count);
        }
    }

}
