   M S B A M L   `   `   `  ���� R  NArduinoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control6ArduinoManagementSystem.Components.MusicPlayer.Control  c6clr-namespace:ArduinoManagementSystem.Components.Email(ArduinoManagementSystem.Components.Email  �Uclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponentsGArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents  �Iclr-namespace:ArduinoManagementSystem.Components.SystemController.Control;ArduinoManagementSystem.Components.SystemController.Control  A%clr-namespace:ArduinoManagementSystemArduinoManagementSystem  �Eclr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control7ArduinoManagementSystem.Components.ColorChanger.Control  (    "ArduinoManagementSystem.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     SMPDclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control     HEmail6clr-namespace:ArduinoManagementSystem.Components.Email     fplayUclr-namespace:ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents     ]ControlIclr-namespace:ArduinoManagementSystem.Components.SystemController.Control     IArduinoManagementSystem%clr-namespace:ArduinoManagementSystem     ZControl1Eclr-namespace:ArduinoManagementSystem.Components.ColorChanger.Control     -     � Title$  Arduino Manager�� � SizeToContent$ WidthAndHeight=� J� 	AllowDrop .  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Icon$ icon.ico�� � AllowsTransparency . 
������  � 	Resources    RedBrush �� Color  SolidBorderBrush  	VintColor  RefreshColor	 �� 
TargetType
 �� Property �� Value ��Name �� Padding ��Name J� Opacity J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius �� Triggers �� Value �� Binding �� RelativeSource �� Mode �� AncestorType �� Path �� 
TargetName �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value��%�  &	        &	      &	 "     &	 5     '�� H     �� $ Silver���� $
 #888���� $ #212121���� $ #212121���� "	 ��.��� 
 � �� �� .R��� $
 grid��$ 0,0,0,0q�._��� ��� .+��� $ 	TextLabel��
�������$��Arial)�$
��Bold"�$��15(�#��z���� $ 
TextLabel2��$ 0Q�
�������$��Arial)�$
��Bold"�$��15(�#��z��   $ 7Q� �� $
 True�� ��  �� $ FindAncestor=�" ��$ IsMouseOver�.a��� $ 	TextLabel��
 � �� �#32ebfb�� $ 
TextLabel2��
 � �� �#32ebfb�� $ 
TextLabel2��
 �@J�Opacity$ 1Q��� $
 True�� ��  �� $ FindAncestor=�" ��$ 
IsSelected�.a��� $ 
TextLabel2��
 � ��
 ������� $ 
TextLabel2��
 �@J�Opacity$ 1Q��� 
 � �� �� " ��.R�� .+��� $ PreviewImage��$��80��$9��3/ArduinoManagementSystem;component/Images/tabBG.png���� $ ContentSite��$��Center=�$��Center=�$��Header��$��	12,2,12,2q���.  P�  �@J�IsMouseOver . P�  �@��
IsSelected . . ��� $ PreviewImage��
 � ��$? 9/ArduinoManagementSystem;component/Images/tabBGActive.png��P�  � {� .  . ��� 
 � �� �#888.��� .+��� -     �� CornerRadius$  8��$��33��$	��Top=����� ! j� Stretch$! UniformToFill=�" �� ImageSource$9" 3/ArduinoManagementSystem;component/Images/tabBG.png��� $	��Top=�$��0,7,60,0q�$��Right=�.+��� # �� Orientation$# 
Horizontal=�.+��� -   $ ��Name$$ lamp1��
���   �$��20��$��21��   $ 10Q��� -   $$ lamp2��
���   �$��20��$��21��   $ 10Q��� -   $$ lamp3��$��20,0,0,0q�
���   �$��20��$��21��   $ 10Q��� -   $$ lamp4��
���   �$��20��$��21��   $ 10Q��� -   $  8��$��33��$	��Top=�% �� BitmapScalingMode$% 
LowQuality=�$��4q�
������ 
������ �� -   & ��Name$& 
TabControl��$��0,0,0,0q�$��0q�
������ 
������ .@��� $��2��$��Music��.��J   DArduinoManagementSystem.Components.MusicPlayer.Control.PlayerControl  -	   '  Name$' MusicPlayerObject��$	��728��( �� Left$( 6��
) �� Top$) 0���� $��3��$��Email��.��;   5ArduinoManagementSystem.Components.Email.EmailControl  -
   *  Name$* EmailObject��$	��900��$	��467��$( 6��$) 0���� -   $��StatusButton��$��Right=�$��0,2,14,0q�$	��Top=����� " ��.R�� .+�� $��Center=�$��Center=�.+�F� $��Yellow��$y�Visible=�$	 0.7Q���������D����Hӭxr�;@��;@���;@Ӏ���;@(�Hӭ(��D��(��D��(�(�D����M���M����M��xr�M���(�D���D�$��28.856��+ �� Stretch$
+ Fill=�$��28.856����
� , 
� Center$, 0.482,0.882&�- 
� GradientOrigin$- 0.482,0.882&�. 
� RadiusY$. 0.554Q�/ 
� RadiusX$/ 0.554Q�.��� 0 � Color$0 	#FFFFC700��1 � Offset$1 0Q�� $0 	#FFFF6800��$1 1Q�F� $��Green��$y�	Collapsed=�$	 0.7Q���������D����Hӭxr�;@��;@���;@Ӏ���;@(�Hӭ(��D��(��D��(�(�D����M���M����M��xr�M���(�D���D�$��28.856��$
+ Fill=�$��28.856����
� $, 0.482,0.882&�$- 0.482,0.882&�$. 0.554Q�$/ 0.554Q�.��� gr1��$0 	#FF2FFF00��$1 0Q�� gr2��$0 	#FF006806��$1 1Q�F� $	��Red��$y�	Collapsed=���������D����Hӭxr�;@��;@���;@Ӏ���;@(�Hӭ(��D��(��D��(�(�D����M���M����M��xr�M���(�D���D�$��28.856��$
+ Fill=�$��28.856����
� $, 0.482,0.882&�$- 0.482,0.882&�$. 0.554Q�$/ 0.554Q�.��� gr1��$	0 Red��$1 0Q�� gr2��$0 	#FF810000��$1 1Q�� $��RefreshRotation��$��25��$��28��$��
-2.5,0,0,0q�$	 0.7Q�2 J� RenderTransformOrigin$2 	0.558,0.5&�z��� IconRefresh��3 �� Angle$3 0Q�4 � Triggers4 :� 5 :� RoutedEvent$5 Loaded��.[��� .���� .��W� 6 �� 
TargetName$6 IconRefresh��7 �� TargetProperty$7 Angle�8 W� From$8 0X�	9 W� To$	9 360X�: g� Duration$: 0:0:1.75D�; g� 	BeginTime$; 0:0:0.1X�< g� RepeatBehavior$< Forever��.+�F� $	 0.1Q�p�����̩Dx7����6���n6� ��n6����n6���6��̑6ќ�D��Ӵ �,��ߗ�دt��\�#��[ $��6.078��$
+ Fill=�$��1.184��= � UseLayoutRounding= .  $��Right=�$��0,0,11.466,0q�$	��Top=�F� $	 0.1Q�S�����Ф B��HO��ұ«P��H%��`��t�0�>�P���%<�����9 �x�8#��[ $��6.137��$
+ Fill=�$��2.381��= .  $��Right=�$��0,0.125,9.287,0q�$	��Top=�F� $	 0.2Q�S����������pX��ӷ`�������Ē�ѠY��[L�X��4hH0��<�D o�$�A#��[ $
��6.03��$
+ Fill=�$��3.214��= .  $��Right=�$��0,0.573,7.359,0q�$	��Top=�F� $	 0.3Q�S����H�����Ә��`h�H��H`����@��X="8c�ط0]\p��mVxE&Q#��[ $��5.814��$
+ Fill=�$��4.229��= .  $��Right=�$��0,1.335,5.447,0q�$	��Top=�F� $	 0.3Q�\����4-Tk���|����K��H������<t��|�є�B�0~��<�ZwT�4�q4-Tk#��[ $��5.316��$
+ Fill=�$��4.867��= .  $��Right=�$��0,2.631,3.668,0q�$	��Top=�F� $	 0.4Q�S�����a�ԣ�hS[�����S,��x�K,��0�|���V����`_�4w����9�#��[ $��5.061��$
+ Fill=�$��5.592��= .  $��Right=�$��0,4.073,2.135,0q�$	��Top=�F� $	 0.4Q�\���Ш�iF��`�ln��(�����aD	�l�
�(��̸����|\�� \t̴���iF�#��[ $��4.511��$
+ Fill=�$��6.451��= .  $��Right=�$��0,6.088,0.454,0q�$	��Top=�F� $	 0.5Q������(E����0�	$���F
,�
�T#�
��(��
L�+x�
lI.�V
\1�}�t1�脋��/ோ�l.ோ�-�ோ�|�ǉLV
(E���#��[ $
+ Fill=�$��6.501��= .  $��Right=�$��0,9.761,0.178,12.476q�F� $	 0.6Q�\���Ќ���tA�40�|A�d���H�zp�O$�ОV�<v�e��L��x�X��]����tA#��[ $��3.995��$
+ Fill=�$��6.845��= .  $��Right=�$��0,0,0.229,7.572q�$��Bottom=�F� $	 0.7Q�S����d�|Re���r�h�tj}��t�����/�/�Ӡ�I�,�hT_��xo�0�#��[ $
��6.79��$
+ Fill=�$
��7.25��= .  $��Right=�$��0,0,1.606,3.075q�$��Bottom=�F� $	 0.8Q�\���Аn"��Ѹ��P�� �|�Ќ�PR� P��O�� P��"� H���� 8��n"��#��[ $��7.316��$
+ Fill=�$��5.803��= .  $��Right=�$��0,0,5.437,0.411q�$��Bottom=�F� $	 0.9Q�������Л\�Ӑq�T��`��ܡ����ܡ��ʀ�ܡ��pLb�HJbt,���cDӐ@�-(i��#����#ӘL���#Њ��|#�Л�l##��[ $��6.976��$
+ Fill=�= .  $��9.602,0,12.031,0.292q�$��Bottom=�F� $ 1Q�������K|���(�.D�v��PU��/� �U/Ѹ�����H�}8p@/��T���`p@/�o���Tap@4e���ׁs�p@����V�#��[ $
+ Fill=�$��12.47��= .  $
��Left=�$��0,5.466,0,2.478q�� $��Rotation��$��	1,1.5,0,0q�$y�	Collapsed=�.+�� $��28��$��27��$	 0.2Q�$2 
0.51,0.492&�z��� 	Icon1��$3 0Q�4 :� $5 Loaded��.[��� .���� .��W� $6 Icon1��$7 Angle�$8 0X�$	9 360X�$: 0:0:0.75D�$; 0:0:0.1X�$< Forever��.+�F� ?���p��D�d�`�E@Q�~�H#J{�H@QX([P�f��K@Q�g�o���H@#��[ $��11.676��$ 1Q�$
+ Fill=�$��11.725��= .  $��Right=�$��0,0,-0.334,0q�$	��Top=�F� ?���pd�l�d�`�E@Q�Qo��I@Q\�+��3�DJ@Q���9#J�F@#��[ $��8.752��$ 1Q�$
+ Fill=�$
��8.69��= .  $
��Left=�$��0,0.125,0,0q�$	��Top=�F� ?���p@×��H.�YG@Q��6O�Fx�J@Q��V�q���K@Q`9���m4��H@#��[ $��8.757��$ 1Q�$
+ Fill=�$��8.695��= .  $
��Left=�$��3.03,3.044,0,0q�$	��Top=�F� ��������<����%�<��@���^�@����h�@����J�%��2����2�����2p���Jp���h�p��^����<�����<��������ӐӠ�� Ss:/ SslQg� Ss�p��Ӡ������������>�p���>lQgӐ�>:/�������#��[ $ 1Q�$
+ Fill=�= .  $��7.172,6.944,6.51,7.738q�F� 5����`��8�� 38�Q 3���MbP@Q`�����MbP@#��[ $��3.536��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,3.992q�$��Bottom=�F� +����`��(<L� 3(<L� 3h�`��h#��[ $��3.288��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,-0.59q�$��Bottom=�� $��28��$��27��$	 0.4Q�$2 
0.51,0.492&�z��� 	Icon2��$3 0Q�4 :� $5 Loaded��.[��� .���� .��W� $6 Icon2��$7 Angle�$8 0X�$	9 360X�$: 0:0:0.75D�$; 0:0:0.05X�$< Forever��.+�F� ?���p��D�d�`�E@Q�~�H#J{�H@QX([P�f��K@Q�g�o���H@#��[ $��11.676��$ 1Q�$
+ Fill=�$��11.725��= .  $��Right=�$��0,0,-0.334,0q�$	��Top=�F� ?���pd�l�d�`�E@Q�Qo��I@Q\�+��3�DJ@Q���9#J�F@#��[ $��8.752��$ 1Q�$
+ Fill=�$
��8.69��= .  $
��Left=�$��0,0.125,0,0q�$	��Top=�F� ?���p@×��H.�YG@Q��6O�Fx�J@Q��V�q���K@Q`9���m4��H@#��[ $��8.757��$ 1Q�$
+ Fill=�$��8.695��= .  $
��Left=�$��3.03,3.044,0,0q�$	��Top=�F� ��������<����%�<��@���^�@����h�@����J�%��2����2�����2p���Jp���h�p��^����<�����<��������ӐӠ�� Ss:/ SslQg� Ss�p��Ӡ������������>�p���>lQgӐ�>:/�������#��[ $ 1Q�$
+ Fill=�= .  $��7.172,6.944,6.51,7.738q�F� 5����`��8�� 38�Q 3���MbP@Q`�����MbP@#��[ $��3.536��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,3.992q�$��Bottom=�F� +����`��(<L� 3(<L� 3h�`��h#��[ $��3.288��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,-0.59q�$��Bottom=�� $��28��$��27��$2 
0.51,0.492&�z��� 	Icon3��$3 0Q�4 :� $5 Loaded��.[��� .���� .��W� $6 Icon3��$7 Angle�$8 0X�$	9 360X�$: 0:0:0.75D�$< Forever��.+�F� ?���p��D�d�`�E@Q�~�H#J{�H@QX([P�f��K@Q�g�o���H@#��[ $��11.676��$ 1Q�$
+ Fill=�$��11.725��= .  $��Right=�$��0,0,-0.334,0q�$	��Top=�F� ?���pd�l�d�`�E@Q�Qo��I@Q\�+��3�DJ@Q���9#J�F@#��[ $��8.752��$ 1Q�$
+ Fill=�$
��8.69��= .  $
��Left=�$��0,0.125,0,0q�$	��Top=�F� ?���p@×��H.�YG@Q��6O�Fx�J@Q��V�q���K@Q`9���m4��H@#��[ $��8.757��$ 1Q�$
+ Fill=�$��8.695��= .  $
��Left=�$��3.03,3.044,0,0q�$	��Top=�F� ��������<����%�<��@���^�@����h�@����J�%��2����2�����2p���Jp���h�p��^����<�����<��������ӐӠ�� Ss:/ SslQg� Ss�p��Ӡ������������>�p���>lQgӐ�>:/�������#��[ $ 1Q�$
+ Fill=�= .  $��7.172,6.944,6.51,7.738q�F� 5����`��8�� 38�Q 3���MbP@Q`�����MbP@#��[ $��3.536��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,3.992q�$��Bottom=�F� +����`��(<L� 3(<L� 3h�`��h#��[ $��3.288��$ 1Q�$
+ Fill=�= .  $��9.173,0,8.619,-0.59q�$��Bottom=�F� $
��Stop�������������<��
4�ӤQ�
�7D$��
�A($��
�4�x$��
4`�<>4`�|Ǝ�4`�D�$
��C��������A(�� Ӵ��
�� �'�
�z��'�
|ƎӜ'�
T�j�q�
�`IlW�
��/�l�vd�	��`$]4E�� �A(�� м�(T�
�7�
T�
�#m
\k(�#m
$"�Ӝ#m
���7�
D�K��(D�K�l��D�K���������$"�����\k(l��T�
��(T�
���	#FFFFEBFF$��20.616��$ 0Q�$
+ Fill=�$��20.615�� P�  � �� . . ��� $
 Stop��
 �@J�Opacity$ 1Q�P�  � ��$
 True��. ��� $ Rotation��
 � y�$ Visible=��� $ Green��
 � y�$ Visible=��� $ Yellow��
 � y�$ 	Collapsed=��� $ RefreshRotation��
 � y�$ 	Collapsed=�P�  �@J�IsMouseOver . . ��� $ Green��
 � y�$ 	Collapsed=��� $	 Red��
 � y�$ Visible=��� $
 Stop��
 �@J�Opacity$ 1Q�