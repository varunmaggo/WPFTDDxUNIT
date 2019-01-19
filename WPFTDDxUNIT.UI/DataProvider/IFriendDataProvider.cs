using WPFTDDxUNIT.Model;

namespace WPFTDDxUNIT.UI.DataProvider
{
    public interface IFriendDataProvider
    {
        Friend GetFriendById(int id);
        void SaveFriend(Friend friend);
        void DeleteFriend(int id);
    }
}
