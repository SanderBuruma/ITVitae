   M S B A M L   `   `   `  ����I  E5KinderBijslag, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_5KinderBijslag_5KinderBijslag  5          _5KinderBijslag.Data   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:_5KinderBijslag     5      $	��624��5   #   ���#DDD.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  DataGridXML��5
      $
��Left=�6(   $	��240��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��600��6{   $   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$ Hidden=�6�    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �#bbf63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,0,1q�68   �� 5       � ��
 �   �64   �� 5       � ��$ center=�6C   �� 5       � ��$	 200��6.   5      5      5      �� 5   
   $��	Voornaam:��6   $
��Left=�6$   $��151,312,0,0q�6?   $	��Top=�6T   $��17��6l   $	��122��6x   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��Familienaam:��6   $
��Left=�6'   $��150,334,0,0q�6B   $	��Top=�6W   $��17��6o   $	��122��6{   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��Geboortedatum:��6   $
��Left=�6)   $��150,360,0,0q�6D   $	��Top=�6Y   $��17��6q   $	��122��6}   $��0,0,5,0q�6�   $��Right=�6�   �� 5   
   $��
Peildatum:��6   $
��Left=�6%   $��312,259,0,0q�6@   $	��Top=�6U   $��15��6m   $	��111��6y   $	��5,0q�6�   $��Right=�6�   �� 5   
   -   5         ��Name$ KindVoornaamBox��5      $
��Left=�6+   $��17��6F   $��277,311,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��182��6�   �� 5   
   -   5        $ KindFamilienaamBox��5      $
��Left=�6.   $��17��6I   $��277,334,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��182��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 KindGeboortedatumBox��5      $
��Left=�63   $��277,356,0,0q�6N   $	��Top=�6c   $	��182��6{   
   SelectedDateFormat$

 Long=�6�   ��6�   Z� �� 5   
   -   5         ��Name$ AddKindButton��5      $��Voeg Toe��6(   $
��Left=�6;   $��183,385,0,0q�6V   $	��Top=�6k   $	��276��6�   
����������	#FFB6B6B66�     5   
   -   5        $	 PeildatumBox��5      $
��Left=�6+   $��428,255,0,0q�6F   $	��Top=�6[   $	��182��6s   $

 Long=�6   ��6�   Z� 6�   �� 5   
   $
��Left=�6   $	��120��6/   $��162,299,0,0q�6<   ���	#FFADADAD$	��Top=�6d   $	��320��6|    �� RadiusY$
 12.1��6�    �� RadiusX$
 12.1��6�    K� ZIndex$ -1��6�   ���	#FFEAEAEA6�   �� 5    
   -   5        $ VerwijderKindButton��5       $��	Verwijder��6.   $
��Left=�6B   $��
10,255,0,0q�6]   $	��Top=�6q   $��70��6�   
����������	#FFB6B6B66�   5!      6   