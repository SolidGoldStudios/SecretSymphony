==pianoquest_father==
{
    - !has_piano_quest:
        Good morning, Melody! #name:Father #mood:happy #audio:male_speak_short_1
        Good morning, father! #name:Melody #mood:happy 
        How are you? #name:Melody 
        I feel kind of strange today, can't quite put my finger on it. #name:Father #mood:sad #audio:male_speak_long_1
        ->END
    - has_piano_quest && !has_scythe:
        The <b>scythe</b> is just outside the house. #name:Father #audio:male_speak_short_1
        ->END
    - has_piano_quest && has_scythe && !completed_piano_quest:
        Good, you found the scythe! Give this big lumber pile a whack. #name:Father #mood:happy #audio:male_speak_long_1
        ->END
    - completed_piano_quest && !has_cow_quest:
        Melody, would you mind checking on the cows? #name:Father #audio:male_speak_medium_1
        ->END
    - completed_piano_quest && has_cow_quest && !completed_cow_quest:
        Did you check on the cows? #name:Father #audio:male_speak_short_1
        ->END
    - else: 
        Looks like it'll be a sunny one today. #name:Father #mood:happy #audio:male_speak_short_2
        ->END
        
}
        
==pianoquest_mother==
{
    - has_piano_quest && !completed_piano_quest:
        Please do something about this unsightly lump of lumber! #name:Mother #mood:sad #audio:female_speak_medium_2
        ->END
    - ready_for_piano_quest && !has_piano_quest:
        Ready for your morning chores, Melody? #name:Mother # mood:happy #audio:female_speak_short_2
        Oh, as ready as I'll ever be! What's first? #name:Melody 
        We found this big pile of firewood in the living room. #name:Father  #audio:male_speak_long_1
        But it's all stuck together. Can you chop it into smaller pieces? #name:Mother #mood:sad  #audio:female_speak_long_2
        I'll get to it. #name:Melody #mood:happy 
        Thanks, Melody! You can just use the <b>scythe</b>. #name:Father #mood:happy #audio:male_speak_medium_1 #quest:InstrumentPianoPartOne #audio:quest_added
        ~ has_piano_quest = true
        ->END
    - completed_piano_quest && !has_trombone_quest:
       Uncle is still trying to fix his carriage. I'm sure he would appreciate some help... #name:Mother #audio:female_speak_long_2
        Sure! #name:Melody #mood:happy 
        ->END
    - completed_piano_quest && has_trombone_quest && !completed_trombone_quest:
        Did you speak to your uncle? #name:Mother  #audio:female_speak_short_1
        ->END
    - else:
        Thanks for doing your chores, Melody! #name:Mother #mood:happy  #audio:female_speak_short_2
        ->END 
}

==pianoquest_brother==
{
    - has_piano_quest && !completed_piano_quest:
        Aww, Father let you use the scythe? #name:Thomas #mood:sad  #audio:female_speak_medium_1
        ->END
    - completed_piano_quest && !has_fishing_quest:
        Could you catch a trumpetfish from the pond? Let's have fish for dinner tonight! #name:Thomas #mood:happy  #audio:female_speak_long_2
        ->END
    - completed_piano_quest && has_fishing_quest && !completed_fishing_quest:
        Well? Did you get the trumpetfish? #name:Thomas #mood:sad  #audio:female_speak_short_1
        ->END
    - else:
        Hey Sis... I feel like there's something important that I'm forgetting to do... #name:Thomas #mood_sad  #audio:female_speak_long_2
        ->END
}

==pianoquest_piano==
{
    - has_piano_quest && !has_scythe:
        This looks pretty weird for a "pile of lumber." And why does it have a keyhole? #name:Melody #mood:thinking  
        ->END
        
    - has_scythe && !has_spoken_to_spirit_piano:
        Stop! Wait! #name:Spirit+of+Music #mood:sad #audio:fairy_speak_short_1 #showSparkles #timeline:FairyEntersTimeline
        Who's that? #name:Melody #mood:concerned 
        I'm the Spirit of Music. Whatever you do, don't hurt that piano! #name:Spirit+of+Music #mood:sad #audio:fairy_speak_medium_1
        ~ has_hit_piano = true
        ~ has_spoken_to_spirit_piano = true
        Don't hurt what? This kindling? #name:Melody 
        That's no kindling. It's a piano! A piano is a musical instrument. #name:Spirit+of+Music #mood:right #audio:fairy_speak_long_1
        Musical instrument? What's that? #name:Melody #mood:concerned  
        Oh no! It seems the Ear Worm has erased your memory too. /*crying sound and animation?*/ #name:Spirit+of+Music #mood: #mood:cry #audio:fairy_speak_medium_2
        Don't cry. I won't hurt this piano if it means that much to you. #name:Melody #mood:sad
        Oh, thank you! Can you help me save the rest of the musical instruments? #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_1
        Yes! Let's do it. #name:Melody #mood:happy  
        Great! Hooray! The lid of the piano is closed and locked right now. #name:Spirit+of+Music #mood:right  #audio:fairy_speak_medium_2
        I was going to open it up, but I dropped the key in your wheat field. #name:Spirit+of+Music #mood:left #audio:fairy_speak_medium_1
        Will you find it? #name:Spirit+of+Music #mood:sad #audio:fairy_speak_short_2
        Here goes nothing! #name:Melody #mood:happy #hideSparkles  
        ->END
        
    - has_spoken_to_spirit_piano && !has_piano_key:
        Well? Did you get the key? #name:Spirit+of+Music #audio:fairy_speak_short_1 #showSparkles
        ->END
         
    - has_piano_key && !has_played_piano:
        You did it! You got the key! I knew you could do it! #name:Spirit+of+Music #mood:happy #showSparkles #audio:fairy_speak_medium_1
        Let me just try this key in the lock... Done! #name:Melody #audio:piano_lid  
        Play "Ode to Joy!" You'll see the notes on the screen. That's your dad's favorite tune!  #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_2 #play:piano|Ode+To+Joy|EEFGGFED|ode_to_joy|pianoquest_played_song
        ->END
    
    - completed_piano_quest:
        Let's play the piano! #name:Melody #mood:happy  
        ->END
        
    - else:
        What is this big wooden thing in my house? #name:Melody #mood:neutral  
    ->END
}

==pianoquest_scythe==
I finally get to use the scythe! Father never let me because it's sharp. #name:Melody #mood:happy
I had better see if I can use it on that pile of kindling in the house. #name:Melody #scene:LivingRoom|-5.9,-15.48|-4.6,-11.68,-10|0,1 
~ has_scythe = true
->END

==pianoquest_scarecrow==
    Ha-ha! #name:Scarecrow  #audio:scarecrow_speak_short_1
    Who said that? #name:Melody #mood:sad  
    Me! The scarecrow! Looking for something? #name:scarecrow #audio:scarecrow_speak_long_1
    My key! #name:Melody #mood:sad  
    If you want it back, you'll have to answer my questions! Are you ready? #name:Scarecrow #audio:scarecrow_speak_long_2
    + [Yes] Let's do it! #name:Melody #mood:happy 
        -> pianoquest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking 
        -> END
        
==pianoquest_trivia==
    TRIVIA!! #name:Goat #trivia:Scarecrow,piano,pianoquest_trivia_success,pianoquest_trivia_fail
    ->pianoquest_trivia_success


==pianoquest_trivia_success==
Good work! You passed. Here you go. #name:Scarecrow #item:Piano+Key #audio:scarecrow_speak_medium_1
~ has_piano_key = true
~ tooltip = "Got the piano key!"
Hooray! Thanks, scarecrow! #name:Melody #mood:happy  
I should go back to the house and try this on that "piano" thing. #name:Melody #mood:thinking #scene:LivingRoom|-5.9,-15.48|-4.6,-11.68,-10|0,1  
->DONE

==pianoquest_trivia_fail==
    Not quite. Want to try again? #name:Scarecrow #audio:scarecrow_speak_medium_2
    + [Yes] Let's do it! #name:Melody #mood:happy  
        -> pianoquest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking   
        -> END
->DONE

==pianoquest_played_song==
    Beautiful! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1
    I... I remember that sound! That was <i>Ode to Joy!</i> #name:Father #mood:happy #audio:male_speak_medium_1
    Yes! And this is a piano, not firewood. #name:Melody #mood:happy 
    I can't believe I forgot! I must have been out of my mind. Hooray! #name:Father #mood:happy #audio:male_speak_medium_2
    Hooray! We saved the piano! #name:Melody #mood:happy 
    We sure did. Nice work, Melody. But there's still a lot of work left to do! #name:Spirit+of+Music #audio:fairy_speak_long_2 
    Will you find the rest of the musical instruments and save them? #name:Spirit+of+Music #mood:left #audio:fairy_speak_medium_1 
    You can count on me! #name:Melody #mood:happy #audio:quest_added #hideSparkles #victory
    ~ tooltip = "You saved the piano!"
    ~ completed_piano_quest = true
    ~ ready_for_trombone_quest = true
    /*on completion, cue the following text with "victory" animation: "Contratulations! You got the keyboard instruments: piano, and celeste!"*/
-> DONE


