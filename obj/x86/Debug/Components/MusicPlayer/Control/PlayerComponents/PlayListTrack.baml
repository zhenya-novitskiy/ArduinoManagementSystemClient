   M S B A M L   `   `   `  ����  ArduinoManagementSystem[    UArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListTrack   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor 	 ControlMediumColor 
 ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $  ProgressBarIndicatorAnimatedFill  	TrackMenu �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �Name � Triggers :� RoutedEvent �� 
TargetName �� TargetProperty g� FillBehavior g� Duration W� From	 W� To A�Name J� Opacity J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius	 �� X1	 �� Y1	 �� X2	 �� Y2 �� Triggers P� Property P� Value �� 
TargetName N� EnterActions  t� From	! t� To" t� EasingFunction.  (System.Windows.Media.Animation.PowerEase#   Power7  1System.Windows.Media.Animation.EasingFunctionBase$   
EasingMode  	PlayTrack	% �� To& �� From  	StopTrack��%�"  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     &	     &		 %    &	
 F    &	 g    &	 �    &	 �    &	 �    &	     &	 .    &	 O    &	 p    &	 �    &	 �    &	 �    &	 �    &	     &	 2    &	 O    &	 p    &	 �    &	 X    &	 �    &	 t    &	 �    ��5
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
   $	 0,0&�5@      $	 1,0&�5A      ��5C      � � 5D      $ 	#000000FF��6#   $ 0Q�5E      � 5F      $ 	#600000FF��6#   $	 0.4Q�5G      � 5H      $ 	#600000FF��6#   $	 0.6Q�5I      � 5J      $ 	#000000FF��6#   $ 1Q�5K      5L      5N      �� 5O   
   " ��6"   .�5P      ��  �@J�SnapsToDevicePixels . 64   �� 5Q       �@�OverridesDefaultStyle . 66   �� 5R       �@�IsSharedSizeScope . 67   �� 5S       �@��HasDropShadow . 6.   �� 5T       �@��	Placement$ Custom=�6*   �� 5U       �@��VerticalOffset$
 -100��6/   �� 5V       �@��HorizontalOffset$
 -100��61   �� 5W       � �� 5X      �� 5Y      " ��6'   .R�5Z      �� $	 Border��6!   
������ $��0q�6K   ._�5[      � $	��200��6#   $	��200��6/   .+�5]   "   � $
 Remove��6'   -   5        $��30��5]   V   $��30��6a    5^   &   :� 5_   *   $ 
MouseEnter��67   [�5`   .   �� 5a   2   .��5b   6   �� $ RemoveHigthLigth��6A   .��5c   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 0X�6�   $ 1X�6�   5d   7   5e   3   5g   +   :� 5h   *   $ 
MouseLeave��67   [�5i   .   �� 5j   2   .��5k   6   �� $ RemoveHigthLigth��6A   .��5l   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 1X�6�   $ 0X�6�   5m   7   5n   3   5p   +   .+�5r   &   A� $ RemoveHigthLigth��6.   $ 0Q�6H   $��20��6T   
���  �� 5s   *     5t   .   $ 20Q�69   6G   5v   '   A� 5w   &   $��1��6.   
���  �����#3333336`   � 5y   &   .+�5z   *   �� 
���  ��$��3��6<   $ 9��6P   $ 9��6W   $ 21��6^   $ 21��6f   6p   �� 5{   *   
���  ��$��3��6<   $ 21��6P   $ 9��6X   $ 9��6_   $ 21��6f   6p   5|   '   5~   #   � 5�   "   $
 RemoveVk��6'   $��30��69   $��30��6D    5�   &   :� 5�   *   $ 
MouseEnter��67   [�5�   .   �� 5�   2   .��5�   6   �� $ RemoveVkHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 0X�6�   $ 1X�6�   5�   7   5�   3   5�   +   :� 5�   *   $ 
MouseLeave��67   [�5�   .   �� 5�   2   .��5�   6   �� $ RemoveVkHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 1X�6�   $ 0X�6�   5�   7   5�   3   5�   +   .+�5�   &   A� $ RemoveVkHigthLigth��6.   $ 0Q�6J   $��20��6V   ���#51779D 5�   *     5�   .   $ 20Q�69   6G   5�   '   A� 5�   &   $��1��6.   ���#51779D���#3333336d   � 5�   &   .+�5�   *   �� 
���  ��$��3��6<   $ 9��6P   $ 9��6W   $ 21��6^   $ 21��6f   6p   �� 5�   *   
���  ��$��3��6<   $ 21��6P   $ 9��6X   $ 9��6_   $ 21��6f   6p   5�   '   5�   #   � 5�   "   $
 AddVk��6'   $��30��66   $��30��6A    5�   &   :� 5�   *   $ 
MouseEnter��67   [�5�   .   �� 5�   2   .��5�   6   �� $ AddVkHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 0X�6�   $ 1X�6�   5�   7   5�   3   5�   +   :� 5�   *   $ 
MouseLeave��67   [�5�   .   �� 5�   2   .��5�   6   �� $ AddVkHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 1X�6�   $ 0X�6�   5�   7   5�   3   5�   +   .+�5�   &   A� $ AddVkHigthLigth��6.   $ 0Q�6G   $��20��6S   ���#51779D 5�   *     5�   .   $ 20Q�69   6G   5�   '   A� 5�   &   $��1��6.   ���#51779D���#3333336d   � 5�   &   .+�5�   *   �� 
��� � �$��3��6>   $ 15��6R   $ 7��6Z   $ 15��6a   $ 23��6i   6s   �� 5�   *   
��� � �$��3��6>   $ 23��6R   $ 15��6Z   $ 7��6b   $ 15��6i   6s   5�   '   5�   #   � 5�   "   $
 
ShowFolder��6'   $��30��6<   $��30��6G    5�   &   :� 5�   *   $ 
MouseEnter��67   [�5�   .   �� 5�   2   .��5�   6   �� $ ShowFolderHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 0X�6�   $ 1X�6�   5�   ;   5�   7   5�   3   5�   +   :� 5�   *   $ 
MouseLeave��67   [�5�   .   �� 5�   2   .��5�   6   �� $ ShowFolderHigthLigth��6A   .��5�   :   W� $ Opacity�6J   $ HoldEnd=�6n   $ 0:0:0.0D�6�   $ 1X�6�   $ 0X�6�   5�   ;   5�   7   5�   3   5�   +   .+�5�   &   A� $ ShowFolderHigthLigth��6.   $ 0Q�6L   $��20��6X   
��� ��� 5�   *     5�   .   $ 20Q�69   6G   5�   '   A� 5�   &   $��1��6.   
��� ������#3333336c   � 5�   &   .+�5�   *   �� 
�������$��1��6?   $ 5��6S   $ 14��6Z   $ 7��6b   $ 23��6i   6s   �� 5�   *   
�������$��1��6?   $ 20��6S   $ 14��6[   $ 22��6c   $ 23��6k   6u   �� 5�   *   
�������$��1��6?   $ 5��6S   $ 14��6Z   $ 20��6b   $ 14��6j   6t   �� 5�   *   
�������$��1��6?   $ 7��6S   $ 23��6Z   $ 22��6b   $ 23��6j   6t   �� 5�   *   
�������$��1��6?   $ 22��6S   $ 9��6[   $ 22��6b   $ 23��6j   6t   �� 5�   *   
�������$��1��6?   $ 7��6S   $ 9��6Z   $ 7��6a   $ 14��6h   6r   �� 5�   *   
�������$��1��6?   $ 7��6S   $ 9��6Z   $ 22��6a   $ 9��6i   6r   5�   '   5�   #   5�      5�       5�      P� 5�       �@��HasDropShadow . . �5�   "   �� $ Border��6)    �@��Padding$ 0,3,0,3q�6P   �� 5�   "   $ Border��6)    �@��CornerRadius$ 4��6U   �� 5�   "   $ Border��6)    �@��CornerRadius$ 4��6U   5�      P� 5�       �@��IsOpen .  5�   "   �� 5�   &   .��5�   *   �� $ Remove��65   .��5   .   t� $ Margin�6A   $ 0:0:0.7D�6d   $ HoldEnd=�6w   $  
-5,-10,0,0X�6�   $! 
75,-10,0,0X�6�   " 5  2     5  6   $# 10Q�6@   $$ EaseOut=�6K   5  /   5  +   5  '   �� 5  &   .��5	  *   �� $ RemoveVk��65   .��5
  .   t� $ Margin�6A   $ 0:0:0.6D�6d   $ HoldEnd=�6w   $  
-5,-10,0,0X�6�   $! 
-5,-80,0,0X�6�   " 5  2     5  6   $# 10Q�6@   $$ EaseOut=�6K   5  /   5  +   5  '   �� 5  &   .��5  *   �� $ AddVk��65   .��5  .   t� $ Margin�6A   $ 0:0:0.5D�6d   $ HoldEnd=�6w   $  
-5,-10,0,0X�6�   $! -75,-10,0,0X�6�   " 5  2     5  6   $# 10Q�6@   $$ EaseOut=�6K   5  /   5  +   5  '   �� 5  &   .��5  *   �� $ 
ShowFolder��65   .��5  .   t� $ Margin�6A   $ 0:0:0.4D�6d   $ HoldEnd=�6w   $  
-5,-10,0,0X�6�   $! 	-5,80,0,0X�6�   " 5  2     5  6   $# 10Q�6@   $$ EaseOut=�6K   5   /   5!  +   5"  '   5$     5&     5(     5)     �� 5+  
   .��5,     �� $ 	TrackName��6   $ Foreground.Color�6A   $% #0f9d9cX�6o   $& WhiteX�6|   $ 0:0:0.5D�6�   6�   �� 5-     $ Number��6   $ Foreground.Color�6>   $% #0f9d9cX�6l   $& #a8a8a8X�6y   $ 0:0:0.5D�6�   6�   �� 5.     $
 Time��6   $ Foreground.Color�6<   $% #0f9d9cX�6j   $& #a8a8a8X�6w   $ 0:0:0.5D�6�   6�   50     �� 51  
   .��52     �� $ 	TrackName��6   $ Foreground.Color�6@   $% WhiteX�6m   $& #0f9d9cX�6x   $ 0:0:0.5D�6�   6�   �� 53     $ Number��6   $ Foreground.Color�6=   $% #a8a8a8X�6j   $& #0f9d9cX�6w   $ 0:0:0.5D�6�   6�   �� 54     $
 Time��6   $ Foreground.Color�6;   $% #a8a8a8X�6h   $& #0f9d9cX�6u   $ 0:0:0.5D�6�   6�   55     58     .��59     � $��23��6   $��Stretch=�6   
������ ' � ContextMenu' 5:  
   �� 5;     #��[ 6   ( �� IsOpen( .  .@�5<     m� $	��123��6   6*   m� 5=     $
��1232��6   6+   m� 5>     $
��1223��6   6+   5?     .+�5B  
   �� ) �� Orientation$) 
Horizontal=�6   
������ .+�5C     �� -   5        * ��Name$* Number��5C  �   $��Center=�6   $��Century Gothic)�63   $��1,0,1,0q�6O   ���#a8a8a8$��Regular"�6v   $y�	Collapsed=�6�   $��00��6�   $��14(�6�   $��CharacterEllipsis=�6�   6�   5G     �� 5H  
   -   5        $* 
SourceIcon��5H     $	��[S]��6   $��20��64   $��Center=�6?   $
��Left=�6Z   + �� Padding$+ 0,0,0,0q�6u   ���#a8a8a8$��0,0,0,0q�6�   $
��Bold"�6�   $��14(�6�   $��CharacterEllipsis=�6�   6�   �� 5J  
   -   5        $* 	TrackName��5J  �   $��Center=�6   $+ 5,0,0,0q�6/   $��Century Gothic)�6C   
�������$��	20,0,50,0q�6s   $��Regular"�6�   $��	TrackName��6�   $��14(�6�   $��CharacterEllipsis=�6�   6�   �� 5K  
   -   5        $
* Time��5K  �   $��Center=�6   $��Century Gothic)�60   , �� TextAlignment$, Right=�6L   $��Right=�6b   $��00:00��6~   ���#a8a8a8$��0,0,10,0q�6�   $��Regular"�6�   $��14(�6�   $��40��6�   6�   �� 5L  
   -   5        $	 Progress��5L     $	 0.5Q�6#   $��0��61   $
��Left=�6;   ��5M     �� 5N     $	 0,1&�6&   $	 0,0&�67   .��5O     � � 5P     $ 	RoyalBlue��6'   $ 0Q�69   6F   � 5Q     $
 Aqua��6'   $	 0.5Q�64   6C   � 5R     $ 	RoyalBlue��6'   $ 1Q�69   6F   5S     5T     5V     5W     5X     