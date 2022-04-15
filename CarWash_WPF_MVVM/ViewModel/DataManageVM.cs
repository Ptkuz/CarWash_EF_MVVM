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

        private delegate void UpdateData();
        UpdateData updateData;



        public Guid CarIdCar { get; set; }
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public CarBody CarCarBody { get; set; }

        public DataManageVM() 
        {
            updateData = new UpdateData(UpdateAllCarsView);
            updateData += UpdateAllClientsView;
            updateData += UpdateAllOrdersView;

        }


        // Вывод данных

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


        // Методы открытия окон
        private void OpenAddCarWindow() 
        {
            AddCar addCar = new AddCar();
            SetCenterWindowAndOpen(addCar);

        
        }

        private void OpenAddClientWindow() 
        {
            AddClient addClient = new AddClient();
            SetCenterWindowAndOpen(addClient);
        }

        private void OpenAddOrderWindow() 
        {
            AddOrder addOrder = new AddOrder();
            SetCenterWindowAndOpen(addOrder);
        
        }

        private void OpenAddBoxWindow() 
        {
            AddBox addBox = new AddBox();
            SetCenterWindowAndOpen(addBox);
        }

        private void OpenAddCarBodyWindow() 
        {
            AddCarBody addCarBody = new AddCarBody();
            SetCenterWindowAndOpen(addCarBody);
        }

        private void OpenAddServiceWindow() 
        {
            AddService addService = new AddService();
            SetCenterWindowAndOpen(addService);
        }

        // Команды открытия окон
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

        private RelayCommand openAddNewClient;
        public RelayCommand OpenAddNewClient
        {
            get
            {
                return openAddNewClient ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindow();
                });

            }
        }

        private RelayCommand openAddNewOrder;
        public RelayCommand OpenAddNewOrder
        {
            get
            {
                return openAddNewOrder ?? new RelayCommand(obj =>
                {
                    OpenAddOrderWindow();
                });

            }
        }

        private RelayCommand openAddNewBox;
        public RelayCommand OpenAddNewBox
        {
            get
            {
                return openAddNewBox ?? new RelayCommand(obj =>
                {
                    OpenAddBoxWindow();
                });

            }
        }

        private RelayCommand openAddNewCarBody;
        public RelayCommand OpenAddNewCarBody
        {
            get
            {
                return openAddNewCarBody ?? new RelayCommand(obj =>
                {
                    OpenAddCarBodyWindow();
                });

            }
        }

        private RelayCommand openAddNewService;
        public RelayCommand OpenAddNewService
        {
            get
            {
                return openAddNewService ?? new RelayCommand(obj =>
                {
                    OpenAddServiceWindow();
                });

            }
        }


        // Команды добавления данных

        private RelayCommand addNewCar;
        public RelayCommand AddNewCar
        {
            get
            {
                

                return addNewCar ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddCar(CarManufacturer, CarModel, CarYear, CarCarBody))
                    {
                        updateData();
                        SetNullValuesProrepty();
                        window.Close();
                        MessageBox.Show("Новый автомобиль успешно добавлен", "Добавление автомобиля", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else 
                    {
                        SetNullValuesProrepty();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении автомобиля", "Добавление автомобиля", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }



        private void SetCenterWindowAndOpen(Window window) 
        { 
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        
        }


        private void UpdateAllCarsView() 
        {
            AllCars = DataWorker.GetAllCars();
            MainWindow.AllCarsView.ItemsSource = null;
            MainWindow.AllCarsView.Items.Clear();

            MainWindow.AllCarsView.ItemsSource = AllCars;
            MainWindow.AllCarsView.Items.Refresh();
        
        }

        private void UpdateAllClientsView() 
        {
            AllClients = DataWorker.GetAllClients();
            MainWindow.AllClientsView.ItemsSource = null;
            MainWindow.AllClientsView.Items.Clear();
            MainWindow.AllClientsView.ItemsSource = AllClients;
            MainWindow.AllClientsView.Items.Refresh();
        
        }

        private void UpdateAllOrdersView() 
        {
            AllOrders = DataWorker.GetAllOrders();
            MainWindow.AllOrdersView.ItemsSource = null;
            MainWindow.AllOrdersView.Items.Clear();
            MainWindow.AllOrdersView.ItemsSource = AllOrders;
            MainWindow.AllOrdersView.Items.Refresh();

        }

        private void SetNullValuesProrepty() 
        {
            CarManufacturer = null;
            CarModel = null;
            CarYear = 0;
            CarCarBody = null;
        
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string properryName) 
        { 
            if(PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(properryName));
        
        }
    }
}
