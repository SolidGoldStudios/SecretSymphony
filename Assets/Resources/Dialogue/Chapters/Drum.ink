==drumquest_blacksmith==

 {
    - !has_drum_quest && ready_for_drum_quest:
        Whew... toasty in here! #name:Blacksmith+Whitney #mood:happy #audio:male_speak_short_1
        ~ has_drum_quest = true
        How are you, Blacksmith? #name:Melody #mood:happy
        Tired! What can I help you with? #name:Blacksmith+Whitney #audio:male_speak_medium_2
        What's that? #name:Melody 
        That? It's a new table someone was nice enough to leave me. #name:Blacksmith+Whitney #mood:happy #audio:male_speak_long_2
        A table? It looks like a bass drum. #name:Melody #mood:skeptical
        What's a bass drum? Let's see what you know. #name:Blacksmith+Whitney #mood:sad #audio:male_speak_medium_1
        ->drumquest_trivia
     
    - has_drum_quest && !completed_drum_quest:
        My table's loud. #name:Blacksmith+Whitney #audio:male_speak_short_1
        That's because it's a bass drum! #name:Melody #mood:happy
        Tell me more! #name:Blacksmith+Whitney #audio:male_speak_short_2
        ->drumquest_trivia
        
    - else:
        Somethin' need mending? #name:Blacksmith+Whitney #audio:male_speak_short_2
        ->END
}

==drumquest_trivia==
    TRIVIA!! #name:Goat #trivia:Blacksmith+Whitney,drum,drumquest_trivia_success,drumquest_trivia_fail
    ->drumquest_trivia_success
    
==drumquest_trivia_success==
    YAY AWESOME I NEED DIALOG #name:Blacksmith+Whitney #mood:happy #audio:male_speak_medium_1
    You're welcome! Now gimme that drum! #name:Melody #mood:happy
    Okay! Please don't hurt me, you maniac! #name:Blacksmith+Whitney #audio:male_speak_medium_2 :victory
    ~ tooltip = "You saved the bass drum!"
    ~ completed_drum_quest = true
    Thanks! Bye! #name:Melody #mood:happy
    -> END
    
==drumquest_trivia_fail==
    YOU FAILED AND I NEED DIALOG, TRY AGAIN #name:Blacksmith+Whitney #mood:sad #audio:male_speak_medium_1
    + [Yes] Let's do it! #name:Melody #mood:happy
        -> drumquest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking
        -> END
    ->drumquest_trivia
    
    