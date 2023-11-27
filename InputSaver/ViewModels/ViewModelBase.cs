using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputSaver.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string changedPropertyName)
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedPropertyName)); }
    }
}
