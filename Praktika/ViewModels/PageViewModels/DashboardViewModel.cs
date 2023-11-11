using MaterialDesignThemes.Wpf;
using Praktika.Command;
using Praktika.Models;
using Praktika.ViewModels.WindowViewModels;
using Praktika.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Praktika.ViewModels.PageViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User>? users;
        public event PropertyChangedEventHandler? PropertyChanged;


        public ObservableCollection<User>? Users
        {
            get => users; set
            {
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Users"));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AllUsersCommand { get; set; }

        public void Refresh_data()
        {

            string? json = File.ReadAllText("../../../Database/Users.json");
            Users = JsonSerializer.Deserialize<ObservableCollection<User>>(json);
        }
        public DashboardViewModel()
        {

            string? json = File.ReadAllText("../../../Database/Users.json");
            Users = JsonSerializer.Deserialize<ObservableCollection<User>>(json);

            AddCommand = new RelayCommand(add_execute, add_can_execute);
            RemoveCommand = new RelayCommand(remove_execute, remove_can_execute);
            EditCommand = new RelayCommand(edit_execute, edit_can_execute);
            AllUsersCommand = new RelayCommand(show_all_execute, show_all_can_execute);
        }

        public void add_execute(object? parameter)
        {
            AddWindowView addWindowView = new AddWindowView();
            addWindowView.DataContext = new AddViewModel(parameter);
            addWindowView.ShowDialog();
        }
        public bool add_can_execute(object? parameter)
        {
            return true;
        }
        /////////////////////////////////////////////////

        public void remove_execute(object parameter)
        {
            int index = (int)parameter;
            Users?.RemoveAt(index);

            string? json_2 = JsonSerializer.Serialize(Users);
            File.WriteAllText("../../../Database/Users.json", json_2);

        }
        public bool remove_can_execute(object? parameter)
        {
            var index = parameter as int?;
            return (!(index == null || index == -1));

        }
        /////////////////////////////////////////////////

        public void edit_execute(object parameter)
        {
            int index = (int)parameter;
            EditWindowView edit_window = new EditWindowView();
            edit_window.DataContext = new EditViewModel(Users![index],index,this);
            edit_window.ShowDialog();
        }
        public bool edit_can_execute(object? parameter)
        {
            var index = parameter as int?;
            return (!(index == null || index == -1));
        }
        /////////////////////////////////////////////////
        public void show_all_execute(object? parameter)
        {
            AllUsersView allusersview = new AllUsersView();
            allusersview.ShowDialog();
        }
        public bool show_all_can_execute(object? parameter)
        {
            return true;
        }


    }
}