using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Praktika.Services
{
    public interface NotificationService : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler? PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName] string? propertyname = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        //}

    }
}
