using WPFTDDxUNIT.UI.Events;
using WPFTDDxUNIT.UI.ViewModel;
using Moq;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WPFTDDxUNIT.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock
                .Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            var navItemViewModel = new NavigationItemViewModel(friendId, "Josuke", eventAggregatorMock.Object);
            navItemViewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(e => e.Publish(friendId), Times.Once);
        }
    }
}
