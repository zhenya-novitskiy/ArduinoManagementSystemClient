   M S B A M L   `   `   `  ����  ArduinoManagementSystem3    -ArduinoManagementSystem.Components.IconButton   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor 	 ControlMediumColor 
 ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $  ProgressBarIndicatorAnimatedFill �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius (�Name J� Opacity'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty g� Duration �� 
TargetName W� From	 W� To �� Triggers��%n  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     &	     &		 %    &	
 F    &	 g    &	 �    &	 �    &	 �    &	     &	 .    &	 O    &	 p    &	 �    &	 �    &	 �    &	 �    &	     &	 2    &	 O    &	 p    &	 �    &	 X    '�� �    ��5
   
   	#FFE8EDF9��6/   ��5   
   	#FFC5CBF9��69   ��5   
   	#FF7381F9��68   ��5   
   	#FFE8EDF9��6=   ��5   
   	#FFC5CBF9��6<   ��5   
   	#FF888888��6;   ��5   
   	#FFC5CBF9��6;   ��5   
   	#FFDDDDDD��6:   ��5   
   	White��61   ��5   
   	#FF7381F9��66   ��5   
   	#FF211AA9��64   ��5   
   	#FF3843C4��69   ��5   
   	#FF211AA9��67   ��5   
   	#FF444444��6.   ��5   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124��6T   ��5!   
   	#FFCCCCCC��64   ��5"   
   	#FF888888��65   ��5#   
   	#FF444444��63   ��5%   
   	#FF888888��6;   ��5&   
   	#FF444444��6:   ��5(   
   	#FFAAAAAA��6<   ��5)   
   	#FF888888��6;   ��5+   
   	Black��6;   ��5.   
   	#FFC5CBF9��62   ��5/   
   	Black��6>   ��50   
   	#FFC5CBF9��68   ��52   
   	#FF3843C4��67   �� 54   
   $ 0.5,1&�55      $ 0.5,0&�56      .��57      � # �  6   $ 0Q�58      � 59      # � 	 6   $	 0.5Q�5:      � 5;      # �  6   $ 1Q�5<      5=      �� 5?   
   $	 0,0&�5@      $	 1,0&�5A      ��5C      � � 5D      $ 	#000000FF��6#   $ 0Q�5E      � 5F      $ 	#600000FF��6#   $	 0.4Q�5G      � 5H      $ 	#600000FF��6#   $	 0.6Q�5I      � 5J      $ 	#000000FF��6#   $ 1Q�5K      5L      5N      �� 5S   
   " ��6   .�5T      ��  �@J�SnapsToDevicePixels . 64   �� 5U       �@�OverridesDefaultStyle . 66   �� 5V       � �� 5W      �� 5X      " ��6&   .R�5Y      �� $	 Border��6U   #��z��6!   $
 2��6e   $��1q�6v   ._�5Z      � .+�5[   "   (� $ DefaultState��6*   #��z��6@   #��z��6`   $ 1Q�6�   .��5\   &   �� 
���  ����66   �� *DefaultState+6w   5]   #   (� 5^   "   $ MouseOverState��6*   #��z��6B   #��z��6b   $ 0Q�6�   .��5_   &   �� ��65   �� *MouseOverState+6Z   5`   #   (� 5a   "   $ MousePressedState��6*   #��z��6E   #��z��6e   $ 0Q�6�   .��5b   &   �� ��65   �� *MousePressedState+6^   5c   #   5d       5f        5g   "   CommonStates��. 5h   &     
Normal��62     5i   &   	MouseOver��. 5j   *   �� .��5k   .   W� $ Opacity�6>   $ 0:0:0.0D�6b   $ DefaultState��6u   $ 1X�6�   $ 0X�6�   6�   W� 5l   .   $ Opacity�6>   $ 0:0:0.0D�6b   $ MouseOverState��6u   $ 0X�6�   $ 1X�6�   6�   5m   +   5n   '     5o   &   Pressed��. 5p   *   �� .��5q   .   W� $ Opacity�6>   $ 0:0:0.0D�6b   $ DefaultState��6u   $ 1X�6�   $ 0X�6�   6�   W� 5r   .   $ Opacity�6>   $ 0:0:0.0D�6b   $ MousePressedState��6u   $ 0X�6�   $ 1X�6�   6�   5s   +   5t   '     5u   &   Disabled��5w   '   5x   #   5z       5{      5~      5�      5�      5�      .��5�      � .+�5�   
   �� -   5         ��Name$ Button��5�      ��6!   ��  �� Path$ Width� �� RelativeSource ��  �� AncestorType" >���6�   �� $ Height� �� " >�6   5�      5�      