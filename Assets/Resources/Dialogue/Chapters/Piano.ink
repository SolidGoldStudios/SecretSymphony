==pianoquest_father==
{
    - has_piano_quest && !has_scythe:
        The <b>scythe</b> is outside by the barn. #name:Father
        ->END
    - has_piano_quest && has_scythe && !piano_complete:
        Good, you found the scythe! Give this big lumber pile a whack. #name:Father #mood:happy
        ->END
    - piano_complete && !has_trombone_quest:
        Melody, Uncle is out in the yard trying to fix his carriage. Could you go and see if he needs help? #name:Father #mood:happy
        You bet! #name:Melody #mood:happy
        ->END
    - piano_complete && has_trombone_quest && !trombone_complete:
        Did you help your uncle? #name:Father
        ->END
    - else:
        Good morning, Melody! #name:Father #mood:happy
        Good morning, father! #name:Melody #mood:happy
        How are you? #name:Melody
        Very well. #name:Father
        ->END
        
}
        
==pianoquest_mother==
{
    - has_piano_quest && !piano_complete:
        Please do something about this unsightly lump of lumber! #name:Mother #mood:sad
        ->END
    - !has_piano_quest:
        Ready for your morning chores, Melody? #name:Mother # mood:happy
        Oh, as ready as I'll ever be! What's first? #name:Melody 
        We found this big pile of firewood in the living room. #name:Father
        But it's all stuck together. Can you chop it into smaller pieces? #name:Mother #mood:sad
        I'll get to it. #name:Melody #mood:happy
        Thanks, Melody! You can just use the <b>scythe</b>. #name:Father #mood:happy #quest:InstrumentPianoPartOne #audio:quest_added
        ~ tooltip = "Added to Quest Log!"
        ~ has_piano_quest = true
        ->END
    - piano_complete && !has_cow_quest:
        Melody, could you check on the cows? #name:Mother
        They're acting funny when I speak to them... #name:Mother #mood:sad
        Sure! #name:Melody #mood:happy
        ->END
    - piano_complete && has_cow_quest && !cow_complete:
        Did you visit the cows? #name:Mother
        ->END
    - else:
        Listen to the lovely sounds of the farm! #name:Mother #mood:happy
        ->END
}

==pianoquest_brother==
{
    - has_piano_quest && !piano_complete:
        Aww, Father let you use the scythe? #name:Thomas #mood:sad
        ->END
    - piano_complete && !has_fishing_quest:
        I was going to go down to the pond to fish, but I heard scary noises! #name:Thomas #mood:sad
        ->END
    - piano_complete && has_fishing_quest && !fishing_complete:
        I'm too scared to go fishing at the pond! #name:Thomas #mood:sad
        ->END
    - else:
        Are you doing chores today? I'm not! #name:Thomas #mood:happy
        ->END
}

==pianoquest_piano==
{
    - has_piano_quest && !has_scythe:
        This looks pretty weird for a "pile of lumber." And why does it have a keyhole? #name:Melody #mood:thinking
        ->END
        
    - has_scythe && !has_spoken_to_spirit_piano:
        Stop! Wait! #name:Spirit+of+Music #mood:sad #audio:fairy_speak_short_1
        Who's that? #name:Melody #mood:concerned
        I'm the Spirit of Music. Whatever you do, don't hurt that piano! #name:Spirit+of+Music #mood:sad #audio:fairy_speak_medium_1
        ~ has_hit_piano = true
        ~ has_spoken_to_spirit_piano = true
        Don't hurt what? This kindling? #name:Melody
        That's no kindling. It's a piano! A piano is a musical instrument. #name:Spirit+of+Music #mood:right #audio:fairy_speak_long_1
        Musical instrument? What's that? #name:Melody #mood:concerned
        Oh no! It seems the Ear Worm has erased your memory too. /*crying sound and animation?*/ #name:Spirit+of+Music #mood: #mood:sad #audio:fairy_speak_medium_2
        Don't cry. I won't hurt this piano if it means that much to you. #name:Melody #mood:sad
        Oh, thank you! Can you help me save the rest of the musical instruments? #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_1
        Yes! Let's do it. #name:Melody #mood:happy
        Great! Hooray! The lid of the piano is closed and locked right now. #name:Spirit+of+Music #mood:right  #audio:fairy_speak_medium_2
        I was going to open it up, but I dropped the key in your wheat field. #name:Spirit+of+Music #mood:left #audio:fairy_speak_medium_1
        Will you find it? #name:Spirit+of+Music #mood:sad #audio:fairy_speak_short_2
        Here goes nothing! #name:Melody #mood:happy
        ->END
        
    - has_spoken_to_spirit_piano && !has_piano_key:
        Well? Did you get the key? #name:Spirit+of+Music #audio:fairy_speak_short_1
        ->END
         
    - has_piano_key && !has_played_piano:
        You did it! You got the key! I knew you could do it! #name:Spirit+of+Music #mood:happy
        Let me just try this key in the lock... Done! #name:Melody #audio:piano_lid
        Play "Ode to Joy!" You'll see the notes on the screen. That's your dad's favorite tune!  #name:Spirit+of+Music #mood:happy #play:piano|Ode+To+Joy|EEFGGFED|ode_to_joy|pianoquest_played_song
        ->END
    
    - piano_complete:
        Let's play the piano! #name:Melody #mood:happy
        ->END
        
    - else:
        What is this big wooden thing in my house? #name:Melody #mood:neutral
    ->END
}

==pianoquest_scythe==
I finally get to use the scythe! Father never let me because it's sharp. #name:Melody #mood:happy
I had better see if I can use it on that pile of kindling in the house. #name:Melody
~ has_scythe = true
->END

==pianoquest_scarecrow==
    Ha-ha! #name:Scarecrow
    Who said that? #name:Melody #mood:sad 
    Me! The scarecrow! Looking for something? #name:scarecrow
    My key! #name:Melody #mood:sad 
    If you want it back, you'll have to answer my questions! Are you ready? #name:Scarecrow
    + [Yes] Let's do it! #name:Melody #mood:happy
        -> pianoquest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking
        -> END
        
==pianoquest_trivia==
    TRIVIA!! #name:Goat #trivia:Scarecrow,piano,pianoquest_trivia_success,pianoquest_trivia_fail
    ->pianoquest_trivia_success


==pianoquest_trivia_success==
Good work! You passed. Here you go. #name:Scarecrow #item:Piano+Key
~ has_piano_key = true
~ tooltip = "Got the piano key!"
Hooray! Thanks, scarecrow! #name:Melody #mood:happy
I should go back to the house and try this on that "piano" thing. #name:Melody #mood:thinking
->DONE

==pianoquest_trivia_fail==
    Not quite. Want to try again? #name:Scarecrow
    + [Yes] Let's do it! #name:Melody #mood:happy
        -> pianoquest_trivia
    + [No] I need more time to study. #name:Melody #mood:thinking
        -> END
->DONE

==pianoquest_played_song==
    Beautiful! #name:Spirit+of+Music #mood:happy 
    I... I remember that sound! That was <i>Ode to Joy!</i> #name:Father #mood:happy
    Yes! And this is a piano, not firewood. #name:Melody #mood:happy
    I can't believe I forgot! I must have been out of my mind. Hooray! #name:Father #mood:happy
    Hooray! We saved the piano! #name:Melody #mood:happy
    We sure did. Nice work, Melody. But there's still a lot of work left to do! Will you find the rest of the musical instruments and save them? #name:Spirit+of+Music 
    You can count on me! #name:Melody #mood:happy #audio:quest_added
    ~ tooltip = "Quest completed!"
    ~ piano_complete = true
    /*on completion, cue the following text with "victory" animation: "Contratulations! You got the keyboard instruments: piano, and celeste!"*/
-> DONE

==pianoquest_book==
    What's that? Hmm.... #name:Melody #mood:concerned
    "<b><i>All About Pianos!</i></b> by Clara Schumann." #name:Book #mood:piano #book:piano
    This book is missing some pages. Maybe I can find them nearby. #name:Melody #mood:neutral
->DONE
