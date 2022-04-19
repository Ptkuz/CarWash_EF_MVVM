using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarWash_WPF_MVVM.ViewModel;

namespace CarWash_WPF_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ViewServices.xaml
    /// </summary>
    public partial class ViewServices : Window
    {
        public ViewServices()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
