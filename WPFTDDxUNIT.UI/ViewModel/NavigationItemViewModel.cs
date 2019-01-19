using WPFTDDxUNIT.UI.Command;
using System.Windows.Input;
using System;
using Prism.Events;
using WPFTDDxUNIT.UI.Events;

namespace WPFTDDxUNIT.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        private IEventAggregator _eventAggregator;

        public int Id { get; private set; }
        public string DisplayMember { get; set; }
        public ICommand OpenFriendEditViewCommand { get; private set; }

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
            _eventAggregator = eventAggregator;
        }

        private void OnFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().Publish(Id);
        }
    }
}
