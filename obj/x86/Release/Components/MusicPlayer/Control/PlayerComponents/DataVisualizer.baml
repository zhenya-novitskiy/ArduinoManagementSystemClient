   M S B A M L   `   `   `  ����   ArduinoManagementSystem\    VArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.DataVisualizer   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     
������   � 	Resources     disableAnim �� 
TargetName �� TargetProperty	 W� To g� Duration g� 	BeginTime  
enableAnim��%  &	        &	 e    �� .��W� $ waver��$ Opacity�$ 0X�$ 0:0:0.10D�W� $ waver2��$ Opacity�$ 0X�$ 0:0:0.10D�W� $ waver3��$ Opacity�$ 0X�$ 0:0:0.10D�W� $ waver4��$ Opacity�$ 0X�$ 0:0:0.10D�W� $ border��$ Opacity�$	 0.9X�$ 0:0:0.20D�W� $ bgImage��$ Opacity�$	 0.3X�$ 0:0:0.10X�$ 0:0:0.10D��� .��W� $ waver��$ Opacity�$ 1X�$ 0:0:0.10X�$ 0:0:0.10D�W� $ waver2��$ Opacity�$	 0.5X�$ 0:0:0.10X�$ 0:0:0.10D�W� $ waver3��$ Opacity�$	 0.5X�$ 0:0:0.10X�$ 0:0:0.10D�W� $ waver4��$ Opacity�$ 1X�$ 0:0:0.10X�$ 0:0:0.10D�W� $ border��$ Opacity�$ 0X�$ 0:0:0.20D�W� $ bgImage��$ Opacity�$ 1X�$ 0:0:0.10D�.���� 
������ .+��� -    ��Name$ bgImage�� �� BitmapScalingMode$ 
LowQuality=�$	��250��$?��9/Components\MusicPlayer\Control\Images\osciloscopeBG2.png�� �� Left$ 41��
	 �� Top$	 39���� -   $ bgImage2��$ 
LowQuality=�$	��332��$A��;/Components\MusicPlayer\Control\Images\dataVisualizerBG.png���� .+�F� -   
 F�Name$
 waver2������        р��    	 J� Opacity$	 0.5Q�$		 130��$ 41��
����� �$��5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect  -   blur��   Radius$ 20Q�F� -   $
 waver������        р��    	
�������$		 130��$ 41��$��2��F� -   $
 waver3������@Ys@����@Ys@x}	$	 0.5Q�$		 115��
����� �$��5��$ 39��   $ 20Q�F� -   $
 waver4������@Ys@����@Ys@x}	$		 115��
�������$��2��$ 39�� J� Clip ��  �� Rect$ 0,0,290,137��� -    ��Name$ border��.+��� -	   $��
rectangle1��$ 31��
���   �$	 29��$��12��
���   �$	��277���� -
   $��
rectangle2��$ 31��
���   �$		 137��$��12��
���   �$	��277���� -   $��
rectangle3��$ 31��
���   �$	 41��$��96��
���   �$��11���� -   $��
rectangle4��$	 290��
���   �$	 41��$��96��
���   �$��18��