using WPFTDDxUNIT.Model;
using WPFTDDxUNIT.UI.Events;
using WPFTDDxUNIT.UI.ViewModel;
using WPFTDDxUNIT.UITests.Extensions;
using Moq;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WPFTDDxUNIT.UITests.ViewModel
{
    public class MainViewModelTests
    {
        private MainViewModel _mainViewModel;
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        private Mock<INavigationViewModel> _navViewModelMock;
        private Mock<IEventAggregator> _eventAggregatorMock;
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;

        public MainViewModelTests()
        {
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _navViewModelMock = new Mock<INavigationViewModel>();

            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(_openFriendEditViewEvent);



            _mainViewModel = new MainViewModel(_navViewModelMock.Object,
                CreateFriendEditViewModel, _eventAggregatorMock.Object);
        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditVmMock = new Mock<IFriendEditViewModel>();
            friendEditVmMock
                .Setup(vm => vm.Load(It.IsAny<int>()))
                .Callback<int>(friendId =>
                {
                    friendEditVmMock.Setup(vm => vm.Friend)
                        .Returns(new Friend { Id = friendId });
                });
            _friendEditViewModelMocks.Add(friendEditVmMock);
            return friendEditVmMock.Object;
        }

        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            _mainViewModel.Load();
            _navViewModelMock.Verify(nvm => nvm.Load(), Times.Once);
        }

        [Fact]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);

            Assert.Equal(1, _mainViewModel.FriendEditViewModels.Count);
            var friendEditVm = _mainViewModel.FriendEditViewModels.First();

            Assert.Equal(7, friendEditVm.Friend.Id);
            Assert.Equal(friendEditVm, _mainViewModel.SelectedFriendEditViewModel);

            _friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }

        [Fact]
        public void ShouldAddFriendEditViewModelOnlyOnce()
        {
            _openFriendEditViewEvent.Publish(5);
            _openFriendEditViewEvent.Publish(5);
            _openFriendEditViewEvent.Publish(6);
            _openFriendEditViewEvent.Publish(7);
            _openFriendEditViewEvent.Publish(7);

            Assert.Equal(3, _mainViewModel.FriendEditViewModels.Count);
            Assert.Equal(7, _mainViewModel.SelectedFriendEditViewModel.Friend.Id);
        }

        [Fact]
        public void RaisePropertyChangedEventForSelectedFriendEditView()
        {
            var friendEditVmMock = new Mock<IFriendEditViewModel>();
            bool eventFired = _mainViewModel.IsPropertyChangedFired(() =>
                {
                    _mainViewModel.SelectedFriendEditViewModel = friendEditVmMock.Object;
                },
                nameof(_mainViewModel.SelectedFriendEditViewModel)
            );
            //TODO how to uses xUnit's Assert.Raise* assertions instead of checking our eventFired variable?
            Assert.True(eventFired);
        }
    }
}
