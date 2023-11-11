using Praktika.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Praktika.ViewModels.WindowViewModels
{
    public class AllUserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User>? users;
        public ObservableCollection<User>? Users
        {
            get => users; set
            {
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Users"));
            }
        }

        public AllUserViewModel()
        {

            string? json = File.ReadAllText("../../../Database/Users.json");
            Users = JsonSerializer.Deserialize<ObservableCollection<User>>(json);

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
