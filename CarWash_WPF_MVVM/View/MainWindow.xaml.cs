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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllCarsView;
        public static ListView AllClientsView;
        public static ListView AllOrdersView;
        public static ListBox AllBoxesView;
        public static ListBox AllCarBodyView;
        public static ListView AllServicesView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();

            AllCarsView = ViewAllCars;
            AllClientsView = ViewAllClients;
            AllOrdersView = ViewAllOrders;
            AllBoxesView = ViewAllBoxes;
            AllCarBodyView = ViewAllCarBody;
            AllServicesView = ViewAllServices;

        }
    }
}
