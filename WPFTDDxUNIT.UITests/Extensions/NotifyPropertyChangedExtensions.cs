using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTDDxUNIT.UITests.Extensions
{
    public static class NotifyPropertyChangedExtensions
    {
        public static bool IsPropertyChangedFired(this INotifyPropertyChanged notifyPropertyChanged,
            Action action, string propertyName)
        {
            bool eventFired = false;
            notifyPropertyChanged.PropertyChanged += (s, ea) =>
            {
                if (ea.PropertyName == propertyName)
                {
                    eventFired = true;
                }
            };
            action();
            return eventFired;
        }
    }
}
