   M S B A M L   `   `   `  ����R  NContactManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ContactManagementSystemContactManagementSystem  5   	   $    ContactManagementSystem.Create   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ContactManagementSystem     5   	   -   5          � Title$  Create New Contact��5      $	��250��6#   $	��400��60   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Name:��6   $��0��6    $
��Left=�6-   $��Center=�6H   �� 5   
   -   5         ��Name$ txtName��5      $��0��6#   $��1��60   $��5q�6@   $	��200��6K   $��Center=�6W   �� 5   
   $��Email:��6   $��1��6!   $
��Left=�6.   $��Center=�6I   �� 5   
   -   5        $ txtEmail��5      $��1��6$   $��1��61   $��5q�6A   $	��200��6L   $��Center=�6X   �� 5   
   $��Phone:��6   $��2��6!   $
��Left=�6.   $��Center=�6I   �� 5   
   -   5        $ txtPhone��5      $��2��6$   $��1��61   $��5q�6A   $	��200��6L   $��Center=�6X   �� 5   
   -   5         ��Name$ btnSave��5      $��3��6"   $��5,5,0,0q�6/   $	��100��6@   $
��Left=�6L   $
��Save��6g   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $ 	btnCancel��5      $��3��6$   $��1��61   $��5q�6A   $	��100��6L   $��Right=�6X   $��Cancel��6t   6�   5      5      