   M S B A M L   `   `   `  ����E  A9MorseCode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_9MorseCode_9MorseCode  5   	       _9MorseCode.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:_9MorseCode     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ White��6    � Offset$ 0Q�6-   � 5      $ 	#FFCDCDCD��6   $ 1Q�61   5      .+�5   
   �� -   5         ��Name$ PlainTextBox��5      $
��Left=�6(   $	��328��6C   $��	48,33,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��276��6�   $��Liberation Mono)�6�   �� 5   
   -   5        $ MorseCodeBox��5      $
��Left=�6(   $	��328��6C   $��
461,33,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��276��6�   $��Liberation Mono)�6�    �� 	IsEnabled . $����-.. . .- .-. / .--- --- .... -. / -... ..- -.-- / ---.. / -- . - . .-. ... / --- ..-. / .--. ..- .-. .--. .-.. . / ..-. .- -... .-. .. -.-. / ..-. --- .-. / -- --- - .... . .-. / ... - --- .--. / ..-. .- - .... . .-. / -. . . -.. ... / -.-- --- ..- / - --- / .... . .-.. .--. / .... .. -- / .--. .-.. --- .-- / - .... . / ..-. .. . .-.. -.. ... ��6�   �� 5   
   $��
Plain Text��6   $
��Left=�6%   $��
153,10,0,0q�6@   $	��Top=�6T    J� RenderTransformOrigin$ 0.292,0.617&�6l   $��63��6�   �� 5   
   $��
Morse Code��6   $
��Left=�6%   $��
560,10,0,0q�6@   $	��Top=�6T   $ 0.292,0.617&�6l   $��88��6�   �� 5   
   -   5        	 ��Name$	 Button2Morse��5      $��----->��6'   $
��Left=�6;   $��369,176,0,0q�6V   $	��Top=�6k   $��48��6�   $��21��6�   �� 5   
   -   5        $	 Button2Plain��5      $��<-----��6'   $
��Left=�6;   $��369,211,0,0q�6V   $	��Top=�6k   $��48��6�   $��21��6�   5      5      