   M S B A M L   `   `   `  ����   ArduinoManagementSystemb    \ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.PlayListFolderHeader   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� $��Stretch=�����   �� ImageSource$;  5/Components\MusicPlayer\Control\Images\playlistBG.png�� � Triggers :�  :� RoutedEvent$ Mouse.MouseEnter��.[��� .����  �� 
TargetName$ ButtonsPannel�� �� TargetProperty$ Opacity�.��W� 	 W� To$ 1X� W� From$ 0X� g� Duration$ 0:0:0.1D�:� $ Mouse.MouseLeave��.[��� .���� $ ButtonsPannel��$ Opacity�.��W� $ 0X�$ 1X�$ 0:0:0.1D�.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   	 ��Name$	 
FolderName��
�������$
��Bold"�$��
FolderName��$��Stretch=�
 �� TextAlignment$
 Center=�$��20���� -   $	 TracksCount��
����� �$�� ��$��5,0,0,0q�$
 Center=�$��20��� -    �Name$ ButtonsPannel�� J� Opacity$ 0Q�.+�� -   $ Remove��
������ $��Right=�$��13��$��13��$��0,0,5,0q�.+�A� -    A�Name$ RemoveEllipse��$��1��
���  ���� 	 �� X1$	 3.5��	 �� Y1$	 3.5��	 �� X2$	 9.5��	 �� Y2$	 9.5��$��2������ *Stroke+ �� ElementName$ RemoveEllipse�� �� Mode$ TwoWay=��� $	 9.5��$	 3.5��$	 3.5��$	 9.5��$��2������ *Stroke+$ RemoveEllipse��$ TwoWay=�� -   $ Refresh��
������ $��Right=�$��12��$��12��$��0,0,25,0q�.+�� $��0,1,0,-1q�.+�A� -   $ RefreshEllipse��$��1��
��� ��� J� Clip ��  �� Rect$ 
0,0,6.5,10��� 
������ $��6.5,0,0,6.5q�$��1��$	��4.5��$	��4.5������ *Stroke+$ RefreshEllipse��$ TwoWay=� �� $ 0,0,3.5,3.5�z���  �� Angle$	 135Q�� $��-1,0,1,0q�.+�� $��13,11,-13,-11q�z��� $	 180Q�.+�A� $��1������ *Stroke+$ RefreshEllipse��$ TwoWay=� �� $ 
0,0,6.5,10��� 
������ $��6.5,-6.5,0,0q�$��1��$	��4.5��$	��4.5������ *Stroke+$ RefreshEllipse��$ TwoWay=� �� $ 0,0,3.5,3.5�z��� $	 135Q�� -   $	 Add��
������ $��Right=�$��13��$��13��$��0,0,45,0q�.+�A� -	   $ 
AddEllipse��$��1��
��� � ��� $	 6.5��$ 2��$	 6.5��$ 11��$��2������ *Stroke+$ 
AddEllipse��$ TwoWay=��� $ 2��$	 6.5��$ 11��$	 6.5��$��2������ *Stroke+$ 
AddEllipse��$ TwoWay=�