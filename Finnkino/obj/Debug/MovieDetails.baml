   M S B A M L   `   `   `  ����C  ?Finnkino, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FinnkinoFinnkino  5   	       Finnkino.MovieDetails   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Finnkino     5   	     � Title$  MovieDetails��5   	   $	��600��6   $	��850��6+    � WindowStartupLocation$ CenterOwner=�5	   	   
���   � � 
ResizeMode$ NoResize=�5   	   .��5      � ��5   
   �� 5       j� Stretch$ UniformToFill=�6   -   5        backgroundImage�� �� Opacity$	 0.5Q�5   J   .+�5   
   �� -   5         ��Name$ textBlock_Title��5      
�������$��24(�6@   $��
0,176,10,0q�6N   $��	TextBlock��6b   $	��Top=�6s   $��WrapWithOverflow=�6�   $��Right=�6�   $	��392��6�   �� 5   
   -   5        $ textBlock_Rating_title��5      
�������$��14(�6G   $
��Left=�6U   $��440,244,0,0q�6p   $
��Wrap=�6�   $��IMDb: ��6�   $	��Top=�6�   �� 5   
   -   5        $ textBlock_Rating��5      
�������$��14(�6A   $
��Left=�6O   $��485,244,0,0q�6j   $
��Wrap=�6   $	��9.9��6�   $	��Top=�6�   �� 5   
   -   5        $ textBlock_Length_title��5      
�������$��14(�6G   $
��Left=�6U   $��520,244,0,0q�6p   $
��Wrap=�6�   $��Kesto: ��6�   $	��Top=�6�   �� 5   
   -   5        $ textBlock_Length��5      
�������$��14(�6A   $
��Left=�6O   $��565,244,0,0q�6j   $
��Wrap=�6   $��	TextBlock��6�   $	��Top=�6�   �� 5   
   -   5        $ textBlock_Genres��5      
�������$��14(�6A   $
��Left=�6O   $��440,268,0,0q�6j   $
��Wrap=�6   $��	TextBlock��6�   $	��Top=�6�   �� 5   
   -   5        $ 
textBlock3��5      
�������$��14(�6;   $
��Left=�6I   $��440,323,20,0q�6d   $
��Wrap=�6z   $��	TextBlock��6�   $	��Top=�6�   �� 5   
   -	   5        $ textBlock_Tickets��5      
�������$��14(�6B   $
��Left=�6P   $��440,0,20,75q�6k   $
��Wrap=�6�   $��Näytösajat:��6�   $��Bottom=�6�   �� 5   
   -
   5         ��Name$ comboBox��5       �� DisplayMemberPath$ ShowableString��6%   $
��Left=�6H   $��
440,0,0,50q�6c   $��Bottom=�6w   $	��160��6�   �� 5   
   -   5         ��Name$ button_Tickets��5      $��
Osta liput��6)   $
��Left=�6>   $��
610,0,0,50q�6Y   $��Bottom=�6m   $��75��6�   6�   5      5      