==trombonequest_uncle==
{
    - completed_trombone_quest && completed_piano_quest && completed_trumpet_quest:
        Are you looking for more instruments to save? #name:Uncle #audio:male_speak_short_1
        We sure are! #name:Melody #mood:happy
        I bet there are more in town! Hop in, I'll give you a ride! #name:Uncle #mood:happy #audio:male_speak_medium_2 #timeline:ToTownTimeline
        ->END
    - completed_trombone_quest && completed_piano_quest && !completed_trumpet_quest:
        I can't believe the Ear Worm tried to steal our memories of music! #name:Uncle #mood:mad #audio:male_speak_long_1
        If you want to fight him, you'll need more musical power! #name:Uncle #audio:male_speak_medium_1
        I think there's one more instrument on this farm... #name:Melody
        Let's find it! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1
    - has_trombone_quest && has_played_trombone_song && !completed_trombone_quest:
        Are you here to try my trivia again? #name:Uncle   #audio:male_speak_short_1
        ->trombonequest_trivia
    - else:
        This dang carriage wheel! Why won't this spoke fit? #name:Uncle #audio:male_speak_short_2
        ->END
}

==trombonequest_horse==
{
    - !has_trombone_quest && ready_for_trombone_quest:
        Good morning, Melody! #name:Horace #audio:horsesound
        Good morning, Horace! #name:Melody #mood:happy
        ...wait a minute. You can talk? #name:Melody #mood:skeptical
        Of course I can. Say, could you do me a favor? #name:Horace
        What do you need me to do? #name:Melody #mood:concerned
        Can you help your Uncle remember this tune? ... #name:Horace #audio:horse_hot_cross_buns
        ~ has_trombone_quest = true
        I remember that! It's... Hot Cross Buns, of course! #name:Melody #mood:happy
        Yep! Uncle used to play it on his trombone all the time. #name:Horace
        Now he seems to think his trombone is a wheel spoke. Silly human... #name:Horace
        I can try to help. What should I do? #name:Melody #mood:concerned
        Maybe if you play the melody for him, he'll remember! Try it! #name:Horace #play:piano|Hot+Cross+Buns|CCCCDDDDEDC|song_hot_cross_buns|trombonequest_played_song
        ->END
    - else:
        Neigh! #name:Horace #audio:horsesound
        ->END
        
        
}

==trombonequest_played_song==
    That... that tune! #name:Uncle #audio:male_speak_short_2
    ~ has_played_trombone_song = true
    Do you remember it? #name:Melody
    Is it... Hot Cross Buns?  #name:Uncle #audio:male_speak_short_1
    Yes! #name:Melody #mood:happy
    And this this... it's not a wheel spoke. It's my trombone! #name:Uncle #mood:happy #audio:male_speak_long_1
    It sure is. By the way, can I please borrow it? I have to go collect all the rest of the instruments of the orchestra! #name:Melody #mood:happy
    Of course. But first, you should learn some basic facts about the trombone.  #name:Uncle #audio:male_speak_medium_1
    ->trombonequest_trivia

==trombonequest_trivia==
    TRIVIA!! #name:Goat #trivia:Uncle,trombone,trombonequest_trivia_success,trombonequest_trivia_fail
    ->trombonequest_trivia_success


==trombonequest_trivia_success==
    Congratulations! Here's the trombone. #name:Uncle #audio:male_speak_medium_2 #victory:scroll-instruments_trombone
    ~ tooltip = "You saved the trombone!"
    ~ has_trombone = true
    ~ completed_trombone_quest = true
    -> END
    
==trombonequest_trivia_fail==
    Whoops! Would you like to try again? #name:Uncle #audio:male_speak_short_1
    + [Yes] Let's do it! #name:Melody #mood:happy
        -> trombonequest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking
        -> END
    ->trombonequest_trivia
    
    

