   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  PromeoCrypto��5      $	��300��6!   $	��400��6.   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $$��Saisir la chaîne à chiffrer:��6   �� 5   
   -   5        $��txtInput��5      $��1��6   $��30��6/   $��5q�6<   $��Center=�6h   �� 5   
   $��2��6   $��Méthode de chiffrement��6    $��5q�6@   .��5      ��  �� Orientation$ 
Horizontal=�6   $��10q�62   $��Center=�6>   .+�5      	� -   5        $��
CheckCesar��5      $��César��60   $��0,0,20,0q�6A   	� 5      -   5        $��CheckVigenere��5      $��Playfair��63   $��0,0,20,0q�6G   	� 5      -   5        $��CheckSubsti��5      $��Substitution��61   $��0,0,20,0q�6I   5      5      �� 5!   
   $��3��6   $��Chaîne chiffrée:��6   $
��auto��68   $
��auto��6E   �� 5"   
   -   5        $��LabelMessCrypte��5"      $��4��6'   $��30��64   
�������$��5,0,5,10q�6S   $��Stretch=�6e   $��Stretch=�6�   
���   �$��1q�6�   $��12(�6�   $��Center=�6�   $
��Bold"�6�   �� 5#   
   -   5        $��Button_copy��5#   !   $��Copie��6   $��Center=�64   $��0,0,0,10q�6Q   $��5��6c   $	��Top=�6p   $��76��6�   ${�False��6�   5$      5%      