using Praktika.Models;
using Praktika.ViewModels.WindowViewModels;
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Praktika.ViewModels;
namespace Praktika.Views.Windows
{

    public partial class AllUsersView : Window
    {

        public AllUsersView()
        {
            InitializeComponent();
            DataContext = new AllUserViewModel();
        }

        
    }
}
