   M S B A M L   `   `   `  ����B  >Beehive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BeehiveBeehive  5   	   M IWpfControlLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1WpfControlLibrary1 5   	   +clr-namespace:Beehive.ViewBeehive.View  5	   	       Beehive.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Beehive     5   	   [WpfControlLibrary1<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1     5   	   +vievclr-namespace:Beehive.View     5	   	     � Title$  
MainWindow��5
   	   $	��600��6   $	��800��6)   
������� � WindowStyle$ ThreeDBorderWindow=�6K    � 
ResizeMode$ NoResize=�5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��1.6* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6    � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $
��1.2* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $��0��6    $��2��60   $��2��6A   $��Przydział prac��5      
���2͚�6,      Beehive.View.QueenView  5   
   -   5          Name$ 	queenView��5   >   $��2��6   $��3��6*   6>   �� 51   
   $��Zapasy��6   $��2��6$   $��3��61   
���2͚�6E   �� 52   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��3��6;   $��Center=�6O   $��Bottom=�53      .+�54      �� -   5        $��amountOfHoney��54      $��Zapasy miodu: 00 mg.��6-   $��5q�6I   �� 55      -   5        $��amountOfNectar��55      $��Zapasy nektaru: 00 mg.��6.   $��5q�6L   �� 56      -   5        $��aliveWorkers��56      $$��Ilość pszczół robotnic: 1.��6,   $��5q�6N   57      �� 58   
   -   5        $��shiftsReports��58      $��3��6'   $��3��64   $��10q�6H   
�������
���2͚�59         Beehive.View.TownHallView  5<   
   -   5          Name$ townHallView��5=      $��4��5<      $��3��6-   $	��Top=�6=   $	��450��6U   5=          Beehive.View.WarehouseView  5>   
   -   5          Name$ warehouseView��5?   *   $��4��5>      $��3��6.   $��Bottom=�6>   $	��100��5?      6*   �� 5@   
   $��
Statystyki��6   
���2͚�$��5q�6B   $��4��6M   $��3��5A      5�      5�      