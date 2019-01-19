using WPFTDDxUNIT.Model;
using System.Collections.Generic;

namespace WPFTDDxUNIT.UI.DataProvider
{
    public interface INavigationDataProvider
    {
        IEnumerable<LookupItem> GetAllFriends();
    }
}
