using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProductsTest.ViewModel.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase()
        {
            RegisterCommands();
            RegisterCollections();
        }
        protected virtual void RegisterCommands(){}
        protected virtual void RegisterCollections() { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
