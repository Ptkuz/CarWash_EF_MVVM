﻿using CarWash_WPF_MVVM.ViewModel;
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

namespace CarWash_WPF_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        //public static DataGrid DataGridServices { get; set; }

        public AddOrder()
        {
            InitializeComponent();
            DataContext = new DataManageVM();

            //DataGridServices = dataGridServices;
        }
    }
}