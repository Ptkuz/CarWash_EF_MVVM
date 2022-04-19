using CarWash_DB;
using CarWash_WPF_MVVM.Model;
using CarWash_WPF_MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace CarWash_WPF_MVVM.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {

        List<Guid> IdServices = new List<Guid>();

        private delegate void UpdateData();
        UpdateData updateData;


        // Свойста Автомобиля
        public Guid IdCar { get; set; }
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public CarBody CarCarBody { get; set; }

        // Свойста клиента
        public Guid IdClient { get; set; }
        public string FIO { get; set; }
        public string CarNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Свойства заявки
        public Guid IdOrder { get; set; }
        public Car OrderCar { get; set; }
        public Client OrderClient { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Box OrderBox { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public Status Status { get; set; }

        // Свойста услуги
        public Guid IdService { get; set; }
        public string NameService { get; set; }
        public int PriceService { get; set; }

        // Свойста бокса
        public string NameBox { get; set; }

        // Свойста кузова
        public string NameCarBody { get; set; }


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { 
                SetProperty(ref value);
                MessageBox.Show("Сработало");
            }
        }

        public static Order SelectedOrder { get; set; } = null;

        Dictionary<Guid, int> orderDict = AddOrder.ServicesDict;

        public void SetProperty(ref bool myProperty) 
        { 
            IsSelected = myProperty;
        }
        

        public DataManageVM()
        {
            updateData = new UpdateData(UpdateAllCarsView);
            updateData += UpdateAllClientsView;
            updateData += UpdateAllOrdersView;
            updateData += UpdateAllBoxView;
            updateData += UpdateAllCarBodyView;
            updateData += UpdateAllServiceView;
            updateData += SetNullValuesProrepty;


        }


        // Вывод данных

        private List<object> allCarsWithOrder = DataWorker.GetAllCarsWithOrder();
        public List<object> AllCarsWithOrder
        {
            get { return allCarsWithOrder; }
            set
            {
                allCarsWithOrder = value;
                NotifyPropertyChanged("AllCarsWithOrder");
            }

        }

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
                allClients = value;
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

        private List<object> orderServices = DataWorker.GetOrderServices(SelectedOrder);
        public List<object> OrderServices 
        {
            get { return orderServices; }
            set { orderServices = value; NotifyPropertyChanged("OrderServices"); }
        
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
        private void OpenViewServicesWindow() 
        {
            ViewServices viewServices = new ViewServices();
            SetCenterWindowAndOpen(viewServices);
        
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

        private RelayCommand openViewService;
        public RelayCommand OpenViewService 
        {
            get 
            {
                return openViewService ?? new RelayCommand(obj => 
                {
                    OpenViewServicesWindow();
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

                        window.Close();
                        MessageBox.Show("Новый автомобиль успешно добавлен", "Добавление автомобиля", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении автомобиля", "Добавление автомобиля", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }

        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {


                return addNewClient ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddClient(FIO, CarNumber, PhoneNumber, Email))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новый клиент успешно добавлен", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении клиента", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }

        private RelayCommand addNewOrder;
        public RelayCommand AddNewOrderWindow
        {
            get
            {


                return addNewOrder ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddOrder(OrderCar, OrderClient, BeginDate, EndDate, OrderBox, Price, ref orderDict))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новый заказ успешно добавлен", "Добавление заказа", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении заказа", "Добавление заказа", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }

        private RelayCommand addNewBox;
        public RelayCommand AddNewBox
        {
            get
            {


                return addNewBox ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddBox(NameBox))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новый бокс успешно добавлен", "Добавление бокса", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении бокса", "Добавление бокса", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }

        private RelayCommand addNewCarBody;
        public RelayCommand AddNewCarBody
        {
            get
            {


                return addNewCarBody ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddCarBody(NameCarBody))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новый кузов успешно добавлен", "Добавление кузова", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении кузова", "Добавление кузова", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }
        }

        private RelayCommand addNewService;
        public RelayCommand AddNewService
        {
            get
            {


                return addNewService ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddService(NameService, PriceService))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новая услуга успешно добавлена", "Добавление услуги", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении услуги", "Добавление услуги", MessageBoxButton.OK, MessageBoxImage.Error);

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

        private void UpdateAllBoxView()
        {
            AllBoxes = DataWorker.GetAllBoxes();
            MainWindow.AllBoxesView.ItemsSource = null;
            MainWindow.AllBoxesView.Items.Clear();
            MainWindow.AllBoxesView.ItemsSource = AllBoxes;
            MainWindow.AllBoxesView.Items.Refresh();
        }

        private void UpdateAllCarBodyView()
        {
            AllCarBody = DataWorker.GetAllCarBody();
            MainWindow.AllCarBodyView.ItemsSource = null;
            MainWindow.AllCarBodyView.Items.Clear();
            MainWindow.AllCarBodyView.ItemsSource = AllCarBody;
            MainWindow.AllCarBodyView.Items.Refresh();

        }

        private void UpdateAllServiceView()
        {
            AllServices = DataWorker.GetAllServices();
            MainWindow.AllServicesView.ItemsSource = null;
            MainWindow.AllServicesView.Items.Clear();
            MainWindow.AllServicesView.ItemsSource = AllServices;
            MainWindow.AllServicesView.Items.Refresh();

        }

        private void SetNullValuesProrepty()
        {
            CarManufacturer = null;
            CarModel = null;
            CarYear = 0;
            CarCarBody = null;

            FIO = null;
            CarNumber = null;
            PhoneNumber = null;
            Email = null;

            OrderCar = null;
            OrderClient = null;
            BeginDate = default;
            EndDate = default;
            OrderBox = null;
            Discount = 0;
            Price = 0;
            Status = null;

            NameService = null;
            PriceService = 0;


        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string properryName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(properryName));

        }



        private RelayCommand onChecked;
        public RelayCommand OnChecked
        {
            get
            {


                return onChecked ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (DataWorker.AddService(NameService, PriceService))
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Новая услуга успешно добавлена", "Добавление услуги", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateData();
                        window.Close();
                        MessageBox.Show("Произошла ошибка при добавлении услуги", "Добавление услуги", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                });

            }

        }

        private void UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                //var checkBoxValue = AddOrder.DataGridServices.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Автомойка", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
    }
}
