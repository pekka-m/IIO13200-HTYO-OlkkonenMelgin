   M S B A M L   `   `   `  ����C  ?Finnkino, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FinnkinoFinnkino  5   	       Finnkino.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Finnkino     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��850��6)    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� $
��Auto=�6   .��5      ��  �� Orientation$ Vertical=�6   $��5q�60   .+�5      �� $��Paras niinku nevö��6   $��18(�65   $
��Left=�6C   $	��Top=�6^   $��0,0,0,5q�6v   �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ comboBox_Area��5       �� DisplayMemberPath$ Theatre��66    �� SelectedValuePath$ AreaId��6R   $��12(�6m   $
��Left=�6{   $	��Top=�6�   $	��150��6�   6�   �� 5      -   5        $ comboBox_Sort��5      $��12(�66   $
��Left=�6D   $��10,0,0,0q�6_   $	��Top=�6q   $	��150��6�   6�   �� 5      -   5         ��Name$ checkBox_allDays��5      $	��Top=�69   $��Kaikki päivät��6Q   $��10 3 0 0q�6i   5      �� 5      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5      �� -   5        $ comboBox_Filter_Genre��5      $��12(�6>   $
��Left=�6L   $	��Top=�6g   $	��150��6   6�   �� 5      -   5        $ comboBox_Filter_AgeLimit��5      $��12(�6A   $
��Left=�6O   $��10,0,0,0q�6j   $	��Top=�6|   $	��150��6�   6�   �� 5      -   5        $  comboBox_Filter_Auditorium��5      $��12(�6C   $
��Left=�6Q   $��10,0,0,0q�6l   $	��Top=�6~   $	��150��6�   6�   �� 5      -   5         ��Name$ button_filter��5      $	��Top=�64   $	��Hae��6L   $��10 0 0 0q�6Z   $��80��6l   6w   5      �� 5      -   5         ��Name$ 	BrowserIC��5      $��0,5,0,0q�62   ��5      �� 5      .R�5      �� $ Vertical=�6)   .+�5   "   �� $��18(�6,   $��10,15,10,10q�6:   ��6O   �� 	 �� Path$		 Day�
 �� StringFormat$
 dddd dd/MM/yyyy���� 5   "   ��6/   �� *Movies+��5   &   �� 5    *   .R�5!   .   ��  �� CornerRadius$ 6��65   
���   �
���   �$��2q�6m   $��5q�6�   ._�5"   2   �� $ Vertical=�6=   $	��100��6T   .+�5#   6   �� $��
cmdCommand��6=   -	   5        .��5$   :   �� .+�5%   >   �� $��UniformToFill=�6D   ��6\   �� *!Images.EventMediumImagePortrait+�� 5&   >    ��Name$ textBlock_Title��6T   $��50��6H   $
��Wrap=�6�   ��6m   �� *Title+6�   �� 5'   >   $	 day��6g   $��0��6H   $y�Hidden=�6S   ��6t   �� *dttmShowStart+�� 5(   >   $ 	eventtiId��6g   $��0��6H   $y�Hidden=�6S   ��6z   �� *	EventID+�� 5)   >   $ originalTitle��6g   $��0��6H   $y�Hidden=�6S   ��6~   �� *OriginalTitle+5*   ;   5+   7   5,   3   5-   /   5.   +   ��50   &   �� 51   *   .R�52   .   � 53   +   55   #   56      57      59      5:      5;      5<      5=      