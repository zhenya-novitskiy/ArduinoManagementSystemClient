   M S B A M L   `   `   `  ���� R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ArduinoManagementSystemArduinoManagementSystem  �Uclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponentsGArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents  W0clr-namespace:ArduinoManagementSystem.Components"ArduinoManagementSystem.Components  }Cclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Models5ArduinoManagementSystem.Components.MusicPlayer.Models  \    VArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolder   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     IarduinoManagementSystem%clr-namespace:ArduinoManagementSystem     rplayerComponentsUclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents     G
components0clr-namespace:ArduinoManagementSystem.Components     VModelsCclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Models     -     J� 	AllowDrop  . 
������ |�.   � 	Resources    ScrollBarThumb �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  VerticalScrollBar � RowDefinitions ]� Thumb	 �� Triggers
 P� Property P� Value  FavsScrollViewer � ColumnDefinitions �� VerticalOffset � Value �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� Orientation �� HorizontalOffset �� ScrollableWidth �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility  PlayListTrackStyle ��Name �� Padding J� SnapsToDevicePixels �Name ��Name J� Opacity J� OpacityMask  �� 
StartPoint! �� EndPoint" � Offset# � Color$ T� X% ��Name& �� Triggers' �� 
TargetName( j� Stretch) j� TileMode* �� ImageSource  PlayListFolderStyle  
GlyphColor  GlyphMouseOver  DisabledControlLightColor  ControlLightColor 	 ControlMediumColor 
 DisabledBorderLightColor  ListBoxFolder]   WArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListListBox+ K� IsItemsHost, �� Color- �� 	Resources  RootContainerStyle  RootListBox��%-  &	        &	 �     7   '�� �    7  &	 d    &	 �    &	 �    &	 R    &	 e    &	 �    &	 �    &		 �    &	
 �    &	 �    7  &	 �    &	 �    7  7  �� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R��� $ 3��$��6��#��z��$��0q����#484a4b�� " ��.R��  �� $��0.00001* �.+��� $��3��$ 4��$��8��#��z��$��0q����#101213]� $��
PART_Track��$��1����.  n� 8��  $��1,0,1,0q�
������ 
������ �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . 	 P� 
 �@��Orientation$ Vertical=�. ���  � ��$ 8����  � ��$
 Auto����  � ��8   �� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��  �� $	��308���� $��8�� �� �� $
��Auto �.+��� $	��308��$
��Left=�$��0���� $��PART_VerticalScrollBar��$��	300,0,0,0q�# z # z # z #y�z �� $��PART_HorizontalScrollBar��$ 
Horizontal=�$��1��$��1��# z # z # z #y�z �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  ��  � �� �� ControlTemplateListBoxItem��" ��.R��� $ Border��$ 0q� . 
������ ._�� $ TabItemContentPresenter��$��10,0,0,0q�.+��� $ Light��$	��305��$ 0Q�$��21�����#367d75$��	-10,0,0,0q�$
��Left=� �� $	  0,0&�$	! 1,0&�.��� $" 0Q�$# 	#FFFFFFFF��� $
" 0.03Q�$# 	#66FFFFFF��� $	" 0.1Q�$# 	#44FFFFFF��� $
" 0.26Q�$# 	#22FFFFFF��� $
" 0.74Q�$# 	#22FFFFFF��� $	" 0.9Q�$# 	#44FFFFFF��� $
" 0.97Q�$# 	#66FFFFFF��� $" 1Q�$# 	#FFFFFFFF��� z�T� TranslateBody��$$ 0Q�.+��� $% 	Presenter��|�.  $	 0.5Q�$��23��& P� 
 �@��
IsSelected . . ��� $' Light�� �@J�Opacity$ 1Q��� $' 	Presenter�� �@J�Opacity$	 0.9Q��� $' Border�� � �� �� $
( Fill=�$) FlipX=�$D* >/Components\MusicPlayer\Control\Images\playlistSelectionBG.png���� " ��.���  �@J�SnapsToDevicePixels . ��  � ��
 ���� ��  � |� .  ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $% Border�� . ��	#FF444444����/+sc#1, 0.004391443, 0.002428215, 0.242281124����Transparent����Transparent����Transparent����Transparent���� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � �� �� " ��.R��� $��Border��
������ ._��  �� $��2 ��� $��* ��� $��2 �.+��� $��1��|�. ���� + . & P� 
 � {� .  . ��� $' Border�� � �� �� 8,   �� $' Border�� � �� �� #, � 
 P� 
 �@J�	IsFocused . . ��� $' Border�� � �� �� $, Transparent���� $' Border�� � �� �� $, Transparent��P� 
 �@��
IsGrouping . . ���  � �� .  - ���� $, Transparent��(��       * SystemColors.HighlightBrushKey+)�� $, Transparent��(��       *SystemColors.ControlBrushKey+)�� " ��.���  � ��
 ���� 	 P� 
 �@��
IsSelected . . ���  � ��
 ���� P� 
 �@��
IsSelected .  . ���  � ��
 ���� �� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 95����  � �� �� " ��.R��� $��Border����Z� ���� $;* 5/Components\MusicPlayer\Control\Images\playlistBG.png��._�� 
������  �� $��2 ��� $��* ��� $��2 �.+��� 
������ $��1��8��  |�.  .���� 
������ + . & P� 
 � {� .  . ��� $' Border�� � �� �� 8,  �� $' Border�� � �� �� #, � 
 P� 
 �@��
IsGrouping . . ���  � �� .  - ���� $, Transparent��(��       * SystemColors.HighlightBrushKey+)�� $, Transparent��(��       *SystemColors.ControlBrushKey+).��� -   $��Layout��
������ $��-2,0,0,0q�.+�6   0ArduinoManagementSystem.Components.LoadingStatus  -   .  Name$. LoadingStatus��$y�	Collapsed=��� $y�	Collapsed=�/ �� Orientation$/ Vertical=�
������ $��Stretch=�.+�b   \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeader  -   0  Name$0 Header��b   \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeader1   MouseDoubleClick$1 Header_OnMouseDoubleClick��2   GotFocus$2 Header_GotFocus��|�.   -   3  Name$3 FolderContainer��]   WArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListListBox4   Drop$4 FolderContainer_OnDrop��5   KeyDown$5 FolderContainer_KeyDown��6   OnKeyActivated$&6  FolderContainer_OnOnKeyActivated��7 �� SelectionMode$7 Extended=�$	��Top=�$	��300��|�. 2   ,ArduinoManagementSystem.SingleSelectionGroup8   	GroupName$8 Group B��
������ ��.  #��[ $9 �� IsSynchronizedWithCurrentItem$9 FalseY�: � LayoutTransform: �� -   ListBoxLayoutTransform��; �� ScaleY$; 1Q�