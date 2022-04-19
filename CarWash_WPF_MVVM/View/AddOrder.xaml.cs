using CarWash_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CarWash_WPF_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public static Dictionary<Guid, int> ServicesDict = new Dictionary<Guid, int>();
        static int fullPrice = default;
        public static int FullPrice { get { return fullPrice; } set { fullPrice = value; } }

        public AddOrder()
        {
            InitializeComponent();
            DataContext = new DataManageVM();


        }

        public void OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.dataGridServices.Columns[0].GetCellContent(this.dataGridServices.SelectedItem);
                if (checkBoxValue != null)
                {
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    object item = dataGridServices.SelectedItem;
                    string IdService = (dataGridServices.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                    string PriceService = (dataGridServices.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                    bool boolId = Guid.TryParse(IdService, out Guid ID);
                    bool boolPrice = int.TryParse(PriceService, out int Price);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    if (boolId && boolPrice)
                    {
                        ServicesDict.Add(ID, Price);
                        FullPrice += Price;
                        txbx_Price.Text = FullPrice.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Автомойка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private void UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkBoxValue = this.dataGridServices.Columns[0].GetCellContent(this.dataGridServices.SelectedItem);
                if (checkBoxValue != null)
                {
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    object item = dataGridServices.SelectedItem;
                    string IdService = (dataGridServices.SelectedCells[1].Column.GetCellContent(item) as TextBlock)!.Text;
                    string PriceService = (dataGridServices.SelectedCells[3].Column.GetCellContent(item) as TextBlock)!.Text;
                    bool boolId = Guid.TryParse(IdService, out Guid ID);
                    bool boolPrice = int.TryParse(PriceService, out int Price);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    if (boolId && boolPrice)
                    {
                        FullPrice -= Price;
                        txbx_Price.Text = FullPrice.ToString();
                        ServicesDict.Remove(ID);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Автомойка", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
    }
}
