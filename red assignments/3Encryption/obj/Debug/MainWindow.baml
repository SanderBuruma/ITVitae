   M S B A M L   `   `   `  ����F  B3Encryption, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_3Encryption_3Encryption  5   	       _3Encryption.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_3Encryption     5   	     � Title$&   En & De-Cryptor by Sander Buruma��5   	   $��173.2��66   $	��800��6E   .��5	      � .+�5
   
   �� -   5         ��Name$ FilepathBox��5
      $
��Left=�6'   $��19��6B   $��	50,35,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��571��6�   �� 5   
   -   5         ��Name$ ButtonSelectFile��5      $��Select TXT File��6+   $
��Left=�6E   $��
635,35,0,0q�6`   $	��Top=�6t   $	��134��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0Q�61   � 5      $ 	#FFDADADA��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ ButtonEncrypt��5      $��Encrypt!��6(   $��
207,83,0,0q�6;   $	��Top=�6O   $	��134��6g   $
��Left=�6s   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ White��6#   $ 0Q�61   � 5      $ 	#FFDADADA��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ ButtonDeEncrypt��5      $��De-Encrypt!��6*   $��
346,83,0,0q�6@   $	��Top=�6T   $	��134��6l   $
��Left=�6x   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ White��6#   $ 0Q�61   � 5      $ 	#FFD7D7D7��6#   $ 1Q�65   5       5"      �� 5#   
   -   5        $ EncodeKeyBox��5#      $
��Left=�6(   $��19��6C   $��	50,59,0,0q�6O   $
 Wrap=�6b   $	��Top=�6v   $	��571��6�   $��Liberation Mono)�6�   �� 5$   
   -   5        $ ButtonRngKey��5$      $��Generate Random Key!��6'   $
��Left=�6F   $��
635,59,0,0q�6a   $	��Top=�6u   $	��134��6�   ��5%      �� 5&      $ 0.5,1&�6&   $ 0.5,0&�67    � SpreadMethod$ Repeat=�6J   	 �� RelativeTransform	 5'      V� 5(      .~�5)      �� 
 �� CenterY$	
 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5*       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5+       �� CenterY$	 0.5Q�6.    �� CenterX$	 0.5Q�6<   T� 5,       T� X$ 2Q�61   5-      .��5/      � $ White��6#   $ 0Q�61   � 50      $ 	#FFDDDDDD��6#   $ 1Q�65   51      53      54      55      