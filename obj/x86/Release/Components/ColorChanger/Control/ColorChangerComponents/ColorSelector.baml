   M S B A M L   `   `   `  ���� R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�\clr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponentsNArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem b    \ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorSelector   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ColorChangerComponents\clr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents     9System&clr-namespace:System;assembly=mscorlib     -   
������   � 	Resources     	MouseDown �� 
TargetName �� TargetProperty	 W� To g� Duration  MouseUp  
MouseDown2  MouseUp2  
BlurRadius  BlurRadius2  CustomThumbForSlider �� 
TargetType �� Property �� Value �� 
TargetType	 �� Angle
 T� X T� Y � Triggers :� RoutedEvent ��Name J� Opacity
 �� Top J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius  MyCustomStyleForSlider � RowDefinitions m�Name m� Fill m� 	Placement ]�Name ]� Thumb n�Name��%�  &	        &	 E     &	 �     &	 �     &	 
    &	     &	 "    7  7   &	 �    7  �� .��W� $ changerLigth��$ Opacity�$ 1X�$ 0:0:0.10D��� .��W� $ changerLigth��$ Opacity�$ 0X�$ 0:0:0.30D��� .��W� $ palette��$ Opacity�$ 1X�$ 0:0:0.50D��� .��W� $ palette��$ Opacity�$ 0X�$ 0:0:0.50D�X�25Q�X�15Q��� " n�.���  �@�OverridesDefaultStyle . ��  � �� �� " n�.R�� $��53��$��27��z�V� .~��� $	 90Q�T� $
 60Q�$	 -18Q� :� $ 
MouseEnter��[��� 8��  :� $ 	MouseDown��[��� 8�� .+��� $ changerLigth��$ 0Q�$ 0��$��53��
������ $��27������ *
FinalColor+   $ 25Q��� $��53��$��27��$
��Fill=�$[��U/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/changer.png���� " ��.���  � �� �� " ��.R��� #��z��#��z��#��z��._��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��$y�	Collapsed=�# z��$	 Top=�$��4��$��0��m� $ 
BottomTick��$y�	Collapsed=�# z��$ Bottom=�$��4��$��0��]� $ 
PART_Track��$��1�� n� $ Thumb��8��  
���   �.���� 
������ .+��� -   $��palette2�� �� Left$ 53��$	 126��$��15��$
��Fill=�$\��V/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/choserBG.png���� -   $��palette��$ 54��$	 127��$��13��$ 0Q�$
��Fill=�$[��U/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/palette.png��$	��208���� -   $��
background��$ 0��$ 0��$	��358��$
��Fill=�$^��X/ArduinoManagementSystem;component/Components/ColorChanger/Control/Images/background.png��$	��390���� -    ��Name$ ChanelTitle��$��Chanel 1��$��Rockwell)�$��14(�$��	ExtraBold"����#838384$ 15��$ 7�� 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   	Direction$	 150Q�   
BlurRadius$ 2Q�   ShadowDepth$ 2Q�g   aArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorLevelsDisplay  -      Name$  ColorLevelsDisplay��$��50��$	��245��$	 115��$ 41���� -   ! ��Name$! slider1��$ 65��$	 364��" � Maximum$	" 185Q�# � Value$	# 185Q�$��68��#��[ $	��224��z��� $		 -90Q�`   ZArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents.ColorSlider  -   $  Name$$ ColorSliderForRed��$	��214��$��82��$	 140��$	 126��  -	   $$ ColorSliderForGreen��$	��214��$��82��$	 222��$	 126��  -
   $$ ColorSliderForBlue��$	��214��$��82��$	 301��$	 126���� .+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+% �� FallbackValue$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ �� $	 -19��.+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ �� $	 -38��.+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ �� $	 -38��$ 21��.+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ �� $ 21��$	 -19��.+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ �� $ 21��.+�A� $ 68��$ 1Q�$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ A� $ 68��$ 63��$��20��
������ $��20������ *
FinalColor+$% #ffff00��   # [ 