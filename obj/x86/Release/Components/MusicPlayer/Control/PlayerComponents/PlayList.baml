   M S B A M L   `   `   `  ���� R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Uclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponentsGArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents  W0clr-namespace:ArduinoManagementSystem.Components"ArduinoManagementSystem.Components  A%clr-namespace:ArduinoManagementSystemArduinoManagementSystem  V    PArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayList   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     rPlayerComponentsUclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents     G
components0clr-namespace:ArduinoManagementSystem.Components     IarduinoManagementSystem%clr-namespace:ArduinoManagementSystem     
������   � 	Resources     ScrollBarThumb �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  VerticalScrollBar � RowDefinitions ]� Thumb �� Triggers	 P� Property
 P� Value  FavsScrollViewer � ColumnDefinitions �� VerticalOffset � Value �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� Orientation �� HorizontalOffset �� ScrollableWidth �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility  DisabledControlLightColor  ControlLightColor  ControlMediumColor  DisabledBorderLightColor  BorderLightColor  BorderMediumColor 	 BorderDarkColor 
 PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $  ProgressBarIndicatorAnimatedFill  	TrackMenu ��Name �Name � Triggers :� RoutedEvent  �� 
TargetName! �� TargetProperty" g� FillBehavior# g� Duration$ W� From	% W� To& A�Name' J� Opacity( J� Effect-  'System.Windows.Media.Effects.BlurEffect)   Radius	* �� X1	+ �� Y1	, �� X2	- �� Y2. �� Triggers/ �� 
TargetName0 N� EnterActions1 t� From	2 t� To3 t� EasingFunction.  (System.Windows.Media.Animation.PowerEase4   Power7  1System.Windows.Media.Animation.EasingFunctionBase5   
EasingMode`   ZArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.TrackTimeConverter  TrackTimeConverter_   YArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.ProgressConverter  ProgressConverter  ListBoxFolder]   WArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListListBox6 K� IsItemsHost7 �� Color8 �� 	Resources  TrackDataTemplate9 � ContextMenu: �� IsOpen; �� Orientation< ��Name= �� Padding> �� TextAlignment? �� Path@ �� 	Converter  FolderDataTemplateb   \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeaderA  NameB �� SelectionMode2   ,ArduinoManagementSystem.SingleSelectionGroupC   	GroupName$D �� IsSynchronizedWithCurrentItemE �� RelativeSourceF �� ModeG �� AncestorTypeH � LayoutTransformI �� ScaleYk	   eArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.TrackOrFolderTemplateSelectorJ 	  FolderDataTemplateK 	  TrackDataTemplate ! TrackOrFolderTemplateSelector��%�  &	        &	 �     7   '�� �    7  &	 d    &	 �    &	 �    &	 �    &	 
    &	     &	 2    &		 E    &	
 X    &	 k    &	 ~    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 F    &	 �    &	     &	     &	 !    7  &	     7  7  7  &	 �    7  &	 B    7  7  �� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R��� $ 3��$��6��#��z��$��0q����#484a4b�� " ��.R��  �� $��0.00001* �.+��� $��3��$ 4��$��8��#��z��$��0q����#101213]� $��
PART_Track��$��1����.  n� 8��  $��1,0,1,0q�
������ 
������ �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P� 	 �@��Orientation$
 Vertical=�. ���  � ��$ 8����  � ��$
 Auto����  � ��8   �� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��  �� $	��308���� $��8�� �� �� $
��Auto �.+��� $	��308��$
��Left=�$��0���� $��PART_VerticalScrollBar��$��	300,0,0,0q�# z # z # z #y�z �� $��PART_HorizontalScrollBar��$ 
Horizontal=�$��1��$��1��# z # z # z #y�z ��Transparent����Transparent����Transparent����Transparent����	#FFCCCCCC����	#FF888888����	#FF444444����	#FF888888����	#FF444444����	#FF888888����	Black����	#FFC5CBF9����	Black����	#FFC5CBF9����	#FF3843C4���� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 0Q�� # �  $	 0.5Q�� # �  $ 1Q��� $	 0,0&�$	 1,0&���� � $ 	#000000FF��$ 0Q�� $ 	#600000FF��$	 0.4Q�� $ 	#600000FF��$	 0.6Q�� $ 	#000000FF��$ 1Q��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�IsSharedSizeScope . ��  �@��HasDropShadow . ��  �@��	Placement$ Custom=���  �@��VerticalOffset$
 -100����  �@��HorizontalOffset$
 -100����  � �� �� " ��.R��� $ Border��
������ $��0q�._�� $	��200��$	��200��.+�� $ Remove��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $  RemoveHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 0X�$% 1X�:� $ 
MouseLeave��[��� .���� $  RemoveHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 1X�$% 0X�.+�A� $& RemoveHigthLigth��$' 0Q�$��20��
���  ��(   $) 20Q�A� $��1��
���  �����#333333� .+��� 
���  ��$��3��$* 9��$+ 9��$, 21��$- 21���� 
���  ��$��3��$* 21��$+ 9��$, 9��$- 21��� $ RemoveVk��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $  RemoveVkHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 0X�$% 1X�:� $ 
MouseLeave��[��� .���� $  RemoveVkHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 1X�$% 0X�.+�A� $& RemoveVkHigthLigth��$' 0Q�$��20�����#51779D(   $) 20Q�A� $��1�����#51779D���#333333� .+��� 
���  ��$��3��$* 9��$+ 9��$, 21��$- 21���� 
���  ��$��3��$* 21��$+ 9��$, 9��$- 21��� $ AddVk��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $  AddVkHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 0X�$% 1X�:� $ 
MouseLeave��[��� .���� $  AddVkHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 1X�$% 0X�.+�A� $& AddVkHigthLigth��$' 0Q�$��20�����#51779D(   $) 20Q�A� $��1�����#51779D���#333333� .+��� 
��� � �$��3��$* 15��$+ 7��$, 15��$- 23���� 
��� � �$��3��$* 23��$+ 15��$, 7��$- 15��� $ 
ShowFolder��$��30��$��30�� :� $ 
MouseEnter��[��� .���� $  ShowFolderHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 0X�$% 1X�:� $ 
MouseLeave��[��� .���� $  ShowFolderHigthLigth��.��W� $! Opacity�$" HoldEnd=�$# 0:0:0.0D�$$ 1X�$% 0X�.+�A� $& ShowFolderHigthLigth��$' 0Q�$��20��
��� ���(   $) 20Q�A� $��1��
��� ������#333333� .+��� 
�������$��1��$* 5��$+ 14��$, 7��$- 23���� 
�������$��1��$* 20��$+ 14��$, 22��$- 23���� 
�������$��1��$* 5��$+ 14��$, 20��$- 14���� 
�������$��1��$* 7��$+ 23��$, 22��$- 23���� 
�������$��1��$* 22��$+ 9��$, 22��$- 23���� 
�������$��1��$* 7��$+ 9��$, 7��$- 14���� 
�������$��1��$* 7��$+ 9��$, 22��$- 9��. P� 	 �@��HasDropShadow
 . . ��� $/ Border�� �@��Padding$ 0,3,0,3q��� $/ Border�� �@��CornerRadius$ 4���� $/ Border�� �@��CornerRadius$ 4��P� 	 �@��IsOpen
 . 0 �� .���� $  Remove��.��t� $! Margin�$# 0:0:0.7D�$" HoldEnd=�$1 
-5,-10,0,0X�$2 
75,-10,0,0X�3   $4 10Q�$5 EaseOut=��� .���� $  RemoveVk��.��t� $! Margin�$# 0:0:0.6D�$" HoldEnd=�$1 
-5,-10,0,0X�$2 
-5,-80,0,0X�3   $4 10Q�$5 EaseOut=��� .���� $  AddVk��.��t� $! Margin�$# 0:0:0.5D�$" HoldEnd=�$1 
-5,-10,0,0X�$2 -75,-10,0,0X�3   $4 10Q�$5 EaseOut=��� .���� $  
ShowFolder��.��t� $! Margin�$# 0:0:0.4D�$" HoldEnd=�$1 
-5,-10,0,0X�$2 	-5,80,0,0X�3   $4 10Q�$5 EaseOut=�    �� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � �� �� " ��.R��� $��Border��
������ ._��  �� $��2 ��� $��* ��� $��2 �.+��� $��1��|�. ���� 6 . . P� 	 � {�
 .  . ��� $/ Border�� � �� �� 87   �� $/ Border�� � �� �� #7 �  P� 	 �@J�	IsFocused
 . . ��� $/ Border�� � �� �� $7 Transparent���� $/ Border�� � �� �� $7 Transparent��P� 	 �@��
IsGrouping
 . . ���  � �� .  8 ���� $7 Transparent��(��       * SystemColors.HighlightBrushKey+)�� $7 Transparent��(��       *SystemColors.ControlBrushKey+)�� .R�� $��23��$��Stretch=�
������ 9 �� 8��  : .  .@�m� $	��123��m� $
��1232��m� $
��1223��.+��� $; 
Horizontal=�
������ .+��� $< Number��$��Center=�$��Century Gothic)�$��1,0,1,0q����#a8a8a8$��Regular"�$y�	Collapsed=�$��00��$��14(�$��CharacterEllipsis=��� $< 
SourceIcon��$	��[S]��$��20��$��Center=�$
��Left=�$= 0,0,0,0q����#a8a8a8$��0,0,0,0q�$
��Bold"�$��14(�$��CharacterEllipsis=��� $��Center=�$= 5,0,0,0q�$��Century Gothic)�
�������$��	20,0,50,0q�$��Regular"�$��14(�$��CharacterEllipsis=����� *OriginalName+�� $��Center=�$��Century Gothic)�$> Right=�$��Right=����#a8a8a8$��0,0,10,0q�$��Regular"�$��14(�$��40������ $
? Time�8@  �� $ Progress��$	' 0.5Q�$
��Left=����� *PercentageOfLoaded+8@  ���� $	 0,1&�$	 0,0&�.��� � $ 	RoyalBlue��$ 0Q�� $
 Aqua��$	 0.5Q�� $ 	RoyalBlue��$ 1Q��� .R�� $��Layout��
������ $��-2,0,0,0q�.+��� $; Vertical=�
������ $��Stretch=�.+�  $A Header��|�.   $B Extended=�$	��Top=�$	��300��|�. $C Group B��
������ ��.  8��  $D FalseY����� $? Folders����� *ItemTemplateSelector+E �� $F FindAncestor=�"G ��H �� ListBoxLayoutTransform��$I 1Q�	  8J   8K  .��� 
������ .+�  #��[ $B Extended=�$	��Top=�$	��300��|�. $C Group B��
������ ��.  #��[ $D FalseY����� *FoldersList+`
   ZArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.RootPlayListFolder
  -   L 
 Name$L PlayListContainer��$y�	Collapsed=�
������ $��0q�
������ 6   0ArduinoManagementSystem.Components.LoadingStatus  -   M  Name$M LoadingStatusElement��$y�	Collapsed=�