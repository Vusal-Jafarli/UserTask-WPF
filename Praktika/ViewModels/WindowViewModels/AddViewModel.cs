using Praktika.Command;
using Praktika.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Praktika.ViewModels.WindowViewModels
{
    public class AddViewModel
    {

        public User addition_user
        {
            get => addition_user1;

            set
            {
                addition_user1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("addition_user"));
            }
        }



        private ObservableCollection<User>? users;
        private User addition_user1;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<User>? Users
        {
            get => users; set
            {
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Users"));
            }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public AddViewModel(object? param)
        {
            Users = param as ObservableCollection<User>;

            int axirinci_id = 0;

            foreach (var item in Users)
            {
                if (item.id >= axirinci_id)
                {
                    axirinci_id = item.id;
                }
            }

            addition_user = new(axirinci_id);
            addition_user.address = new();
            addition_user.company = new();
            CancelCommand = new RelayCommand(cancel_execute);
            AddCommand = new RelayCommand(add_execute, can_add_execute);

        }

        public AddViewModel()
        {
        }

        public void cancel_execute(object? parameter)
        {
            Window? pencere = parameter as Window;
            pencere?.Close();
        }

        public void add_execute(object? parameter)
        {
            Users?.Add(addition_user);
            string? json_2 = JsonSerializer.Serialize(Users);
            File.WriteAllText("../../../Database/Users.json", json_2);
            addition_user = new();

            Window? pencere = parameter as Window;
            pencere?.Close();
        }

        public bool can_add_execute(object? parameter)
        {
            return (addition_user.name != null && addition_user.username != null
                && addition_user.email != null && addition_user.website != null);
        }
    }
}
