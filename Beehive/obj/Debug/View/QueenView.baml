   M S B A M L   `   `   `  ����M  IWpfControlLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1WpfControlLibrary1  5      B >Beehive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Beehive.ViewModelBeehive.ViewModel 5      5clr-namespace:Beehive.ViewModelBeehive.ViewModel 5	         Beehive.View.QueenView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [WpfControlLibrary1<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1     5      1localclr-namespace:Beehive.ViewModel     5      5	viewmodelclr-namespace:Beehive.ViewModel     5	        � 	Resources  5      ��%    5      .��5      � -   5        $��gridDataContext��5       � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��7, 15, 0, 0q�6   $��0��6*   $��0��67   .+�5      �� $��Zadanie robotnicy:��6   �� 5      -   5         ��Name$ workerBeeJob��5      
���2͚�.@�5      �� $��Zbieranie nektaru��6    �� 
IsSelected . 
 � Tag$ 0��6M   �� 5      $��Wytwarzanie miodu��6   $ 1��6;   �� 5      $��Pielęgnacja jaj��6   $ 2��69   �� 5      $��Nauczanie pszczółek��6   $ 3��6=   �� 5      $��Sprzątanie ula��6   $ 4��68   �� 5       $��Patrol z żądłami��6   $ 5��6:   �� 5!      $��Urlop��6   $ 6��6/   5"      5#      �� 5$   
   $��1��6   $��
7, 7, 0, 0q�6%   .+�5%      �� $��Zmiany:��6   &    WpfControlLibrary1.NumericUpDown  5&      -   5        $��shifts��5&   G      Minimum$ 1��6/      Maximum$ 6��6;      Value$ 1��6U   5'      �� 5(   
   -   5        $��
assignWork��5)      $"��Przypisz tę pracę pszczole��5(      $��1��66   $��2��6C   $��15, 5, 15, 5q�6W   
���2͚�$��Center=�5)   =   $��15(�6X   6f   �� 5*   
   -   5        $��2��5*      $��2��6!   $��10q�62   $(��"Rozpocznij 
 następną 
  zmianę��6>   
���2͚�$��15(�5+   +   69   5,      5-      