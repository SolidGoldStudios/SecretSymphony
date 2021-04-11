==flutequest_professor==
    Good morning, Professor. #name:Melody
    {
    - !has_flute_quest && ready_for_flute_quest:
        What's that? #name:Melody #mood:thinking
        ~ has_flute_quest = true
        What, my pointy-thing? #name:Professor+Oze #audio:male_speak_short_1
        Yes, your pointy thing. #name:Melody
        It's a cool new baton I found. It's for pointing at chalkboards. #name:Professor+Oze #mood:happy #audio:male_speak_medium_2
        That's not for pointing at chalkboards! That's a flute! #name:Melody #mood:happy
        A flute? What's a flute? #name:Professor+Oze #audio:male_speak_short_2 #mood:sad
        ->flutequest_trivia
    - has_flute_quest && !completed_flute_quest:
        Are you here to try my trivia again? #name:Professor+Oze #mood:happy #audio:male_speak_short_2
        ->flutequest_trivia
    - else:
        Good morning, Melody! #name:Professor+Oze #audio:male_speak_short_2
        ->END
    }
    -> END

==flutequest_trivia==
    TRIVIA!! #name:Goat #trivia:Professor+Oze,flute,flutequest_trivia_success,flutequest_trivia_fail
    ->flutequest_trivia_success

==flutequest_trivia_success==
    Fascinating! I still don't entirely understand, but thank you for teaching me! #name:Professor+Oze #mood:happy #audio:male_speak_medium_1
    You're welcome! #name:Melody #mood:happy
    Now that you know it's a flute, can I borrow it? #name:Melody
    Of course you can, Melody. #name:Professor+Oze #item:Flute #audio:male_speak_short_2
    ~ tooltip = "You saved the flute!"
    ~ completed_flute_quest = true
    Thanks! Bye! #name:Melody #mood:happy
    -> END
    
==flutequest_trivia_fail==
    Hmm, I'm still not convinced, Melody! Try again? #name:Professor+Oze #mood:sad #audio:male_speak_medium_1
    + [Yes] Let's do it! #name:Melody #mood:happy
        -> flutequest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking
        -> END
    ->flutequest_trivia