   M S B A M L   `   `   `  ����Q  Mwpf discord connection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:wpf_discord_connectionwpf_discord_connection  5   	   '    !wpf_discord_connection.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:wpf_discord_connection     5   	     � Title$  
MainWindow��5   	   $	��450��6   $��946.939��6)   .��5	      � .+�5
   
   �� $��Webhook URLs��6   $
��Left=�6'   $��26��6B   $��	10,72,0,0q�6N   $	��Top=�6a   $	��134��6y   �� 5   
   -   5         ��Name$ Username��5      $
��Left=�6$   $��23��6?   $��	10,41,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $��Random Bot name��6r   $	��Top=�6�   $	��167��6�   �� 5   
   $��Username��6   $
��Left=�6#   $��26��6>   $��	10,10,0,0q�6J   $	��Top=�6]   $	��110��6u   �� 5   
   $��Embed image URLs��6   $
��Left=�6,   $��29��6G   $��
192,69,0,0q�6S   $	��Top=�6g   $	��180��6   �� 5   
   $��Chat message��6   $
��Left=�6'   $��26��6B   $��
390,10,0,0q�6N   $	��Top=�6b   $	��134��6z   �� 5   
   -   5        $ ChatMessage��5   8    �� 	MaxLength$
 2000��6    �� AcceptsReturn . $
��Left=�6N   $	��272��6i   $��
390,41,0,0q�6v   $
 Wrap=�6�   $��What a wonderful day��6�   $	��Top=�6�   $	��533��6�   �� 5   
   -   5        $��Send to Webhooks��5   &   $
��Left=�6A   $��43��6\   $��526,356,0,0q�6h   $	��Top=�6}   $	��271��6�   �� 5   
   -   5         ��Name$ ImageBox��5      $
��Left=�6$   $	��210��6?   $��192,103,0,0q�6L   $	��Top=�6a   $	��180��6y   �� 5   
   -   5        $ 
WebhookBox��5      $
��Left=�6&   $	��210��6A   $��
10,103,0,0q�6N   $	��Top=�6b   $	��167��6z   �� 5   
   -   5        $ webhookName��5      $
��Left=�6'   $��23��6B   $��
10,327,0,0q�6N   $
 Wrap=�6b   $
��Name��6v   $	��Top=�6�   $	��167��6�   �� 5   
   -   5        $ 
webhookUrl��5      $
��Left=�6&   $��23��6A   $��
10,355,0,0q�6M   $
 Wrap=�6a   $	��URL��6u   $	��Top=�6�   $	��167��6�   �� 5   
   -   5        $��Add webhook��5   %   $
��Left=�6;   $��28��6V   $��
10,383,0,0q�6b   $	��Top=�6v   $	��167��6�   �� 5   
   -	   5        $ 	ImageName��5      $
��Left=�6%   $��23��6@   $��192,327,0,0q�6L   $
 Wrap=�6a   $
��Name��6u   $	��Top=�6�   $	��180��6�   �� 5   
   -
   5        $ ImageUrl��5      $
��Left=�6$   $��23��6?   $��192,355,0,0q�6K   $
 Wrap=�6`   $	��URL��6t   $	��Top=�6   $	��180��6�   �� 5   
   -   5        $��	Add Image��5   #   $
��Left=�67   $��28��6R   $��192,383,0,0q�6^   $	��Top=�6s   $	��180��6�   �� 5   
   -   5        $ BotImage��5      $
��Left=�6$   $��23��6?   $��
192,41,0,0q�6K   $
 Wrap=�6_   $��Bot image URL��6s   $	��Top=�6�   $	��167��6�   �� 5   
   $��	Bot photo��6   $
��Left=�6$   $��26��6?   $��
192,10,0,0q�6K   $	��Top=�6_   $	��110��6w   5      5      