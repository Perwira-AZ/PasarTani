   M S B A M L   `   `   `  ����D  @PasarTani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PasarTani	PasarTani  5   	   C&clr-namespace:PasarTani.MVVM.ViewModelPasarTani.MVVM.ViewModel  5   	       PasarTani.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PasarTani     5   	   <	viewModel&clr-namespace:PasarTani.MVVM.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��920��6)    � WindowStyle$ SingleBorderWindow=�5
       � 
ResizeMode$ NoResize=�5      
������  � AllowsTransparency$ False��5       � DataContext 5      ,  &PasarTani.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5"      �� $��
Pasar Tani��6   $��Center=�5#   	   $��Center=�5$   	   
�������$��24(�5&   	   �� 5(      -   5         ��Name$ lbLoginGreeting��5(      $��Kelos��61   $��0��6>   $��1��6K   $��30(�6[   $��Right=�6i   $y�Hidden=�6�   
�������$��
0,10,115,0q�6�   6�   �� 5)      -   5        	 ��Name$	 
btnSignOut��5)      $��0��6)   $��1��66   $��30��6F   $��60��6R   $��595,18,35,27q�6]   $y�	Collapsed=�6�   ���	#FFE23F3F
���������6�   �� *HomeViewCommand+.��6�   
Sign Out6�   �� 5,      $��1��6   .+�5-      	� -   5        
 	�Name$
 SignUpViewTitleMenu��5-      $��Sign Up��5.      $��50��5/   	   
�������$��14(�51   	      MenuButtonTheme#��[  52       d� 	IsChecked$
 TrueY�53      $y�Visible=�55      ��54      �� *SignUpViewCommand+55      	� 59      -   5        $
 LoginViewTitleMenu��59      $��Login��5:      $��50��5;   	   
�������$��14(�5=   	   #��[  5>      $
 TrueY�5?      $y�Visible=�5A      ��5@      �� *LoginViewCommand+5A      	� 5D      -   5        $
 HomeViewTitleMenu��5D      $��Beranda��5E      $��50��5F   	   
�������$��14(�5H   	   #��[  5I      $
 TrueY�5J      $y�Visible=�5L      ��5K      �� *HomeViewCommand+5L      	� 5O      -   5        $
 SellerViewTitleMenu��5O      $��Penjual��5P      $��50��5Q   	   
�������$��14(�5S   	   #��[  5T      $y�	Collapsed=�5V      ��5U      �� *SellerViewCommand+5V      	� 5Z      -   5        $
 BuyerViewTitleMenu��5Z      $��Pembeli��5[      $��50��5\   	   
�������$��14(�5^   	   #��[  5_      $y�	Collapsed=�5a      ��5`      �� *BuyerViewCommand+5a      	� 5e      -   5        $
 ProfileViewTitleMenu��5e      $
��Akun��5f      $��50��5g   	   
�������$��14(�5i   	   #��[  5j      $y�	Collapsed=�5l      ��5k      �� *ProfileViewCommand+5l      5o      �� 5q      -	   5        $��1��5q      $��1��5r      $��15q�5s      ��5t      �� *CurrentView+6=   5u      5w      5x      