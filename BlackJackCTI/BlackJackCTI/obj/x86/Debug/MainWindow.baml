   M S B A M L   `   `   `  ����  BlackJackCTI    BlackJackCTI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   �   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          � Title$  	BlackJack��5   	    � 
ResizeMode$ 	CanResize=�62    � WindowStartupLocation$ CenterScreen=�6a    � SizeToContent$ WidthAndHeight=�6D   � DataContext 6I   �� .��5      � $	��753��6   .+�5   
   �� -   5        $��BackGroundImage��5   �   $	��503��6   $
��Left=�6   $
��Fill=�68   $	��Top=�6G   $	��753��6_   $5��//BlackJackCTI;component/Images/GameStandard.jpg��6k   6�   �� 5   
   -   5        $��NotificationPannel��5   J   $��52��6   $
��Left=�6   $��	264,0,0,0q�67   $
��Fill=�6d   $	��Top=�6s   $	��252��6�   $@��:/BlackJackCTI;component/Images/Notifications%20pannel2.jpg��6�   �� 5   
   -   5        $��NotificationLabel��5   G   $��
BlackJack!��6   $��37��6%   $��246,15,235,0q�61   $	��Top=�6`   
�������$��Palatino Linotype)�6�   $��Normal"�6�   $��20(�6�   $��Center=�6�   $��Center=�6�   $��LeftToRight=�6  $��Italic$�6E   J� OpacityMask 6.  Z� 6Z  �� 5	   
   -   5        $��NewGameButton��5	   L   $��63��6   $
��Left=�6   $��292,130,0,0q�67   $
��Fill=�6a   $	��Top=�6p   $	��189��6�   $5��//BlackJackCTI;component/Images/NewMouseExit.jpg��6�   6=  �� 5
   
   -   5        $��
QuitButton��5
   L   $��63��6   $
��Left=�6   $��292,263,0,0q�67   $
��Fill=�6^   $	��Top=�6m   $	��189��6�   $6��0/BlackJackCTI;component/Images/QuitMouseExit.jpg��6�   62  �� 5   
   -   5        $��DealGrey��5   L   $��32��6   $
��Left=�6   $��314,433,0,0q�67   $
��Fill=�6\   $	��Top=�6k   $	��122��6�   $6��0/BlackJackCTI;component/Images/DealGreyedOut.jpg��6�   �� 5   
   -   5        $��
DealButton��5   L   $��32��6   $
��Left=�6   $��314,433,0,0q�67   $
��Fill=�6^   $	��Top=�6m   $	��122��6�   $3��-/BlackJackCTI;component/Images/DealNormal.jpg��6�   6/  �� 5   
   -	   5        $��HitGrey��5   L   $��32��6   $
��Left=�6   $��189,433,0,0q�67   $
��Fill=�6[   $	��Top=�6j   $	��126��6�   $5��//BlackJackCTI;component/Images/HitGreyedOut.jpg��6�   �� 5   
   -
   5        $��	HitButton��5   L   $��32��6   $
��Left=�6   $��189,433,0,0q�67   $
��Fill=�6]   $	��Top=�6l   $	��126��6�   $5��//BlackJackCTI;component/Images/HitGreyedOut.jpg��6�   6-  �� 5   
   -   5        $��StayGrey��5   L   $��32��6   $
��Left=�6   $��434,433,0,0q�67   $
��Fill=�6\   $	��Top=�6k   $	��126��6�   $6��0/BlackJackCTI;component/Images/StayGreyedOut.jpg��6�   �� 5   
   -   5        $��
StayButton��5   M   $��32��6   $��Right=�6   $��0,433,193,0q�68   $
��Fill=�6_   $	��Top=�6n   $	��126��6�   $6��0/BlackJackCTI;component/Images/StayGreyedOut.jpg��6�   63  �� 5   
   -   5        $��EndSessionButton��5   L   $��32��6   $
��Left=�6   $��314,465,0,0q�67   $
��Fill=�6d   $	��Top=�6s   $	��122��6�   $9��3/BlackJackCTI;component/Images/EndSessionNormal.jpg��6�   6I  �� 5   
   -   5        $��Card5��5   L   $	��123��6   $
��Left=�6   $��
1487,0,0,0q�68   $
��Fill=�6Y   $	��Top=�6h   $��79��6�   $1��+/BlackJackCTI;component/Images/CardBack.png��6�   �� 5   
   -   5        $��Card1��5   L   $	��123��6   $
��Left=�6   $��
1487,0,0,0q�68   $
��Fill=�6Y   $	��Top=�6h   $��79��6�   $1��+/BlackJackCTI;component/Images/CardBack.png��6�    6�   �� �� 5   
   -   5        $��Card2��5   L   $	��123��6   $
��Left=�6   $��
1487,0,0,0q�68   $
��Fill=�6Y   $	��Top=�6h   $��79��6�   $1��+/BlackJackCTI;component/Images/CardBack.png��6�   �� 5   
   -   5        $��PlayerTotalValueLabel��5   W   $��0��6   $��28��6   $
��Left=�6(   $��
79,465,0,0q�6C   $	��Top=�6t   
�������$��Palatino Linotype)�6�   $��16(�6�   �� 5   
   -   5        $��
LosesLabel��5   X   $��0��6   $��28��6   $
��Left=�6(   $��246,410,0,0q�6C   $	��Top=�6j   
�������$��Palatino Linotype)�6�   6�   �� 5   
   -   5        $��WinLabel��5   Y   $��0��6   $��28��6   $��Right=�6(   $��0,411,373,0q�6D   $	��Top=�6i   
�������$��Palatino Linotype)�6�   �� 5   
   -   5        $��TieLabel��5   Y   $��0��6   $��28��6   $��Right=�6(   $��0,411,256,0q�6D   $	��Top=�6i   
�������$��Palatino Linotype)�6�   �� 5   
   -   5        $��BankerTotalValueLabel��5   X   $��0��6   $��28��6   $��Right=�6(   $��
0,465,94,0q�6D   $	��Top=�6u   
�������$��Palatino Linotype)�6�   $��16(�6�   �� 5   
   -   5        $��Card3��5   L   $	��123��6   $
��Left=�6   $��
1487,0,0,0q�68   $
��Fill=�6Y   $	��Top=�6h   $��79��6�   $1��+/BlackJackCTI;component/Images/CardBack.png��6�   �� 5   
   -   5        $��Card4��5   L   $	��123��6   $
��Left=�6   $��
1487,0,0,0q�68   $
��Fill=�6Y   $	��Top=�6h   $��79��6�   $1��+/BlackJackCTI;component/Images/CardBack.png��6�   �� 5   
   -   5        $��PlayerPointerText��5   W   $	��↓��6   $��45��6   $
��Left=�6(   $��
79,387,0,0q�6C   $	��Top=�6p   $��28(�6�   $��26��6�   
�������6�   �� 5   
   -   5        $��BankerPointerText��5   3   $	��↓��6   $��633,387,94,71q�6   $��28(�6L   
�������6Z   �� 5   
   -   5        $��ContinueButton��5   L   $��43��6   $
��Left=�6   $��299,270,0,0q�67   $
��Fill=�6b   $	��Top=�6q   $	��169��6�   $<��6/BlackJackCTI;component/Images/ContinueHighLighted.jpg��6�   6#  �� 5   
   -   5        $��MusicButton��5   J   $��70��6   $
��Left=�6   $��	707,0,0,0q�67   $
��Fill=�6]   $	��Top=�6l   $��34��6�   $4��./BlackJackCTI;component/Images/MusicNoteOn.jpg��6�   6�   5       5!      