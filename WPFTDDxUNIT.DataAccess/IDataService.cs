using System;
using System.Collections.Generic;
using WPFTDDxUNIT.Model;

namespace WPFTDDxUNIT.DataAccess
{
  public interface IDataService : IDisposable
  {
    Friend GetFriendById(int friendId);

    void SaveFriend(Friend friend);

    void DeleteFriend(int friendId);

    IEnumerable<LookupItem> GetAllFriends();
  }
}
