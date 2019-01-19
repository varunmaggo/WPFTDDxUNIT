﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFTDDxUNIT.UI.ViewModel
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}