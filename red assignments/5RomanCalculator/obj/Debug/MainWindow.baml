   M S B A M L   `   `   `  ����K  G5RomanCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_5RomanCalculator_5RomanCalculator  5   	   "    _5RomanCalculator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:_5RomanCalculator     5   	     � Title$/  )Roman Numeral Calculator by Sander Buruma��5   	   $	��102��6;   $��604.533��6H   ���	#FFCDCDCD.��5	      � .+�5
   
   �� -   5         ��Name$ 	Value1Box��5
      $
��Left=�6%   $��20��6@   $��	30,10,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��150��6�   $��2q�6�    �� TextAlignment$ Center=�6�    � Cursor$ IBeam��6�   $	��CCC��6�   6�   �� 5   
   -   5        $ 	Value2Box��5      $
��Left=�6%   $��20��6@   $��
218,10,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��150��6�   $��2q�6�   $ Center=�6�   $ IBeam��6�   $��XV��6�   6�   �� 5   
   -   5        $ 	OutputBox��5      $
��Left=�6%   $��20��6@   $��
408,10,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��150��6�   $��2q�6�   $ Center=�6�   {�.  $��CCCXV��6�   	� 5   
   -   5         	�Name$ RadioAdd��5      $��+��6(   $
��Left=�64   $��
162,35,0,0q�6O   $	��Top=�6c   $��1q�6{   $��15��6�   $��25��6�   $��
-12,11,0,0q�6�   6�   	� 5   
   -   5        $ RadioSub��5      $��-��6(   $
��Left=�64   $��
182,35,0,0q�6O   $	��Top=�6c   $��1q�6{   $��15��6�   $��25��6�   $��	-11,6,0,0q�6�   $��18(�6�   6�   	� 5   
   -   5        $ 	RadioMult��5      $��*��6)   $
��Left=�65   $��
202,35,0,0q�6P   $	��Top=�6d   $��1q�6|   $��15��6�   $��25��6�   $��
-11,14,0,0q�6�   6�   	� 5   
   -   5        $ RadioDiv��5      $��/��6(   $
��Left=�64   $��
222,35,0,0q�6O   $	��Top=�6c   $��1q�6{   $��15��6�   $��25��6�   $��
-11,14,0,0q�6�   6�   �� 5   
   -   5         ��Name$ CalculateButton��5      $��=��6*   $
��Left=�66   $��
377,10,0,0q�6Q   $	��Top=�6e   $��20��6}   $��1,-3,0,0q�6�   $��20��6�   $��14(�6�    J� RenderTransformOrigin$ 1.657,0.557&�6�   $��1q�6�   6�   �� 5   
   -	   5         ��Name$ OperatorLabel��5      $��+��6'   $
��Left=�63   $��
186,10,0,0q�6N   $	��Top=�6b   $��27��6z   $��20��6�   $��0,0,0,5q�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   5      5      