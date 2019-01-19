using WPFTDDxUNIT.Model;
using WPFTDDxUNIT.UI.DataProvider;
using WPFTDDxUNIT.UI.ViewModel;
using WPFTDDxUNIT.UITests.Extensions;
using Moq;
using Xunit;

namespace WPFTDDxUNIT.UITests.ViewModel
{
    public class FriendEditViewModelTests
    {
        const int _friendId = 317;
        private Mock<IFriendDataProvider> _dataProviderMock;
        private FriendEditViewModel _editVm;

        public FriendEditViewModelTests()
        {
            _dataProviderMock = new Mock<IFriendDataProvider>();
            _dataProviderMock
                .Setup(dp => dp.GetFriendById(_friendId))
                .Returns(new Friend { Id = _friendId, FirstName = "Josuke" });

            _editVm = new FriendEditViewModel(_dataProviderMock.Object);
        }

        [Fact]
        public void ShouldLoadFriend()
        {
            Assert.Null(_editVm.Friend);
            _editVm.Load(_friendId);

            Assert.NotNull(_editVm.Friend);
            Assert.Equal(_friendId, _editVm.Friend.Id);

            _dataProviderMock.Verify(dp => dp.GetFriendById(_friendId), Times.Once);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventForFriend()
        {
            Assert.Null(_editVm.Friend);
            bool eventFired = _editVm.IsPropertyChangedFired(() =>
                {
                    _editVm.Load(_friendId);
                },
                nameof(_editVm.Friend));
            Assert.True(eventFired);
        }
    }
}
