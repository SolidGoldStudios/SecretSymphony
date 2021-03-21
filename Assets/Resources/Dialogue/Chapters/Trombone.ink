==trombonequest_uncle==
{
    - completed_trombone_quest:
        Quick, kid! The fuzz is hot on my tail! #name:Uncle #mood:mad  #audio:male_speak_short_1
        Get in the carriage if you want to live! #name:Uncle #mood:mad   #audio:male_speak_short_1 #scene:FarmToTownCutscene|8.6,-25.9|15.8,-24.1,-2.2|0,-1
        ->END
    - has_trombone_quest && has_played_trombone_song && !completed_trombone_quest:
        Are you here to try my trivia again? #name:Uncle   #audio:male_speak_short_1
        ->trombonequest_trivia
    - else:
        This dang carriage wheel! Why won't this spoke fit? #name:Uncle   #audio:male_speak_short_2
        ->END
        
}

==trombonequest_horse==
{
    - !has_trombone_quest && ready_for_trombone_quest:
        Good morning, Melody! #name:Horace #audio:horsesound
        Good morning, Horace! #name:Melody #mood:happy   #audio:female_speak_short_1
        ...wait a minute. You can talk? #name:Melody #mood:skeptical #audio:female_speak_short_2
        Of course I can. Say, could you do me a favor? #name:Horace
        What do you need me to do? #name:Melody #mood:concerned #audio:female_speak_short_1
        Can you help your Uncle remember this tune? ... #name:Horace #audio:horse_hot_cross_buns #audio:quest_added
        ~ tooltip = "Added to Quest Log!"
        ~ has_trombone_quest = true
        I remember that! It's... Hot Cross Buns, of course! #name:Melody #mood:happy #audio:female_speak_medium_1
        Yep! Uncle used to play it on his trombone all the time. #name:Horace
        Now he seems to think his trombone is a wheel spoke. Silly human... #name:Horace
        I can try to help. What should I do? #name:Melody #mood:concerned #audio:female_speak_medium_2
        Maybe if you play the melody for him, he'll remember! Try it! #name:Horace #play:piano|Hot+Cross+Buns|CCCCDDDDEDC|song_hot_cross_buns|trombonequest_played_song
        ->END
    - else:
        Neigh! #name:Horace #audio:horsesound
        ->END
        
        
}

==trombonequest_played_song==
    That... that tune! #name:Uncle #audio:male_speak_short_2
    ~ has_played_trombone_song = true
    Do you remember it? #name:Melody #audio:female_speak_short_1
    Is it... Hot Cross Buns?  #name:Uncle #audio:male_speak_short_1
    Yes! #name:Melody #mood:happy #audio:female_speak_short_1
    And this this... it's not a wheel spoke. It's my trombone! #name:Uncle #mood:happy #audio:male_speak_long_1
    It sure is. By the way, can I please borrow it? I have to go collect all the rest of the instruments of the orchestra! #name:Melody #mood:happy #audio:female_speak_long_1
    Of course. But first, you should learn some basic facts about the trombone.  #name:Uncle #audio:male_speak_medium_1
    ->trombonequest_trivia

==trombonequest_trivia==
    TRIVIA!! #name:Goat #trivia:Uncle,trombone,trombonequest_trivia_success,trombonequest_trivia_fail
    ->trombonequest_trivia_success


==trombonequest_trivia_success==
    Congratulations! Here's the trombone. #name:Uncle #item:Trombone #audio:male_speak_medium_2
    ~ tooltip = "You saved the trombone!"
    ~ completed_trombone_quest = true
    -> END
    
==trombonequest_trivia_fail==
    Whoops! Would you like to try again? #name:Uncle #audio:male_speak_short_1
    + [Yes] Let's do it! #name:Melody #mood:happy #audio:female_speak_short_1
        -> trombonequest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking #audio:female_speak_short_2
        -> END
    ->trombonequest_trivia