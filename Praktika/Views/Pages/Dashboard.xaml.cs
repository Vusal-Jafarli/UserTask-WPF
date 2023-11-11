using Praktika.Models;
using Praktika.ViewModels.PageViewModels;
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

namespace Praktika.Views.Pages
{

    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();

        }
    }
}
