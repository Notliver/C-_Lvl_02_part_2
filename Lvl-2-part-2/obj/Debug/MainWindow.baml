   M S B A M L   `   `   `  ����G  CLvl-2-part-2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lvl_2_part_2Lvl_2_part_2  5   	       Lvl_2_part_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Lvl_2_part_2     5   	     � Title$  Сотрудники��5   	   $	��450��6   $	��800��6)   .��5	      � $��0,0,3.333,-0.333q�6    � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��EmployeesDataGrid��5         AutoGenerateColumns .     
IsReadOnly . ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Header$) #Персональный номер��5   %      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   7   �� *ID+5   S     5      -   5        LNColumn��$ Фамилия��5   %    . $
 Auto 6H    5   7   �� *	Last name+5   H     5      -   5        FNColumn��$ Имя��5   %    . $
 Auto 6D    5   7   �� *
First name+5   D     5      -   5        PatrCollumn��$ Отчество��5   %    . $
 Auto 6I    5   :   �� *
Patronymic+5   I     5      -   5        	DepColumn��$ Департамент��5   %    . $
 Auto 6L    5   8   �� *
Department+5   L   5      �� 58   
   $��1��6   $��Center=�6%   .+�59      �� -   5        $��AddEmp��5:      $+��%Добавить сотрудника��5;      $��Center=�5<      $��10q�5=      $	��Top=�5>      $	��180��5?      ��5@      �� *
AddCommand+�� 5A      -   5        $��AdjEmp��5B      $7��1Редактировать сотрудников��5C      $��Center=�5D      $��10q�5E      $	��Top=�5F      $	��180��5G      �� 5H      -	   5        $��AdjDep��5I      $9��3Редактировать департаменты��5J      $��Center=�5K      $��10q�5L      $	��Top=�5M      $	��180��5N      �� 5O      -
   5        $��Delete��5P      $!��Удалить список��5Q      $��Center=�5R      $��10q�5S      $	��Top=�5T      $	��180��5U      �� 5V      -   5        $
��Exit��5W      $��
Выход��5X      $��Center=�5Y      $��10q�5Z      $	��Top=�5[      $	��180��5\      5]      5^      5_      