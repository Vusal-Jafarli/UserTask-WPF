using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Praktika.Models
{
    public class User
    {
        public int axirinci_id = 0;
        public  int id { get; set; }
        public  string name { get; set; }
        public  string username { get; set; }
        public  string email { get; set; }
        public  Address address { get; set; }
        public  string website { get; set; }
        public  Company company { get; set; }

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

        public User(int id, string name, string username, string email, Address address, string website, Company company)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.email = email;
            this.address = address;
            this.website = website;
            this.company = company;
        }

        public User(int axirinci_id)
        {
            this.id = ++axirinci_id;
        }
        public User()
        {

  
        }

        public override string ToString()
        {
            return "Vusal";
        }
    }
}
