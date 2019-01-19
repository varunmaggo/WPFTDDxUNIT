using WPFTDDxUNIT.Model;
using System;
using WPFTDDxUNIT.UI.DataProvider;

namespace WPFTDDxUNIT.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
        Friend Friend { get; }
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _dataProvider;
        private Friend _friend;

        public FriendEditViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Friend Friend
        {
            get
            {
                return _friend;
            }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public void Load(int friendId)
        {
            Friend = _dataProvider.GetFriendById(friendId);
        }

    }
}
