   M S B A M L   `   `   `  ����H  D4b Dierenpark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_4b_Dierenpark_4b_Dierenpark  5   	       _4b_Dierenpark.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_4b_Dierenpark     5   	     � Title$  
Dierenpark��5   	   $��342.8��6   $��635.4��6+   ���#DDD � 
ResizeMode$ NoResize=�6K   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataGrid1��5
      $
��Left=�6&   $	��111��6A   $	��Top=�6N   $	��360��6f   $��2,44,0,0q�6r    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$
 Left=�6C   �� 5       � ��$	 120��6.   5      5      5      �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��100��6@   $��
37,178,0,0q�6M   ���	#FF898989$	��Top=�6t   $	��230��6�    �� RadiusY$
 16.5��6�    �� RadiusX$
 16.5��6�   �� 5   
   -   5        	 ��Name$	 KinderenSlider��5      $
��Left=�6)   $��129,221,0,0q�6D   $	��Top=�6Y   $	��127��6q   
 �� IsSnapToTickEnabled
 .  � Maximum$ 20Q�6�   6�   �� 5   
   -   5         ��Name$ KinderenLabel��5      $��Kinderen: 0��6'   $
��Left=�6=   $��
47,221,0,0q�6X   $	��Top=�6l   $��18��6�   $��0q�6�   $��77��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ FamilieNaam��5      $
��Left=�6'   $��16��6B   $��129,200,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��127��6�   6�   �� 5   
   $��
Achternaam��6   $
��Left=�6%   $��
47,200,0,0q�6@   $	��Top=�6T   $��16��6l   $��0q�6x   $��77��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ VoegFamilieToeButton��5      $��Voeg Toe��6/   $
��Left=�6B   $��118,247,0,0q�6]   $	��Top=�6r   $��75��6�   
�������6�   �� 5   
   $��>��6   $
��Left=�6   $��367,105,0,0q�67   $	��Top=�6L   $��16��6d   $��0q�6p   $��7��6|   $��Right=�6�     5   
   -   5        $ 	DataGrid2��5      $
��Left=�6&   $��90��6A   $��
379,52,0,0q�6M   $	��Top=�6a   $	��214��6y    5      ��%  '        �� 5      "  6   .�5       ��  � �� �#bbf63   �� 5!       � ��$ SemiBold"�63   �� 5"       � ��$ 0,0,0,1q�68   �� 5#       � ��
 �   �64   �� 5$       � ��$
 Left=�6C   �� 5%       � ��$	 100��6.   5&      5'      5(      �� 5)   
   ���	#FFF4F4F5$
��Left=�6%   $	��100��6@   $��379,178,0,0q�6M   ���	#FF898989$	��Top=�6u   $	��214��6�   $
 16.5��6�   $
 16.5��6�   �� 5*   
   -   5        $ PersoonNaam��5*      $
��Left=�6'   $��16��6B   $��470,200,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��113��6�   6�   �� 5+   
   $
��Naam��6   $
��Left=�6   $��374,200,0,0q�6:   $	��Top=�6O   $��16��6g   $��0q�6s   $��77��6   $��Right=�6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ GeboorteDatumPicker��5,      $
��Left=�62   $��470,222,0,0q�6M   $	��Top=�6b   $��17��6z   $	��113��6�   $��2,0,0,0q�6�   �� 5-   
   $��Geboortedatum��6   $
��Left=�6(   $��374,223,0,0q�6C   $	��Top=�6X   $��16��6p   $��0q�6|   $��91��6�   $��Right=�6�   �� 5.   
   $��Familie��6   $
��Left=�6"   $��108,182,0,0q�6=   $	��Top=�6R   $��16��6j   $��0q�6v   $��77��6�   $��Right=�6�   $
��Bold"�6�   �� 5/   
   $��
Volwassene��6   $
��Left=�6%   $��449,179,0,0q�6@   $	��Top=�6U   $��16��6m   $��0q�6y   $��77��6�   $��Right=�6�   $
��Bold"�6�   �� 50   
   -	   5        $ VoegPersoonToeButton��50      $��Voeg Toe��6/   $
��Left=�6B   $��449,252,0,0q�6]   $	��Top=�6r   $��75��6�   
�������6�     51   
   -
   5        $ 	Peildatum��51      $
��Left=�6(   $��272,198,0,0q�6C   $	��Top=�6X   $��17��6p   $	��102��6|   $��2,0,0,0q�6�   6�   �� 52   
   $��	Peildatum��6   $
��Left=�6$   $��272,177,0,0q�6?   $	��Top=�6T   $��16��6l   $��0q�6x   $��77��6�   $��Right=�6�   $
��Bold"�6�   �� 53   
   -   5        $ VerwijderPersoonButton��53      $��	Verwijder��61   $
��Left=�6E   $��451,142,0,0q�6`   $	��Top=�6u   $��75��6�   
�������6�   �� 54   
   -   5        $ VerwijderFamilieButton��54      $��	Verwijder��61   $
��Left=�6E   $��129,154,0,0q�6`   $	��Top=�6u   $��75��6�   
�������6�   �� 55   
   $��Gezinnen��6   $
��Left=�6#   $��
140,23,0,0q�6>   $	��Top=�6R   $��16��6j   $��0q�6v   $��77��6�   $��Right=�6�   $
��Bold"�6�   �� 56   
   $��Volwassenen��6   $
��Left=�6&   $��
438,31,0,0q�6A   $	��Top=�6U   $��16��6m   $��0q�6y   $��77��6�   $��Right=�6�   $
��Bold"�6�   57      58      