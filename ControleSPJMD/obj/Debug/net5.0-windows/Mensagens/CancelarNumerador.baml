   M S B A M L   `   `   `  ����H  DControleSPJMD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ControleSPJMD.MensagensControleSPJMD.Mensagens  5   	   /    )ControleSPJMD.Mensagens.CancelarNumerador   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:ControleSPJMD.Mensagens  5   	     � Language$  pt-BR�5	   	    � Title$ CancelarNumerador��5
   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69   $	��756��6^   $	��242��6j    � WindowStyle$
 None=�6w    � Icon$ 	/ppjm.png��6�   .��5      � .+�5   
   �� 
����������	#FFFAA61A$��5��64   � 5   
   $��
10,82,0,83q�6   $
��Left=�6#   $	��102��6>   ��5      �� 5       �� ImageSource$ /Mensagens/atencao.png��6    j� Stretch$ Uniform=�6B   5      �� 5   
   $��
ATENÇÃO!��6   $
��Left=�6#   $��
347,10,0,0q�6>   $	��Top=�6R   $��Verdana)�6j   $��24(�6   $
��Bold"�6�   �� 5   
   $��Para Anular o numerador:��6   $
��Left=�63   $	��Top=�6N   $��Verdana)�6f   $
��Bold"�6{   $	��606��6�   $
��Left=�6�   $��Center=�6�   ���	#FFFAA61A$��
117,52,0,0q�6�   �� 5   
   $K��E1 - Descreva o motivo no campo abaixo e pressione o botão CONFIRMAR.��6   $
��Left=�6_   $	��Top=�6z   $��Verdana)�6�   $
��Bold"�6�   $	��606��6�   $
��Left=�6�   $��Center=�6�   ���	#FF6374A6$��
117,75,0,0q�6   �� 5   
   -   5         ��Name$ btnConfirmar��5      $��	CONFIRMAR��6'   $
��Left=�6;   $��287,190,0,0q�6V   $	��Top=�6k   
�������
���   �
���   �$��2��6�   $	��120��6�   $
��Bold"�6�   	 � Cursor$
	 Hand��6�   6�   �� 5   
   -   5        $ btnCancelar��5      $��CANCELAR��6&   $
��Left=�69   $��429,190,0,0q�6T   $	��Top=�6i   
�������
���   �
���   �$��0��6�   $	��120��6�   $
��Bold"�6�   $
	 Hand��6�   �� 5   
   $W��Q2 - Apenas o usuário que cadastrou o numerador poderar realizar essa operação.��6   $
��Left=�6i   $	��Top=�6�   $��Verdana)�6�   $
��Bold"�6�   $	��606��6�   $
��Left=�6�   $��Center=�6�   ���	#FF6374A6$��
117,97,0,0q�6*  �� 5   
   -   5        
 ��Name$
 txtObsCancelaNum��5      $
��Left=�6,   $��117,134,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6q   $	��606��6�   $��Verdana)�6�   $
��Bold"�6�   ���	#FFD9D9D9$��1,1,1,1q�6�   $��4,4,4,4q�6�   $	 Arrow��6    �� 	MaxLength$ 50��6  
���   �$��1��61  5      5      