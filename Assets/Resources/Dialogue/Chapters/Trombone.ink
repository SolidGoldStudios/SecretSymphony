==trombonequest_uncle==
{
    - has_trombone_quest:
        You have the trombone quest! Woohoo! I need dialog! #name:Uncle
        ->END
    - else:
        This dang carriage! I need dialog! Talk to my horse to get the quest! #name:Uncle 
        ~ has_trombone_quest = true
        ->END
        
}

==trombonequest_horse==
{
    - has_trombone_quest:
        Good morning, Melody! #name:Horse
        Good morning, Horse! #name:Melody #mood:happy
        ...wait a minute. You can talk? #name:Melody #mood:skeptical
        Of course I can. Say, could you do me a favor? #name:Horse
        What do you need me to do? #name:Melody #mood:concerned
        Can you help your Uncle remember this tune? ... #name:Horse #audio:horse_hotcrossbuns
        I remember that! It's... Hot Cross Buns, of course! #name:Melody #mood:happy
        Yep! Uncle used to play it on his trombone all the time. #name:Horse
        Now he seems to think his trombone is a wheel spoke. Silly human... #name:horse
        I can try to help. What should I do? #name:Melody #mood:concerned
        Maybe if you play the melody for him, he'll remember! Try it! #name:Horse #play:piano|Hot+Cross+Buns|EDCEDCCCCCDDDDEDC|hot_cross_buns|trombonequest_played_song
        ->END
    - else:
        Neigh! #name:Horse #audio_horseneigh
        ->END
        
}

==trombonequest_played_song==
    That... that tune! #name:Uncle
    Do you remember it? #name:Melody
    Is it... Hot Cross Buns?  #name:Uncle
    Yes! #name:Melody #mood:happy
    And this this... it's not a wheel spoke. It's my trombone! #name:Uncle #mood:happy
    It sure is. By the way, can I please borrow it? I have to go collect all the rest of the instruments of the orchestra! #name:Melody #mood:happy
    Of course. But first, you should learn some basic facts about the trombone.  #name:Uncle
    ->trombonequest_trivia

==trombonequest_trivia==
    TRIVIA!! #name:Goat #trivia:Uncle,trombone,trombonequest_trivia_success,trombonequest_trivia_fail
    ->trombonequest_trivia_success


==trombonequest_trivia_success==
    Congratulations! Here's the trombone. #name:Uncle #item:Trombone
    -> END
    
==trombonetriviatryagain
    Woops! Try again. #name:Uncle
    ->trombonequest_trivia