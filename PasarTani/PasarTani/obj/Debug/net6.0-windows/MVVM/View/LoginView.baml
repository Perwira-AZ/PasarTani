   M S B A M L   `   `   `  ����D  @PasarTani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PasarTani.MVVM.ViewPasarTani.MVVM.View  5      #    PasarTani.MVVM.View.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PasarTani.MVVM.View     5      .��5	      � .+�5
   
   �� 
���   �$��1q�6%     �� CornerRadius$  20��69   $��Center=�6K   $	��Top=�6h   $	��263��6�   ��5      �� 5       �� 
StartPoint$
 0, 0&�6&    �� EndPoint$
 1, 2&�68   .��5      �  � Color$ #844EFF��6#    � Offset$	 0.0Q�63   � 5      $ #4BB2FF��6#   $ 1Q�63   5      ._�5      � $��28,28,28,28q�6   .+�5      �� $
��Wrap=�6   $��Login��60   $��0,15,0,0q�6=   $��24(�6O   $
��Bold"�6]   
�������$��Center=�6�   $	��Top=�6�   $��36��6�   �� 5      $��Center=�6   $��Center=�6:   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $	��Top=�6W   $��0,0,0,16q�6o   .+�5      �� $��Email:��6    $��81��61   $��Right=�6<   $��Center=�6_   
�������$��16(�6�   $
��Left=�6�   �� 5      -   5         ��Name$ txtEmail��5   "    �� TextWrapping$
 Wrap=�64   
�������$��Center=�6\   $	��180��6~   $��32��6�   .��6�    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%_   '��       �� 5   "   "	 ��6(   .�5   &   �� 
 �@��CornerRadius$ 15��6E   5   #   5      .��61   5      5      �� 5      $ 
Horizontal=�6!   $��Center=�6:   $	��Top=�6W   .+�5       �� $��	Password:��6    $��81��64   $��Right=�6?   $��Center=�6b   
�������$��16(�6�   �� 5!      $��30��6"   $	��180��6.   
�������$  15��6M   ._�5"      G� -   5         G�Name$ passPassword��5"   *   
������ $��Center=�6Z   $
��Left=�6|   $	��180��6�   
������ 6�   5#      5$      5%      �� 5'      $ 
Horizontal=�6   $��Bottom=�66   $��Center=�6Q   $��41��6n   .+�5(      �� -   5         ��Name$ 	btnSeller��5(      ���#ffc554
�������$��0q�6X   $
��Left=�6l   $	��120��6�   $��29��6�   $��Center=�6�   $��0,0,10,0q�6�   .��6�   Login as Seller 5*      ��%_   '��       �� 5+      "	 ��6$   .�5,   "   �� 
 �@��CornerRadius$ 15��6A   5-      5.      5/      �� 50      -   5        $ btnCustomer��50      ���#4eff91
�������$��0q�6Z   $
��Left=�6n   $��Center=�6�   $	��120��6�   $��32��6�   .��6�   Login as Customer 52      ��%_   '��       �� 53      "	 ��6$   .�54   "   �� 
 �@��CornerRadius$ 15��6A   55      56      57      58      59      5:      5;      5<      