   M S B A M L   `   `   `  ����R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ArduinoManagementSystemArduinoManagementSystem  5      �Uclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponentsGArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents  5      W0clr-namespace:ArduinoManagementSystem.Components"ArduinoManagementSystem.Components  5      }Cclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Models5ArduinoManagementSystem.Components.MusicPlayer.Models  5	      \    VArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolder   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      IarduinoManagementSystem%clr-namespace:ArduinoManagementSystem     5      rplayerComponentsUclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents     5      G
components0clr-namespace:ArduinoManagementSystem.Components     5      VModelsCclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Models     5	      -   5          J� 	AllowDrop  . 
������ |�.   � 	Resources 5         ScrollBarThumb �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  VerticalScrollBar � RowDefinitions ]� Thumb	 �� Triggers
 P� Property P� Value  FavsScrollViewer � ColumnDefinitions �� VerticalOffset � Value �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� Orientation �� HorizontalOffset �� ScrollableWidth �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility  PlayListTrackStyle ��Name �� Padding J� SnapsToDevicePixels �Name ��Name J� Opacity J� OpacityMask  �� 
StartPoint! �� EndPoint" � Offset# � Color$ T� X% ��Name& �� Triggers' �� 
TargetName( j� Stretch) j� TileMode* �� ImageSource  PlayListFolderStyle  
GlyphColor  GlyphMouseOver  DisabledControlLightColor  ControlLightColor 	 ControlMediumColor 
 DisabledBorderLightColor  ListBoxFolder]   WArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListListBox+ K� IsItemsHost, �� Color- �� 	Resources  RootContainerStyle  RootListBox��%�  &	        &	 {    7   '�� �    7  &	 #    &	 �    &	 .    &	 �    &	 �    &	 �    &	     &		 B    &	
 e    &	 �    7  &	 �    &	 �    7  7  �� 5   
   " n�6'   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � |� .  6*   �� 5       � �� 5      �� 5      " n�6&   .R�5      �� $ 3��6!   $��6��62   #��z��6<   $��0q�6h   ���#484a4b6|   5      5      5      �� 5   
   " ��66   .R�5      �  5      �� 5      $��0.00001* �6$   .+�5      �� $��3��6   $ 4��6*   $��8��6;   #��z��6E   $��0q�6q   ���#1012136�   ]� 5      $��
PART_Track��6   $��1��6*   ��.  5       n� 5!      8��  $��1,0,1,0q�6H   
������ 
������ 6r   5#      5$      5%      �� 5&   
   " ��6+   .�5'      ��  �@J�SnapsToDevicePixels . 64   �� 5(       �@�OverridesDefaultStyle . 66   	 5)      P� 5*      
 �@��Orientation$ Vertical=�62   . �5+      ��  � ��$ 8��6.   �� 5,       � ��$
 Auto��6/   �� 5-       � ��8   61   5.      50      �� 51   
   " ��6)   .�52      ��  �@�OverridesDefaultStyle . 66   �� 53       � �� 54      �� 55      " ��6&   .R�56      �  57      �� 58   "   $	��308��63   �� 59   "   $��8��64    5;      �� 5<   "   �� 5=   "   $
��Auto �60   .+�5@      �� $	��308��65   $
��Left=�6A   $��0��6\   �� 5B      $��PART_VerticalScrollBar��6=   $��	300,0,0,0q�6(   # z 5C   %   # z 5D   %   # z 5E   %   #y�z 5F   %   �� 5G      $��PART_HorizontalScrollBar��6(   $ 
Horizontal=�5H   %   $��1��5I   %   $��1��5J   %   # z 5K   %   # z 5L   %   # z 5M   %   #y�z 5N   %   5P      5Q      5S      5T      �� 5U   
   " ��5V      .�5W      ��  �@J�SnapsToDevicePixels . 5X      �� 5Y       �@�OverridesDefaultStyle .  5Z      �� 5[       � �� 5\      �� 5]      ControlTemplateListBoxItem��" ��6J   .R�5^      �� $ Border��6!   $ 0q�61    . 
������ ._�5_      � $ TabItemContentPresenter��66   $��10,0,0,0q�6$   .+�5`   "   �� $ Light��6Q   $	��305��6,   $ 0Q�69   $��21��6E   ���#367d75$��	-10,0,0,0q�6o   $
��Left=�6�    5a   &   �� 5b   *   $	  0,0&�6>   $	! 1,0&�6O   .��5c   .   � $" 0Q�6;   $# 	#FFFFFFFF��6F   6Z   � 5d   .   $
" 0.03Q�6;   $# 	#66FFFFFF��6I   6]   � 5e   .   $	" 0.1Q�6;   $# 	#44FFFFFF��6H   6\   � 5f   .   $
" 0.26Q�6;   $# 	#22FFFFFF��6I   6]   � 5g   .   $
" 0.74Q�6;   $# 	#22FFFFFF��6I   6]   � 5h   .   $	" 0.9Q�6;   $# 	#44FFFFFF��6H   6\   � 5i   .   $
" 0.97Q�6;   $# 	#66FFFFFF��6I   6]   � 5j   .   $" 1Q�6;   $# 	#FFFFFFFF��6F   6Z   5k   +   5m   #   � 5n   "   z�5o   &   T� 5p   *   TranslateBody��$$ 0Q�6T   6\   .+�5r   &   �� $% 	Presenter��6I   |�.  $	 0.5Q�6]   $��23��6k   5s   '   5t   #   5u      5w      & 5x      P� 5y      
 �@��
IsSelected . . �5z   "   �� $' Light��6<    �@J�Opacity$ 1Q�6O   6[   �� 5{   "   $' 	Presenter��6<    �@J�Opacity$	 0.9Q�6S   6a   �� 5|   "   $' Border��6?    � �� 5}   &   �� 5~   *   $
( Fill=�66   $) FlipX=�6E   $D* >/Components\MusicPlayer\Control\Images\playlistSelectionBG.png��6X   6�   5�   #   5�      5�      5�      5�      �� 5�   
   " ��5�      .�5�      ��  �@J�SnapsToDevicePixels . 5�      �� 5�       � ��
 ���� 6A   �� 5�       � |� .  5�      �� 5�       �@�OverridesDefaultStyle . 5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $% Border��6+    . 5�      5�      5�      5�      ��5�   
   	#FF444444��6.   ��5�   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124��6T   ��5�   
   Transparent��6?   ��5�   
   Transparent��67   ��5�   
   Transparent��68   ��5�   
   Transparent��6>   �� 5�   
   "  6&   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � �� . 6>   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Border��6!   
������ ._�5�      �  5�   "   �� 5�   &   $��2 �64   6A   �� 5�   &   $��* �64   6A   �� 5�   &   $��2 �64   6A   .+�5�   "   �� $��1��64   |�. ��5�   &   �� 5�   *   + . 5�   +   5�   #   5�      5�      & 5�      P� 5�      
 � {� .  . �5�   "   �� $' Border��6)    � �� 5�   &   �� 5�   *   8,   6:   5�   #   �� 5�   "   $' Border��6)    � �� 5�   &   �� 5�   *   #, � 
 6:   5�   #   5�      P� 5�      
 �@J�	IsFocused . . �5�   "   �� $' Border��6)    � �� 5�   &   �� 5�   *   $, Transparent��6:   5�   #   �� 5�   "   $' Border��6)    � �� 5�   &   �� 5�   *   $, Transparent��6:   5�   #   5�      P� 5�      
 �@��
IsGrouping . . �5�   "   ��  � �� .  6R   5�      5�      5�      - 5�      ���� 5�      $, Transparent��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   �� 5�      $, Transparent��6T   (��       6"   *SystemColors.ControlBrushKey+)6T   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��
 ���� 6+   	 5�      P� 5�      
 �@��
IsSelected . . �5�      ��  � ��
 ���� 63   5�      P� 5�      
 �@��
IsSelected .  . �5�      ��  � ��
 ���� 63   5�      5�      �� 5�   
   "  6$   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � ��$
 Auto=�6K   �� 5       � ��$
 Auto=�6I   �� 5      � �� . 6>   �� 5      � ��$	 120��6)   �� 5      � ��$ 95��6*   �� 5      � �� 5     �� 5     " ��6&   .R�5     �� $��Border��6!   ��6/   Z� ��5     �� 5	  "   $;* 5/Components\MusicPlayer\Control\Images\playlistBG.png��6-   ._�5     � 
������  5  "   �� 5  &   $��2 �64   6A   �� 5  &   $��* �64   6A   �� 5  &   $��2 �64   6A   .+�5  "   �� 
������ $��1��6H   8��  |�.  .��5  &   �� 
������ + . 5  '   5  #   5     5     & 5     P� 5     
 � {� .  . �5  "   �� $' Border��6)    � �� 5  &   �� 5  *   8,  6:   5  #   �� 5  "   $' Border��6)    � �� 5   &   �� 5!  *   #, � 
 6:   5#  #   5$     P� 5%     
 �@��
IsGrouping . . �5&  "   ��  � �� .  6R   5'     5)     5+     - 5,     ���� 5-     $, Transparent��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   �� 5.     $, Transparent��6T   (��       6"   *SystemColors.ControlBrushKey+)6T   50     51     53     .��57     � -   5        $��Layout��57     
������ $��-2,0,0,0q�62   .+�58  
   6   0ArduinoManagementSystem.Components.LoadingStatus  -   5        .  Name$. LoadingStatus��58  :   $y�	Collapsed=�6#   6T   �� 59  
   $y�	Collapsed=�6   / �� Orientation$/ Vertical=�6,   
������ $��Stretch=�6\   .+�5:     b   \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeader  -   5        0  Name$0 Header��5:  F   b   \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeader1   MouseDoubleClick$1 Header_OnMouseDoubleClick��6V   2   GotFocus$2 Header_GotFocus��6�   |�. 6�     5;     -   5        3  Name$3 FolderContainer��5;  0   ]   WArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListListBox4   Drop$4 FolderContainer_OnDrop��6Q  5   KeyDown$5 FolderContainer_KeyDown��6o  6   OnKeyActivated$&6  FolderContainer_OnOnKeyActivated��6�  7 �� SelectionMode$7 Extended=�6I   $	��Top=�6c   $	��300��6{   |�. 2   ,ArduinoManagementSystem.SingleSelectionGroup8   	GroupName$8 Group B��6�   
������ ��.  #��[ 6  $9 �� IsSynchronizedWithCurrentItem$9 FalseY�6+  : � LayoutTransform: 5<     �� 5=     -   5        ListBoxLayoutTransform��; �� ScaleY$; 1Q�5=  I   6V   5?     5@     5C     5D     