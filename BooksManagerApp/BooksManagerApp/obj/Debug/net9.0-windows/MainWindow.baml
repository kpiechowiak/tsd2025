   M S B A M L   `   `   `  ����J  FBooksManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BooksManagerAppBooksManagerApp  5   	        BooksManagerApp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BooksManagerApp     5   	     � Title$  Books Manager��5   	   $	��600��6   $	��900��6,    � 	Resources 5
         BookTemplate �� Orientation��%  &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   $��5q�62   .+�5      �� $��30��60   ��6   �� *Id+60   �� 5      $	��250��63   $
��10,0q�6?   ��6   �� *Title+6?   �� 5      ��6   �� *IsRead+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   .+�5      �� $
��LOGO��6   $��24(�6$   $
��Bold"�62   $��Center=�6D   $
��0,10q�6a   �� 5      $	��0,5q�6   5      � 5    
   $��1��6   $��10q�6    � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $��* �6#   .+�5&      �� $��0��6   $��10q�6)   .+�5'      �� $��My Books��6   $
��Bold"�6,   $��16(�6>   $��0,0,0,10q�6L   �� 5(      -   5         ��Name$ BooksListBox��5(      #��[  60   �� 5)      -   5        $	��Add��5)      $��80��6'   $��0,10,0,0q�62   6D   5*      (   "BooksManagerApp.BookDetailsControl  5,      -   5          Name$ DetailsPanel��5,   '   $��1��6=   5-      �� 5/   
   $��2��6   $��10q�6"   .+�50      �� $	��0,5q�6   �� 51      $ 
Horizontal=�6   $��Center=�62   .+�52      �� $��Adjust the darkness:��6   $��Center=�68   �� 53       � Minimum$ 0Q�6    � Maximum$	 100Q�6%   	 � Value$	 12Q�63   $	��300��6>   $
��10,0q�6J   �� 54      $��Value 12��6   $��Center=�6,   $
��10,0q�6G   55      56      57      58      