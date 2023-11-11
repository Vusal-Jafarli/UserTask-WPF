using Praktika.Command;
using Praktika.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using Praktika.ViewModels.PageViewModels;

namespace Praktika.ViewModels.WindowViewModels
{
    public class EditViewModel:INotifyPropertyChanged
    {
        public int change_index { get; set; }
        public object? obj;
        private ObservableCollection<User>? users;
        public ObservableCollection<User>? Users
        {
            get => users; set
            {
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Users"));
            }
        }
        public EditViewModel(User? user,int change_index,object? obj)
        {
            this.obj = obj;
            this.User = new();
            this.User.id = user.id;
            this.User.name = user.name;
            this.User.username = user.username;
            this.User.email = user.email;
            this.User.website = user.website;
            this.User.address = new Address(user.address.city, user.address.street);
            this.User.company = new Company(user.company.name, user.company.bs);
            this.change_index = change_index;
            CancelCommand = new RelayCommand(cancel_execute);
            SaveCommand = new RelayCommand(save_execute, save_can_execute);
        }

        private User? User;

        public User? user
        {
            get { return User; }
            set 
            {
                User = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;


        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

   

        public EditViewModel()
        {
        }

        public void cancel_execute(object? parameter)
        {
            Window? pencere = parameter as Window;
            pencere?.Close();
        }

        public void save_execute(object? parameter)
        {
            string? json = File.ReadAllText("../../../Database/Users.json");
            Users = JsonSerializer.Deserialize<ObservableCollection<User>>(json);

            Users.RemoveAt(change_index);

            Users.Add(user);

            string? json_2 = JsonSerializer.Serialize(Users);
            File.WriteAllText("../../../Database/Users.json", json_2);
            user = new();

            DashboardViewModel? dashboard = obj as DashboardViewModel;
            dashboard?.Refresh_data();
            Window? pencere = parameter as Window;
            pencere?.Close();

            

        }

        public bool save_can_execute(object? parameter)
        {
            return (user.name != null && user.username != null
                && user.email != null && user.website != null);
        }
    }
}
