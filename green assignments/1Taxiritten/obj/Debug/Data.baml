   M S B A M L   `   `   `  ����F  B1Taxiritten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_5KinderBijslag_5KinderBijslag  5          _5KinderBijslag.Data   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:_5KinderBijslag     5      $	��624��5   #   ���#DDD.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  DataGridXML��5
      $
��Left=�6(   $	��240��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��600��6{   $   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$ Hidden=�6�    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$ center=�6C   �� 5       � ��$	 150��6.   5      5      5      �� 5   
   $��Gereden kms:��6   $
��Left=�6'   $��102,284,0,0q�6B   $	��Top=�6W   $��17��6o   $	��153��6{   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��Begindatum:��6   $
��Left=�6&   $��101,306,0,0q�6A   $	��Top=�6V   $��17��6n   $	��153��6z   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��	Rit Duur:��6   $
��Left=�6$   $��127,363,0,0q�6?   $	��Top=�6T   $��17��6l   $��84��6x   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   -   5         ��Name$ AddTaxiritButton��5      $��Voeg Toe��6+   $
��Left=�6>   $��102,385,0,0q�6Y   $	��Top=�6n   $	��463��6�   
����������	#FFB6B6B66�   �� 5   
   $
��Left=�6   $	��151��6/   $��
85,269,0,0q�6<   ���	#FFADADAD$	��Top=�6c   $	��499��6{    �� RadiusY$
 12.1��6�   	 �� RadiusX$
	 12.1��6�   
 K� ZIndex$
 -1��6�   ���	#FFEAEAEA6�   �� 5   
   -   5        $ VerwijderTaxiritButton��5      $��	Verwijder��61   $
��Left=�6E   $��
10,255,0,0q�6`   $	��Top=�6t   $��70��6�   
����������	#FFB6B6B66�   �� 5   
   -   5         ��Name$ GeredenKmsBox��5      $
��Left=�6)   $��17��6D   $��261,283,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��304��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ BegindatumBox��5      $
��Left=�6,   $��261,306,0,0q�6G   $	��Top=�6\   $��17��6t   $	��304��6�   $	��2,0q�6�   �� 5   
   -   5         ��Name$ RitDuurLabel��5      $��10:00��6&   $
��Left=�66   $��216,363,0,0q�6Q   $	��Top=�6f   $��17��6~   $��48��6�   $��Center=�6�   $��Center=�6�   $��0q�6�   �� 5   
   -   5         ��Name$ RitDuurSlider��5      $
��Left=�6(   $��277,363,0,0q�6C   $	��Top=�6X   $	��288��6p    � Maximum$	 288Q�6|    � Value$	 120Q�6�   �� 5    
   $��
Rit Begin:��6   $
��Left=�6%   $��127,341,0,0q�6@   $	��Top=�6U   $��17��6m   $��84��6y   $��0,0,5,0q�6�   $��Right=�6�   �� 5!   
   -   5        $ RitBeginLabel��5!      $��10:00��6'   $
��Left=�67   $��216,344,0,0q�6R   $	��Top=�6g   $��17��6   $��48��6�   $��Center=�6�   $��Center=�6�   $��0q�6�   �� 5"   
   -	   5        $ RitBeginSlider��5"      $
��Left=�6)   $��277,344,0,0q�6D   $	��Top=�6Y   $	��288��6q   $	 288Q�6}   $	 120Q�6�   6�   5#      5$      