   M S B A M L   `   `   `  ����  6Camping    _6Camping.Data   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��824��5   #   ���#DDD  � Language$  en-NL�6A   .��5      � .+�5	   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXML��5	      $
��Left=�6(   $	��203��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��800��6{   $   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$ Hidden=�6�    � 	Resources 5
      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$ center=�6C   �� 5       � ��$	 100��6.   5      5      5      �� 5   
   -   5         ��Name$ AddTransportItemButton��5      $��Voeg Toe��61   $
��Left=�6D   $��194,395,0,0q�6_   $	��Top=�6t   $	��286��6�   
����������	#FFB6B6B66�   �� 5   
   $
��Left=�6   $	��200��6/   $��
96,225,0,0q�6<   ���	#FFADADAD$	��Top=�6c   $	��490��6{   	 �� RadiusY$
	 12.1��6�   
 �� RadiusX$

 12.1��6�    K� ZIndex$ -1��6�   ���	#FFEAEAEA6�   �� 5   
   -   5        $" VerwijderTransportItemButton��5      $��	Verwijder��67   $
��Left=�6K   $��
13,225,0,0q�6f   $	��Top=�6z   $��65��6�   
����������	#FFB6B6B66�   �� 5   
   $��Naam Huurder��6   $
��Left=�6'   $��180,244,0,0q�6B   $	��Top=�6W   $��0q�6o   $��Right=�6{   $��90��6�   �� 5   
   $��
Begin Huur��6   $
��Left=�6%   $��180,265,0,0q�6@   $	��Top=�6U   $��0q�6m   $��Right=�6y   $��90��6�   $��18��6�   �� 5   
   $��Plaats Breedte in m3��6   $
��Left=�6/   $��180,319,0,0q�6J   $	��Top=�6_   $��0q�6w   $��Right=�6�   $	��115��6�   �� 5   
   -   5         ��Name$ NaamHuurderBox��5      $
��Left=�6*   $��16��6E   $��275,244,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��191��6�   6�   �� 5   
   -   5        $ PlaatsBreedteM3��5      $
��Left=�6+   $��16��6F   $��300,319,0,0q�6R   $
 Wrap=�6g   $��10��6{   $	��Top=�6�   $	��166��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ BeginHuurDatePicker��5      $
��Left=�62   $��275,265,0,0q�6M   $	��Top=�6b   $	��191��6z   $��18��6�   $	��2,0q�6�   6�   �� 5   
   $��
Einde Huur��6   $
��Left=�6%   $��180,288,0,0q�6@   $	��Top=�6U   $��0q�6m   $��Right=�6y   $��90��6�   $��18��6�     5   
   -   5        $ EindeHuurDatePicker��5      $
��Left=�62   $��275,288,0,0q�6M   $	��Top=�6b   $	��191��6z   $��18��6�   $	��2,0q�6�   6�   �� 5    
   -   5         ��Name$ AutoCheckBox��5       $
��Auto��6)   $
��Left=�68   $��420,375,0,0q�6S   $	��Top=�6h   �� 5!   
   -	   5        $ HondCheckBox��5!      $
��Hond��6)   $
��Left=�68   $��346,375,0,0q�6S   $	��Top=�6h   �� 5"   
   $��Aantal Personen��6   $
��Left=�6*   $��180,340,0,0q�6E   $	��Top=�6Z   $��0q�6r   $��Right=�6~   $	��115��6�   �� 5#   
   -
   5        $ AantalPersonenBox��5#      $
��Left=�6-   $��16��6H   $��300,340,0,0q�6T   $
 Wrap=�6i   $��1��6}   $	��Top=�6�   $	��166��6�   6�   5$      5%      