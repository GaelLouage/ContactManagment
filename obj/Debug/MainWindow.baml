   M S B A M L   `   `   `  ����R  NContactManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ContactManagementSystemContactManagementSystem  5   	   (    "ContactManagementSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ContactManagementSystem     5   	     � Title$  ContactManagement��5   	   $	��450��6#   $	��800��60   .��5	      � -   5         � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	txtSearch��5      $��0��6%   $��10q�62   $	��200��6>   $��Center=�6J   $
��Left=�6e   6�   �� 5   
   -   5         ��Name$ cmbOrder��5      $��1��6%   $��0��65   $��10q�6B   $	��200��6N   $��Center=�6Z   $
��Left=�6u   6�   �� 5   
   -   5         ��Name$ 
lvContacts��5      $��1��6'   $��4��64   $��2��6E   $��10q�6Y    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 200��6Y    �� DisplayMemberBinding 63   �� *Name+6Y   �� 5      $��Phone Number��6%   $	 150��6b    6;   �� *Phone+6b   �� 5       $��Email��6%   $	 200��6[    64   �� *Email+6[   5"      5$      �� 5&   
   -   5        	 ��Name$	 	btnCreate��5&      $��Create��6$   $��1��65   $��5��6E   $��10 10 10 10q�6R   $��70��6g   $��40��6r   $
��Left=�6~   6�   �� 5'   
   -   5        $	 	btnUpdate��5'      $��Update��6$   $��1��65   $��5��6E   $��10 10 10 10q�6R   $��70��6g   $��40��6r   $��Center=�6~   6�   �� 5(   
   -   5        $	 	btnDelete��5(      $��Delete��6$   $��1��65   $��5��6E   $��10 10 10 10q�6R   $��70��6g   $��40��6r   $��Right=�6~   6�   5*      5+      