   M S B A M L   `   `   `  ����D  @PasarTani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PasarTani.MVVM.ViewPasarTani.MVVM.View  5      C&clr-namespace:PasarTani.MVVM.ViewModelPasarTani.MVVM.ViewModel  5      #    PasarTani.MVVM.View.BuyerView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PasarTani.MVVM.View     5      5vm&clr-namespace:PasarTani.MVVM.ViewModel     5        � DataContext  5      -  'PasarTani.MVVM.ViewModel.BuyerViewModel  5   
   .��5      �� $
��Auto=�6   .��5   
   ��  � 	Resources 5       �� 
TargetType �� Property �� Value��%[   '��       �� 5      " ��6   .�5      ��  � ��$ 15, 0, 0, 0q�6/   5      5      .+�5      �� $!��Barang yang dapat anda beli��6   
�������$��28(�5      $
��Left=�5      $��0, 0, 0, 20q�5      � 5      $��Center=�6   .+�5      �� -   5        $��ItemCollection��5      $��1��65   $��0��6B   ��6R   �� *Items+��5      �� 5       .R�5!      �  � Orientation$ 
Horizontal=�6(   5"      ��5$      �� 5%      .R�5&      �� $	��120��6%   $	��175��61    �� CornerRadius$ 10��6>   ���#353340$��10q�6e   ._�5(   "   � .+�5)   &   �� .+�5+   *   �� $��95��61   $��65��6<   $ 6��6H   ���#525252$��0,10,0,0q�6n   $��Center=�6�   ._�5-   .   �� ��64   �� *
ImageURL+5.   +   �� 5/   *   
�������$��16(�6a   $
��Bold"�6o   $��95��6�   $��0,5,0,0q�6�    �� TextAlignment$ Center=�6�   ��64   �� *
ItemName+6�   �� 50   *   
�������$��12(�6w   $��Normal"�6�   $��95��6�   $��0,5,0,0q�6�   $ Center=�6�   ��64   �� *Price+ �� StringFormat$ Rp{0:N2}��6�   �� 51   *   
�������$��12(�6y   $��Normal"�6�   $��95��6�   $��0,5,0,0q�6�   $ Center=�6�   ��64   �� *Stock+$ 
Stock: {0}��6�   �� 53   *   .+�54   .   �� -   5        $��Checkout��54   5   $��0,5,0,0q�6H   $��Center=�6Y   $��75��6w   
���   �
��� ��� 55   2   ��%_   '��       �� 56   6   " ��6<   .�57   :   ��  �@��CornerRadius$ 15��6Y   58   7   59   3   5:   /   5;   +   5=   '   5>   #   5@      5A      5C      5D      5F      5G      5H      