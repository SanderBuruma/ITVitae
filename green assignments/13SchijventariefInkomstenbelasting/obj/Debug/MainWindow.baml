   M S B A M L   `   `   `  ����]  Y13SchijventariefInkomstenbelasting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:_13SchijventariefInkomstenbelasting#_13SchijventariefInkomstenbelasting  5   	   4    ._13SchijventariefInkomstenbelasting.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:_13SchijventariefInkomstenbelasting     5   	     � Title$  Inkomstenbelasting��5   	   $��372.4��6$   $	��500��63   ���#ddd.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PersonenDataGrid��5
      $
��Left=�6-   $	��167��6H   $��	10,10,0,0q�6U   $	��Top=�6h   $	��474��6�    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$
 Left=�6C   �� 5       � ��$	 118��6.   5      5      5      �� 5   
   -   5         ��Name$ VerwijderPersoonButton��5      $��	Verwijder��61   $
��Left=�6E   $��
10,182,0,0q�6`   $	��Top=�6t   $��70��6�   
�������6�   �� 5   
   $��Naam Persoon��6   $
��Left=�6'   $��122,210,0,0q�6B   $	��Top=�6W   $��0q�6o   $��Right=�6{   $��89��6�   �� 5   
   $��Inkomen €��6   $
��Left=�6$   $��153,228,0,0q�6?   $	��Top=�6T   $��0q�6l   $��Right=�6x   $��58��6�   �� 5   
   -   5        $ VoegtoePersoonButton��5      $��Voeg Toe��6/   $
��Left=�6B   $��216,300,0,0q�6]   $	��Top=�6r   $��70��6�   
�������6�   �� 5   
   -   5         ��Name$ NaamBox��5      $
��Left=�6#   $��15��6>   $��216,210,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��107��6�   $��0,-2,0,0q�6�   6�   �� 5   
   -   5        $ 
InkomenBox��5      $
��Left=�6&   $��15��6A   $��216,229,0,0q�6M   $
 Wrap=�6b   $��0��6v   $	��Top=�6   $	��107��6�   $��0,-2,0,0q�6�   6�   �� 5   
   -   5        	 ��Name$	 BelastingVrijeSomLabel��5      $��Belastingvrije Som: €��60   $
��Left=�6P   $��122,276,0,0q�6k   $	��Top=�6�   $��0q�6�   $��Right=�6�   $	��201��6�   �� 5   
   -   5        
 ��Name$
 TariefComboBox��5      $
��Left=�6+   $��225,249,0,0q�6F   $	��Top=�6[   $��98��6s    �� SelectedIndex$ 0��6~   .@�5      �� $��Tariefgroep 1��6   �� 5      $��Tariefgroep 2��6   �� 5       $��Tariefgroep 3��6   �� 5!      $��Tariefgroep 4��6   �� 5"      $��Tariefgroep 5��6   5#      �� 5$   
   ���	#FFF9F9F9$
��Left=�6%   $	��130��6@   $��122,200,0,0q�6M   ���	#FFAEAEAE$	��Top=�6u   $	��214��6�    �� RadiusY$
 19.3��6�    �� RadiusX$
 19.3��6�    K� ZIndex$ -1��6�   5%      5&      