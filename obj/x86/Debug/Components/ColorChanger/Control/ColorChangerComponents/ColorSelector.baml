   M S B A M L   `   `   `  ����R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�\clr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponentsNArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      b    \ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorSelector   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ColorChangerComponents\clr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents     5      9System&clr-namespace:System;assembly=mscorlib     5      -   5        
������   � 	Resources  5	         	MouseDown �� 
TargetName �� TargetProperty	 W� To g� Duration  MouseUp  
MouseDown2  MouseUp2  
BlurRadius  BlurRadius2  CustomThumbForSlider �� 
TargetType �� Property �� Value �� 
TargetType	 �� Angle
 T� X T� Y � Triggers :� RoutedEvent ��Name J� Opacity
 �� Top J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius  MyCustomStyleForSlider � RowDefinitions m�Name m� Fill m� 	Placement ]�Name ]� Thumb n�Name��%L  &	        &	 t     &	 �     &	 W    &	 �    &	 �    &	 �    7  7   &	 Z    7  �� 5   
   .��5      W� $ changerLigth��6   $ Opacity�6C   $ 1X�6h   $ 0:0:0.10D�6q   5      �� 5   
   .��5      W� $ changerLigth��6   $ Opacity�6C   $ 0X�6h   $ 0:0:0.30D�6q   5      �� 5   
   .��5      W� $ palette��6   $ Opacity�6>   $ 1X�6c   $ 0:0:0.50D�6l   5      �� 5   
   .��5      W� $ palette��6   $ Opacity�6>   $ 0X�6c   $ 0:0:0.50D�6l   5      X�5   
   25Q�6/   X�5   
   15Q�60   �� 5   
   " n�6-   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5       " n�6&   .R�5!      � $��53��6   $��27��6,   z�5"      V� 5#   "   .~�5$   &   �� $	 90Q�66   6C   T� 5%   &   $
 60Q�69   $	 -18Q�6@   6J   5&   #    5(      :� 5)   "   $ 
MouseEnter��6/   [�5*   &   �� 5+   *   8��  6:   5-   #   :� 5.   "   $ 	MouseDown��6/   [�5/   &   �� 50   *   8�� 6:   52   "   .+�55      �� $ changerLigth��6�   $ 0Q�6)   $ 0��6Q   $��53��6`   
������ $��27��6�   ��65   �� *
FinalColor+ 56   "     57   &   $ 25Q�61   6?   59      �� 5:      $��53��6&   $��27��63   $
��Fill=�6?   $[��U/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/changer.png��6O   5;      5<      5>      5?      �� 5A   
   " ��6/   .�5B      ��  � �� 5C      �� 5D      " ��6&   .R�5E      �� #��z��6!   #��z��6K   #��z��6w   ._�5F      �  5G   "   �� 5H   &   $
��Auto �64   �� 5I   &   $
��Auto �64   #��z��6B   �� 5J   &   $
��Auto �64   .+�5L   "   m� $ TopTick��6*   $y�	Collapsed=�6;   # z��6R   $	 Top=�6v   $��4��6�   $��0��6�   m� 5M   "   $ 
BottomTick��6*   $y�	Collapsed=�6>   # z��6U   $ Bottom=�6y   $��4��6�   $��0��6�   ]� 5O   "   $ 
PART_Track��6(   $��1��6<    5P   &   n� 5Q   *   $ Thumb��61   8��  
���   �6n   5S   #   5T      5U      5V      5X      5Y      5\      .��5]      �� 
������ .+�5^   
   �� -   5        $��palette2��5^   =    �� Left$ 53��6   $	 126��6!   $��15��62   $
��Fill=�6M   $\��V/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/choserBG.png��6]   �� 5_   
   -   5        $��palette��5_   I   $ 54��6   $	 127��6!   $��13��62   $ 0Q�6=   $
��Fill=�6X   $[��U/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/palette.png��6h   $	��208��6�   �� 5b   
   -   5        $��
background��5b   <   $ 0��6   $ 0��6    $	��358��6/   $
��Fill=�6N   $^��X/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/background.png��6^   $	��390��6�   �� 5c   
   -   5         ��Name$ ChanelTitle��5c   G   $��Chanel 1��6   $��Rockwell)�6#   $��14(�69   $��	ExtraBold"�6\   ���#838384$ 15��6�   $ 7��6�    5d      3  -System.Windows.Media.Effects.DropShadowEffect  5e         Color$ Black��6#      	Direction$	 150Q�61      
BlurRadius$ 2Q�6A      ShadowDepth$ 2Q�6P   6b   5g      g   aArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorLevelsDisplay  5n   
   -   5           Name$  ColorLevelsDisplay��5n   4   $��50��6P   $	��245��6\   $	 115��6h   $ 41��6z   6�   �� 5o   
   -   5        ! ��Name$! slider1��5o   �   $ 65��6   $	 364��6"   " � Maximum$	" 185Q�63   # � Value$	# 185Q�6A   $��68��6M   #��[ 6Y   $	��224��6�   z�5p      �� 5q      $		 -90Q�6"   60   5s      `   ZArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorSlider  5~   
   -   5        $  Name$$ ColorSliderForRed��5~   -   $	��214��6H   $��82��6U   $	 140��6`   $	 126��6r   6�     5   
   -	   5        $$ ColorSliderForGreen��5   -   $	��214��6J   $��82��6W   $	 222��6b   $	 126��6t   6�     5�   
   -
   5        $$ ColorSliderForBlue��5�   -   $	��214��6I   $��82��6V   $	 301��6a   $	 126��6s   6�   �� 5�   
   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+% �� FallbackValue$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6Z   $��20��6j   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      �� 5�   
   $	 -19��6   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6Z   $��20��6j   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      �� 5�   
   $	 -38��6   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6Z   $��20��6j   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      �� 5�   
   $	 -38��6   $ 21��6$   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6Z   $��20��6j   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      �� 5�   
   $ 21��6   $	 -19��6!   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6[   $��20��6k   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      �� 5�   
   $ 21��6   .+�5�      A� $ 68��6   $ 1Q�6'   $ 63��6g   $��20��6w   
������ $��20��6�   ��63   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6I   5�      A� 5�      $ 68��6   $ 63��6Z   $��20��6j   
������ $��20��6�   ��6'   �� *
FinalColor+$% #ffff00�� 5�        5�      # [ 6!   6H   5�      5�      5�      5�      