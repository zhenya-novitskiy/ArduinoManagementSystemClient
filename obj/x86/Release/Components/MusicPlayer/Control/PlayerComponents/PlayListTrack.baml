   M S B A M L   `   `   `  ����   ArduinoManagementSystem[    UArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListTrack   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor 	 ControlMediumColor 
 ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $  ProgressBarIndicatorAnimatedFill  	TrackMenu �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �Name � Triggers :� RoutedEvent �� 
TargetName �� TargetProperty g� FillBehavior g� Duration W� From	 W� To A�Name J� Opacity J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius	 �� X1	 �� Y1	 �� X2	 �� Y2 �� Triggers P� Property P� Value �� 
TargetName N� EnterActions  t� From	! t� To" t� EasingFunction.  (System.Windows.Media.Animation.PowerEase#   Power7  1System.Windows.Media.Animation.EasingFunctionBase$   
EasingMode  	PlayTrack	% �� To& �� From  	StopTrack��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	     &	 ;    &	 N    &	 a    &	 t    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 u    &	     &	 K    &	 K    ��	#FFE8EDF9����	#FFC5CBF9����	#FF7381F9����	#FFE8EDF9����	#FFC5CBF9����	#FF888888����	#FFC5CBF9����	#FFDDDDDD����	White����	#FF7381F9����	#FF211AA9����	#FF3843C4����	#FF211AA9����	#FF444444����/+sc#1, 0.004391443, 0.002428215, 0.242281124����	#FFCCCCCC����	#FF888888����	#FF444444����	#FF888888����	#FF444444����	#FFAAAAAA����	#FF888888����	Black����	#FFC5CBF9����	Black����	#FFC5CBF9����	#FF3843C4���� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 0Q�� # � 	 $	 0.5Q�� # �  $ 1Q��� $	 0,0&�$	 1,0&���� � $ 	#000000FF��$ 0Q�� $ 	#600000FF��$	 0.4Q�� $ 	#600000FF��$	 0.6Q�� $ 	#000000FF��$ 1Q��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�IsSharedSizeScope . ��  �@��HasDropShadow . ��  �@��	Placement$ Custom=���  �@��VerticalOffset$
 -100����  �@��HorizontalOffset$
 -100����  � �� �� " ��.R��� $	 Border��
������ $��0q�._�� $	��200��$	��200��.+�� $
 Remove��-   $��30��$��30�� :� $ 
MouseEnter��[��� .���� $ RemoveHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 0X�$ 1X�:� $ 
MouseLeave��[��� .���� $ RemoveHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 1X�$ 0X�.+�A� $ RemoveHigthLigth��$ 0Q�$��20��
���  ��   $ 20Q�A� $��1��
���  �����#333333� .+��� 
���  ��$��3��$ 9��$ 9��$ 21��$ 21���� 
���  ��$��3��$ 21��$ 9��$ 9��$ 21��� $
 RemoveVk��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $ RemoveVkHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 0X�$ 1X�:� $ 
MouseLeave��[��� .���� $ RemoveVkHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 1X�$ 0X�.+�A� $ RemoveVkHigthLigth��$ 0Q�$��20�����#51779D   $ 20Q�A� $��1�����#51779D���#333333� .+��� 
���  ��$��3��$ 9��$ 9��$ 21��$ 21���� 
���  ��$��3��$ 21��$ 9��$ 9��$ 21��� $
 AddVk��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $ AddVkHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 0X�$ 1X�:� $ 
MouseLeave��[��� .���� $ AddVkHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 1X�$ 0X�.+�A� $ AddVkHigthLigth��$ 0Q�$��20�����#51779D   $ 20Q�A� $��1�����#51779D���#333333� .+��� 
��� � �$��3��$ 15��$ 7��$ 15��$ 23���� 
��� � �$��3��$ 23��$ 15��$ 7��$ 15��� $
 
ShowFolder��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $ ShowFolderHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 0X�$ 1X�:� $ 
MouseLeave��[��� .���� $ ShowFolderHigthLigth��.��W� $ Opacity�$ HoldEnd=�$ 0:0:0.0D�$ 1X�$ 0X�.+�A� $ ShowFolderHigthLigth��$ 0Q�$��20��
��� ���   $ 20Q�A� $��1��
��� ������#333333� .+��� 
�������$��1��$ 5��$ 14��$ 7��$ 23���� 
�������$��1��$ 20��$ 14��$ 22��$ 23���� 
�������$��1��$ 5��$ 14��$ 20��$ 14���� 
�������$��1��$ 7��$ 23��$ 22��$ 23���� 
�������$��1��$ 22��$ 9��$ 22��$ 23���� 
�������$��1��$ 7��$ 9��$ 7��$ 14���� 
�������$��1��$ 7��$ 9��$ 22��$ 9�� P�  �@��HasDropShadow . . ��� $ Border�� �@��Padding$ 0,3,0,3q��� $ Border�� �@��CornerRadius$ 4���� $ Border�� �@��CornerRadius$ 4��P�  �@��IsOpen .  �� .���� $ Remove��.��t� $ Margin�$ 0:0:0.7D�$ HoldEnd=�$  
-5,-10,0,0X�$! 
75,-10,0,0X�"   $# 10Q�$$ EaseOut=��� .���� $ RemoveVk��.��t� $ Margin�$ 0:0:0.6D�$ HoldEnd=�$  
-5,-10,0,0X�$! 
-5,-80,0,0X�"   $# 10Q�$$ EaseOut=��� .���� $ AddVk��.��t� $ Margin�$ 0:0:0.5D�$ HoldEnd=�$  
-5,-10,0,0X�$! -75,-10,0,0X�"   $# 10Q�$$ EaseOut=��� .���� $ 
ShowFolder��.��t� $ Margin�$ 0:0:0.4D�$ HoldEnd=�$  
-5,-10,0,0X�$! 	-5,80,0,0X�"   $# 10Q�$$ EaseOut=��� .���� $ 	TrackName��$ Foreground.Color�$% #0f9d9cX�$& WhiteX�$ 0:0:0.5D��� $ Number��$ Foreground.Color�$% #0f9d9cX�$& #a8a8a8X�$ 0:0:0.5D��� $
 Time��$ Foreground.Color�$% #0f9d9cX�$& #a8a8a8X�$ 0:0:0.5D��� .���� $ 	TrackName��$ Foreground.Color�$% WhiteX�$& #0f9d9cX�$ 0:0:0.5D��� $ Number��$ Foreground.Color�$% #a8a8a8X�$& #0f9d9cX�$ 0:0:0.5D��� $
 Time��$ Foreground.Color�$% #a8a8a8X�$& #0f9d9cX�$ 0:0:0.5D�.��� $��23��$��Stretch=�
������ ' � ContextMenu' �� #��[ ( �� IsOpen( .  .@�m� $	��123��m� $
��1232��m� $
��1223��.+��� ) �� Orientation$) 
Horizontal=�
������ .+��� -   * ��Name$* Number��$��Center=�$��Century Gothic)�$��1,0,1,0q����#a8a8a8$��Regular"�$y�	Collapsed=�$��00��$��14(�$��CharacterEllipsis=��� -   $* 
SourceIcon��$	��[S]��$��20��$��Center=�$
��Left=�+ �� Padding$+ 0,0,0,0q����#a8a8a8$��0,0,0,0q�$
��Bold"�$��14(�$��CharacterEllipsis=��� -   $* 	TrackName��$��Center=�$+ 5,0,0,0q�$��Century Gothic)�
�������$��	20,0,50,0q�$��Regular"�$��	TrackName��$��14(�$��CharacterEllipsis=��� -   $
* Time��$��Center=�$��Century Gothic)�, �� TextAlignment$, Right=�$��Right=�$��00:00�����#a8a8a8$��0,0,10,0q�$��Regular"�$��14(�$��40���� -   $	 Progress��$	 0.5Q�$��0��$
��Left=����� $	 0,1&�$	 0,0&�.��� � $ 	RoyalBlue��$ 0Q�� $
 Aqua��$	 0.5Q�� $ 	RoyalBlue��$ 1Q�