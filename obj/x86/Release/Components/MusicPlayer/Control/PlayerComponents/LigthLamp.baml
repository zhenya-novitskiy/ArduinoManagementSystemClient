   M S B A M L   `   `   `  ����   ArduinoManagementSystemW    QArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.LigthLamp   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     	moveLigth �� 
TargetName �� TargetProperty	 W� To g� Duration W� From g� 	BeginTime��%�  &	        �� .��W� $ 	Container��$ (Canvas.Left)�$ -3X�$ 0:0:0.10D�W� $ 	Container��$ (Canvas.Top)�$ -2X�$ 0:0:0.10D�W� $ 	Container��$ (Canvas.Left)�$ -3X�$ -7X�$ 0:0:0.10X�$ 0:0:0.55D�W� $ 	Container��$ (Canvas.Top)�$ -2X�$ -6X�$ 0:0:0.10X�$ 0:0:0.55D�W� $
 blur��$ Radius�$ 15X�$ 0:0:0.10D�W� $
 blur��$ Radius�$ 2X�$ 0:0:0.10X�$ 0:0:0.55D�.���� .+��� -    ��Name$
 img3��$6��0/Components\MusicPlayer\Control\Images\lamp3.png��$��Uniform=�$��60��$��60�� �� Left$ 0��
	 �� Top$	 0���� -   
 ��Name$
 	Container��$ -7��$	 -7��.+�� -    �Name$ lighter2�� � Points/ �   ���� u �� -1@x} -1$	 -10��$		 -26����Z� z���  �� Angle$	 122Q� �� CenterX$ 20Q� �� CenterY$ 20Q����� -   
GradBorder�� �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$	 Red�� � Offset$ 0Q�� $ 	#00FF0000��$ 1Q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 5Q��� -   $	 img��$6��0/Components\MusicPlayer\Control\Images\lamp1.png��$��Uniform=�$��60��$��60��$ 0��$	 0��� -   $ lighter��' �   ���;G�J] �� ��$ 23��$	 49����Z�    -   blur��$ 0Q�z��� $	 -58Q�$ 20Q�$ 20Q���
�  
� GradientOrigin$ 0.5,0.0&� 
� Center$ 0.5,0.5&�.��� $	 Red��-   GradientStop1��$ 0Q�� $ Transparent��-	   GradientStop2��$ 1Q��� -
   $
 img4��$6��0/Components\MusicPlayer\Control\Images\lamp4.png��$��Uniform=�$��60��$��60��$ 0��$	 0���� -   $
 img2��$6��0/Components\MusicPlayer\Control\Images\lamp2.png��$��Uniform=�$��60��$��60��$ 0��$	 0���� -   $��
textBlock1��$ 19��
�������$	 32��$��23������ *	TextColor+ �� Mode$ TwoWay=�