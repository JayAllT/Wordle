   M S B A M L   `   `   `  ����A  =Wordle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WordleWordle  5   	       Wordle.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Wordle     5   	     � Title$  Wordle��5   	   $	��500��6   $	��350��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��---- WORDLE ----��6   $��5��6+   $��Center=�6?   $��Center=�6\   $��25(�6w   $��Impact)�6�   �� 5   
   -   5         ��Name$ txt1_1��5      $��1��6"   $��0��6/   $��40(�6?   $�� ��6M    �� TextAlignment$ Center=�6U   $��5q�6l   6w   �� 5    
   -   5        $ txt2_1��5       $��2��6"   $��0��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5!   
   -   5        $ txt3_1��5!      $��3��6"   $��0��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5"   
   -   5        $ txt4_1��5"      $��4��6"   $��0��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5#   
   -   5        $ txt5_1��5#      $��5��6"   $��0��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5$   
   -   5        $ txt1_2��5$      $��1��6"   $��1��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5%   
   -   5        $ txt2_2��5%      $��2��6"   $��1��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5&   
   -   5        $ txt3_2��5&      $��3��6"   $��1��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5'   
   -	   5        $ txt4_2��5'      $��4��6"   $��1��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5(   
   -
   5        $ txt5_2��5(      $��5��6"   $��1��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5)   
   -   5        $ txt1_3��5)      $��1��6"   $��2��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5*   
   -   5        $ txt2_3��5*      $��2��6"   $��2��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5+   
   -   5        $ txt3_3��5+      $��3��6"   $��2��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5,   
   -   5        $ txt4_3��5,      $��4��6"   $��2��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5-   
   -   5        $ txt5_3��5-      $��5��6"   $��2��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5.   
   -   5        $ txt1_4��5.      $��1��6"   $��3��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 5/   
   -   5        $ txt2_4��5/      $��2��6"   $��3��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 50   
   -   5        $ txt3_4��50      $��3��6"   $��3��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 51   
   -   5        $ txt4_4��51      $��4��6"   $��3��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 52   
   -   5        $ txt5_4��52      $��5��6"   $��3��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6w   �� 53   
   -   5        $ txt1_5��53      $��1��6"   $��4��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6�   �� 54   
   -   5        $ txt2_5��54      $��2��6"   $��4��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6�   �� 55   
   -   5        $ txt3_5��55      $��3��6"   $��4��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6�   �� 56   
   -   5        $ txt4_5��56      $��4��6"   $��4��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6�   �� 57   
   -   5        $ txt5_5��57      $��5��6"   $��4��6/   $��40(�6?   $�� ��6M   $ Center=�6U   $��5q�6l   6�   �� 59   
   -   5         ��Name$ lblOut��59      $��6��6    $��5��6-   $��Center=�6A   $��Center=�6^   $��24(�6y   �� 5:   
   -   5         ��Name$ 	btnReplay��5:      {�.  $��New Word��66   $��7��6I   $��5��6V   $��Center=�6j   $��Center=�6�   $	��250��6�   $��35��6�   $��16(�6�   6�   5;      5<      