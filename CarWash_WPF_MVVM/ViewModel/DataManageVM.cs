using CarWash_WPF_MVVM.Model;
using CarWash_WPF_MVVM.View;
using CarWash_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using CarWash_WPF_MVVM.View;

namespace CarWash_WPF_MVVM.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        private List<object> allCars = DataWorker.GetAllCars();
        public List<object> AllCars 
        {
            get { return allCars; }
            set 
            {
                allCars = value;
                NotifyPropertyChanged("AllCars");
            }
        
        }

        private List<object> allClients = DataWorker.GetAllClients();
        public List<object> AllClients 
        {
            get { return allClients; }
            set 
            { 
                allBoxes = value;
                NotifyPropertyChanged("AllClients");
            
            }
        
        }

        private List<object> allOrders = DataWorker.GetAllOrders();
        public List<object> AllOrders
        {
            get { return allOrders; }
            set
            {
                allOrders = value;
                NotifyPropertyChanged("AllOrders");

            }

        }


        private List<object> allBoxes = DataWorker.GetAllBoxes();
        public List<object> AllBoxes 
        {
            get { return allBoxes; }
            set 
            {
                allBoxes = value;
                NotifyPropertyChanged("AllBoxes");
            
            }
        
        }

        private List<object> allCarBodies = DataWorker.GetAllCarBody();
        public List<object> AllCarBody
        {
            get { return allCarBodies; }
            set
            {
                allCarBodies = value;
                NotifyPropertyChanged("AllCarBody");

            }

        }

        private List<object> allServices = DataWorker.GetAllServices();
        public List<object> AllServices
        {
            get { return allServices; }
            set
            {
                allServices = value;
                NotifyPropertyChanged("AllServices");

            }

        }

        private void OpenAddCarWindow() 
        {
            AddCar addCar = new AddCar();
            SetCenterWindowAndOpen(addCar);

        
        }

        private RelayCommand openAddNewCar;
        public RelayCommand OpenAddNewCar 
        {
            get 
            { 
                return openAddNewCar ?? new RelayCommand(obj =>
                {
                    OpenAddCarWindow();
                });
                
            }
        
        }


        private void SetCenterWindowAndOpen(Window window) 
        { 
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        
        }

        private void UpdateAllDataView() 
        {
            UpdateAllCarsView();
        }

        private void UpdateAllCarsView() 
        {
            AllCars = DataWorker.GetAllCars();
            MainWindow.AllCarsView.ItemsSource = null;
            MainWindow.AllCarsView.Items.Clear();

            MainWindow.AllCarsView.ItemsSource = AllCars;
            MainWindow.AllCarsView.Items.Refresh();
        
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string properryName) 
        { 
            if(PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(properryName));
        
        }
    }
}
