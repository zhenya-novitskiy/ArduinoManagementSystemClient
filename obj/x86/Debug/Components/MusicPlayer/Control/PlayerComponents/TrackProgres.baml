   M S B A M L   `   `   `  ����  ArduinoManagementSystemZ    TArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.TrackProgres   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      
������   � 	Resources  5         changeValue �� 
TargetName �� TargetProperty �� From	 �� To g� Duration��%�   &	        �� 5	   
   .��5
      �� $	 gr1��6   $ Color�69   $	 RedX�6[   $ TransparentX�6g   $ 0:0:1.0D�6y   �� 5      $	 gr2��6   $ Color�69   $	 RedX�6[   $ TransparentX�6f   $ 0:0:1.0D�6y   5      5      .��5      ��  J� Clip 5   
   �� 5       �� Rect$ 
0,0,271,11�6    64   .+�5   
   ��  �� BitmapScalingMode$ 
LowQuality=�6   $8��2/Components\MusicPlayer\Control\Images\trackBg.png��6?   $	��271��6{   $
��Fill=�6�   $��11��6�   	 �� Left$	 0��6�   

 �� Top$
 -1��6�   6�   �� 5   
   -   5         ��Name$ Pointer��5   1   $	 77��6   $
 9��6"   .+�5      �� -   5        $��
rectangle1��5   $   $��9��6   $��10��6H   $	 0��6S   $
 -9��6c   ��66   Z� ��5      �� 5       �� EndPoint$ 1,0.5&�6*    �� 
StartPoint$ 0,0.5&�6;   .��5      �  � Color$ Transparent��6'    � Offset$ 0Q�6;   � 5      -   5        gr1��$ Transparent��5   4   $ 0.343Q�6H   � 5      -   5        gr2��$ Transparent��5   4   $ 0.709Q�6H   � 5      $ Transparent��6'   $ 1Q�6;   5      5      �� 5      $ 
LowQuality=�6   $>��8/Components\MusicPlayer\Control\Images\trackSelector.png��6C   $��12��6�   $��Uniform=�6�   $	
 -10��6�   6�   5       � 5!   
   -   5         �Name$ ProgressBar1��5!      $	 0��6,   $
 0��6<   $��11��6K    J� Opacity$ 0Q�6X   $	��271��6d   6p   5"      5#      