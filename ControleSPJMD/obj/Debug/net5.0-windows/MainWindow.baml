   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    ControleSPJMD   ControleSPJMD.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	     � Language$  pt-BR�5	   	    � Title$ JanelaProcedimento��5
   	    � 
ResizeMode$ NoResize=�6$    � WindowStartupLocation$ CenterScreen=�6:   $
��1280��6_   $	��680��6l    � WindowStyle$
 None=�6y    � Icon$ 	/ppjm.png��6�   .��5      � .+�5   
   � -   5         �Name$ gridPrincipal��5      $y�	Collapsed=�6&    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��30 �6    �� 5      $
��307* �6    �� 5      $��30 �6    .+�5      � $��1��6   ���	#FFD9D9D9 5      �� 5      $��71 �6$   �� 5      $��* �6$   .+�5      � $��
0,10,0,534q�6   $��2��6+   ��5      �� 5      	 j� Stretch$	 Uniform=�6%   
 �� ImageSource$
 
/deusa.png��67   5!      �� 5"      $��SPJMD��6   $��Center=�6(   $��1��6E   $	��Top=�6R   $	��180��6j   $��Center=�6v   $
��Bold"�6�   $��20(�6�   $��Rubik)�6�   $��29��6�   $��0,10,0,0q�6�   ���	#DD0000006�   �� 5#      -   5         ��Name$ btnNumerador��5#      $��10,49,10,468q�6/   $��1��6E   ���	#FF6374A6
���   �$��	NUMERADOR��6�   $��Verdana)�6�   $��1��6�   $
��Bold"�6�   $��Stretch=�6�   $��Center=�6�   $��Center=�6  $��Normal$�6?  $��14(�6R   �� IsCancel$
 True��6`  ��6i   Z� 6p  �� 5$      -   5        $ btnPoliciais��5$      $��10,86,10,431q�6/   $��1��6E   ���	#FF6374A6
���   �$��	POLICIAIS��6�   $��Verdana)�6�   $��2��6�   $��14(�6�   $
��Bold"�6�   ��6i   Z� 6�   �� 5%      $��10,123,10,394q�6   $��1��60   ���	#FF6374A6
���   �$��PROCEDIMENTOS��6~   $��Verdana)�6�   $��3��6�   $��14(�6�   $
��Bold"�6�   ��6T   Z� 6�   �� 5&      $��10,160,10,357q�6   $��1��60   ���	#FF6374A6
���   �$��	PROCESSOS��6~   $��Verdana)�6�   $��4��6�   $��14(�6�   $
��Bold"�6�   ��6T   Z� 6�   �� 5'      $��10,197,10,320q�6   $��1��60   ���	#FF6374A6
���   �$��
CORREG/CAJ��6~   $��Verdana)�6�   $��5��6�   $��14(�6�   $
��Bold"�6�   ��6T   Z� 6�   �� 5(      $��10,234,10,283q�6   $��1��60   ���	#FF6374A6
���   �$��	USUÁRIOS��6~   $��Verdana)�6�   $��6��6�    � Cursor$
 Hand��6�   $
��Bold"�6�   $��14(�6�   ��6T   Z� 6�   �� 5)      -   5         ��Name$ lblBuzzoDeveloper��5)      $��Label��63   $��Center=�6C   $��	0,514,0,0q�6`   $��1��6s   $	��Top=�6�   $��Verdana)�6�   $	��180��6�   $��Center=�6�   $��Center=�6�   
���   �$
��Bold"�6  $��10(�6$   J� Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         
BlurRadius$ 12Q�6'      Color$ Black��67      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]      	Direction$	 350Q�6m   5-      � 5.      -   5        $ gridBarraTitulo��5.      $��2��6,   ���	#FF020873.+�5/      �� �� 50       �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�51      �� -   5        $ btnCalendario��51       0  ,MaterialDesignFloatingActionMiniAccentButton#��[  64   $��25��6z   $��25��6�   
�������$��7��6�   ��6�   Z� ��6�   Z� .��52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Calendar=�62   53      �� 54      -   5        $ btnMinimizar��54      #��[  63   $��25��6y   $��25��6�   
�������$��8��6�   ��6�   Z� ��6�   Z� .��55        $ WindowMinimize=�62   56      �� 57      -   5        $ btnFecharPrograma��57      #��[  68   $��25��6~   $��25��6�   
�������$��9��6�   ��6�   Z� ��6�   Z� .��58        $ Power=�62   59      5:       5;        5<      $ 12Q�6'   $ Black��67   $ Quality=�6E   $ 1Q�6]   $	 630Q�6m   5>      � 5?      $��2��6   ���	#FF020873$��2��67   .+�5@      �� �� 5A      -	   5        $ lblPM_Logado��5A      $��Center=�6.   $��Center=�6K   $��Verdana)�6f   $��9(�6{   
�������6�    5B        5C      $ 12Q�6'   $ Black��67   $ Quality=�6E   $ 1Q�6]   $
 -630Q�6m   5E      � 5F      -
   5        $ gridCalendario��5F      $y�	Collapsed=�6+   $��1��6B   $��803,10,10,246q�6R   $��1��6i   .+�5G      &   System.Windows.Controls.Calendar  $
��Left=�6   $��Center=�66   $	��257��6Q   5H      5I      � 5L   
   -   5        $ 	gridLogin��5L      $y�Visible=�6"   
�������$��Right=�6J   $
��1280��6f   .+�5M      �� $:��4SEÇÃO DE POLÍCIA JUDICIÁRIA MILITAR E DISCIPLINA��6   $��0,31,0,0q�6O   $��Center=�6a   $	��Top=�6~   $��
Constantia)�6�   $��36(�6�   $��Normal$�6�   $
��Bold"�6�   �� 5N      $��Uniform=�6    �� StretchDirection$
 Both=�6&   $��Center=�6>   $	��Top=�6[   $��	0,107,0,0q�6s   $	��246��6�   $	��326��6�   $��
/deusa.png��6�   �� 5O      $��USUÁRIO��6   $��Center=�6&   $��	0,385,0,0q�6C   $	��Top=�6V   $��
Constantia)�6n   $
��Bold"�6�   $��16(�6�   �� 5P      -   5         ��Name$ txtLogin��5P      $��Center=�6(   $��	0,418,0,0q�6E   $	��Top=�6X   $	��120��6p   $��Arial Black)�6|   $��14(�6�   $��Center=�6�   $��Center=�6�   $��0��6�    �� 	MaxLength$ 6��6#   �� TextWrapping$
 Wrap=�61  6E  �� 5Q      $��SENHA��6   $��Center=�6$   $��	0,497,0,0q�6A   $	��Top=�6T   $��
Constantia)�6l   $
��Bold"�6�   $��16(�6�   G� 5R      -   5         G�Name$ txtSenha��5R      $��Center=�6,   $��	0,530,0,0q�6I   $	��Top=�6\   $	��120��6t   $��1��6�   $��Center=�6�   $��Center=�6�   $��14(�6�   �� 5S      -   5        $ 	btnEntrar��5S      $��ENTRAR��6(   $
��Left=�69   $��528,601,0,0q�6T   $	��Top=�6i   
�������
���   �
���   �$��2��6�   $��92��6�   $
��Bold"�6�   �� 5T      -   5        $ btnSairLogin��5T      $��FECHAR��6+   $
��Left=�6<   $��660,601,0,0q�6W   $	��Top=�6l   
�������
���   �
���   �$��3��6�   $��92��6�   $
��Bold"�6�   5U      5V      5Y      