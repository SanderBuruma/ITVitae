   M S B A M L   `   `   `  ����G  C3Autoverhuur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:_3Autoverhuur_3Autoverhuur  5          _3Autoverhuur.Data   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:_3Autoverhuur     5      $	��624��5   #   ���#DDD.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  DataGridXML��5
      $
��Left=�6(   $	��240��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��600��6{   $   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$ Hidden=�6�    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$ center=�6C   �� 5       � ��$	 120��6.   5      5      5      �� 5   
   $��Gereden kms:��6   $
��Left=�6'   $��102,284,0,0q�6B   $	��Top=�6W   $��17��6o   $	��153��6{   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��Begindatum:��6   $
��Left=�6&   $��101,306,0,0q�6A   $	��Top=�6V   $��17��6n   $	��153��6z   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   -   5         ��Name$ AddVerhuringButton��5      $��Voeg Toe��6-   $
��Left=�6@   $��102,391,0,0q�6[   $	��Top=�6p   $	��463��6�   
����������	#FFB6B6B66�   �� 5   
   $
��Left=�6   $	��151��6/   $��
85,269,0,0q�6<   ���	#FFADADAD$	��Top=�6c   $	��499��6{    �� RadiusY$
 12.1��6�   	 �� RadiusX$
	 12.1��6�   
 K� ZIndex$
 -1��6�   ���	#FFEAEAEA6�   �� 5   
   -   5        $ VerwijderVerhuringButton��5      $��	Verwijder��63   $
��Left=�6G   $��
10,255,0,0q�6b   $	��Top=�6v   $��70��6�   
����������	#FFB6B6B66�   �� 5   
   -   5         ��Name$ GeredenKmsBox��5      $
��Left=�6)   $��17��6D   $��261,283,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��304��6�   6�   �� 5   
   $��Eindedatum:��6   $
��Left=�6&   $��101,328,0,0q�6A   $	��Top=�6V   $��17��6n   $	��153��6z   $��0,0,5,0q�6�   $��Right=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ BeginDatumBox��5      $
��Left=�6,   $��261,306,0,0q�6G   $	��Top=�6\   $��17��6t   $	��304��6�   $	��2,0q�6�   6�     5   
   -   5        $ EindeDatumBox��5      $
��Left=�6,   $��261,328,0,0q�6G   $	��Top=�6\   $��17��6t   $	��304��6�   $	��2,0q�6�   6�   �� 5   
   -   5         ��Name$ TypeVoertuigBox��5      $
��Left=�6+   $��36��6F   $��261,350,0,0q�6R   $	��Top=�6g   $	��304��6    �� SelectedIndex$ 0��6�   .@�5       �� $
��auto��6   $��10(�6)   $	��4,0q�67   �� 5!      $��busje��6   $��10(�6*   $	��4,0q�68   5"      5#      5$      