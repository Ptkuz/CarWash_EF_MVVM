   M S B A M L   `   `   `  ����K  GCarWash_WPF_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CarWash_WPF_MVVM.ViewCarWash_WPF_MVVM.View  5   	   $    CarWash_WPF_MVVM.View.AddOrder   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:CarWash_WPF_MVVM.View     5   	   -   5        $��AddNewOrder��5   4     � Title$  AddOrder��6	   $	��550��6   $
��1100��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��1200* �6   �� 5      $	��60* �6   �� 5      $
��100* �6   .+�5   
   �� $��0��6   .+�5      �� $.��(Добавить новую запись��6   $��18(�65   $
��Bold"�6C   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��0,0,10,0q�6   .+�5      �� $)��#Список автомобилей��6   &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns$ False��6f   $	��350��6�   ��6   �� *AllCarsWithOrder+ �� SelectedItem 6D   �� *
OrderCar+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Производитель��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6.   �� *Manufacturer+6O     5      $# Название полное��6H    6.   �� *Model+6H     5      $ Год выпуска��6G    6.   �� *Year+6G   5      5      �� 5      $��0,0,10,0q�6   .+�5      �� $#��Список клиентов��6     5       $ False��6c   $	��350��6   ��6   �� *
AllClients+ 6>   �� *OrderClient+ 5!        5"      $ ФИО��6F    6.   �� *FIO+6F     5#      $% Номер автомобиля��6L    6.   �� *	CarNumber+6L     5$      $! Номер телефона��6N    6.   �� *PhoneNumber+6N     5%      $ Email��6H    6.   �� *Email+6H   5'      5(      �� 5)      .+�5*      �� $��Список услуг��6     5+      -   5          Name$ dataGridServices��5+      $ False��6Y   $	��350��6u   ��65   �� *AllServices+ 5,      4  .System.Windows.Controls.DataGridCheckBoxColumn  5-      -   5        CheckBoxColumn��$ Выбрать��5-   d    6I   �� *Choise+	   	CellStyle	 5.      �� 5/   "   .�50   &   -   5        52   #   54        55      $ Id Услуги��6L    6.   �� *	IdService+6L     56      $ Услуга��6N    6.   �� *NameService+6N     57      $ Цена��6O    6.   �� *PriceService+6O   59      5:      5;      �� 5<   
   $��2��6   $ 
Horizontal=�6"   .+�5=      �� $��Дата начала: ��6   (  "System.Windows.Controls.DatePicker  5>      
   SelectedDate
 6   �� *	BeginDate+�� 5?      $#��Дата окончания: ��6     5@      
 6   �� *	EndDate+�� 5A      $��
Бокс: ��6   �� 5B       �� DisplayMemberPath$ NameBox��68   $	��200��6v   ��6   �� *
AllBoxes+ 6T   �� *
OrderBox+6v   �� 5C      $��
Цена: ��6   �� 5D      -   5         ��Name$ 
txbx_Price��5D   R    �� 
IsReadOnly$
 True��6f   $	��200��6x   ��6   �� *Price+ �� UpdateSourceTrigger$ PropertyChanged=�6x   5E      �� 5F   
   $��3��6   $��0,10,0,0q�6"   .+�5G      �� $��Добавить��6;   $	��200��6N   ��6   �� *AddNewOrderWindow+��6Z   ��  �� ElementName$ AddNewOrder��5H      5I      5J      