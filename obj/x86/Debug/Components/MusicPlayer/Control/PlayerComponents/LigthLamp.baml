   M S B A M L   `   `   `  ����  ArduinoManagementSystemW    QArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents.LigthLamp   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         	moveLigth �� 
TargetName �� TargetProperty	 W� To g� Duration W� From g� 	BeginTime��%�  &	        �� 5	   
   .��5
      W� $ 	Container��6   $ (Canvas.Left)�6@   $ -3X�6k   $ 0:0:0.10D�6u   W� 5      $ 	Container��6   $ (Canvas.Top)�6@   $ -2X�6j   $ 0:0:0.10D�6s   W� 5      $ 	Container��6   $ (Canvas.Left)�6@   $ -3X�6j   $ -7X�6t   $ 0:0:0.10X�6}   $ 0:0:0.55D�6�   W� 5      $ 	Container��6   $ (Canvas.Top)�6@   $ -2X�6i   $ -6X�6s   $ 0:0:0.10X�6{   $ 0:0:0.55D�6�   W� 5      $
 blur��6   $ Radius�6;   $ 15X�6_   $ 0:0:0.10D�6h   W� 5      $
 blur��6   $ Radius�6;   $ 2X�6_   $ 0:0:0.10X�6f   $ 0:0:0.55D�6{   5      5      .��5      �� .+�5   
   �� -   5         ��Name$
 img3��5      $6��0/Components\MusicPlayer\Control\Images\lamp3.png��6   $��Uniform=�6X   $��60��6j   $��60��6v    �� Left$ 0��6�   
	 �� Top$	 0��6�   6�   �� 5   
   -   5        
 ��Name$
 	Container��5      $ -7��6$   $	 -7��65   .+�5      � -   5         �Name$ lighter2��5       � Points/ �   ���� u �� -1@x} -1$	 -10��6`   $		 -26��6r   ��6*   Z� z�5      �� 5       �� Angle$	 122Q�6&    �� CenterX$ 20Q�5       �� CenterY$ 20Q�6   ��5      �� 5      -   5        
GradBorder�� �� EndPoint$	 0,1&�5   >    �� 
StartPoint$	 0,0&�6M   .��5      �  � Color$	 Red��6'    � Offset$ 0Q�63   � 5      $ 	#00FF0000��6'   $ 1Q�69   5        J� Effect 5"      -  'System.Windows.Media.Effects.BlurEffect  5#         Radius$ 5Q�6!   6.   5%      �� 5'      -   5        $	 img��5'      $6��0/Components\MusicPlayer\Control\Images\lamp1.png��6!   $��Uniform=�6[   $��60��6m   $��60��6y   $ 0��6�   $	 0��6�   6�   � 5(      -   5        $ lighter��5(      ' �   ���;G�J] �� ��$ 23��6\   $	 49��6m   ��6(   Z�  5)        5*      -   5        blur��$ 0Q�5*   /   6<   z�5-      �� 5.      $	 -58Q�6&   $ 20Q�5/      $ 20Q�6   ��51      
� 52       
� GradientOrigin$ 0.5,0.0&�6*    
� Center$ 0.5,0.5&�6C   .��53      � $	 Red��6'   -   5        GradientStop1��$ 0Q�53   J   � 54      $ Transparent��6'   -	   5        GradientStop2��$ 1Q�54   R   55      57      �� 58      -
   5        $
 img4��58      $6��0/Components\MusicPlayer\Control\Images\lamp4.png��6"   $��Uniform=�6\   $��60��6n   $��60��6z   $ 0��6�   $	 0��6�   6�   59      �� 5:   
   -   5        $
 img2��5:      $6��0/Components\MusicPlayer\Control\Images\lamp2.png��6   $��Uniform=�6X   $��60��6j   $��60��6v   $ 0��6�   $	 0��6�   6�   �� 5;   
   -   5        $��
textBlock1��5;   U   $ 19��6   
�������$	 32��69   $��23��6I   ��6g   �� *	TextColor+ �� Mode$ TwoWay=�5<      5=      