==pianoquest_father==
{
    - has_piano_quest && !has_scythe:
        The <b>scythe</b> is outside by the barn. #name:Father
        ->END
    - has_piano_quest && has_scythe:
        Good, you found it! Give this big lumber pile a whack. #name:Father #mood:happy
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
    - has_piano_quest:
        Please do something about this unsightly lump of lumber! #name:Mother # mood:sad
        ->END
    - else:
        Ready for your morning chores, Melody? #name:Mother # mood:happy
        Oh, as ready as I'll ever be! What's first? #name:Melody 
        We found this big pile of firewood in the living room. #name:Father
        But it's all stuck together. Can you chop it into smaller pieces? #name:Mother #mood:sad
        I'll get to it. #name:Melody #mood:happy
        Thanks, Melody! You can just use the <b>scythe</b>. #name:Father #mood:happy #quest:InstrumentPiano
        ~ tooltip = "Added to Quest Log!"
        ->END
}

==pianoquest_brother==
{
    - has_piano_quest:
        Aww, Father let you use the scythe? #name:Thomas #mood:sad
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
        I'm the Spirit of Music. Whatever you do, don't hurt that piano! #name:Spirit+of+Music #mood:sad
        ~ has_hit_piano = true
        ~ has_spoken_to_spirit_piano = true
        A piano? What's a piano? #name:Melody #mood:neutral
        A piano is a musical instrument. #name:Spirit+of+Music
        Musical instrument? What's that? #name:Melody #mood:concerned
        The Ear Worm has erased your memory too! /*crying sound and animation?*/ #name:Spirit+of+Music #mood: #mood:sad
        Don't cry. I won't hurt this piano if it means that much to you. #name:Melody #mood:sad
        Oh, thank you! Can you help me save the rest of the musical instruments? #name:Spirit+of+Music #mood:happy
        Okay! I'll do it! #name:Melody #mood:happy
        Great! Hooray! The lid of the piano is closed and locked right now. #name:Spirit+of+Music #mood:right
        I was going to open it up, but I dropped the key in your wheat field. Will you find it? #name:Spirit+of+Music #mood:left
        Here goes nothing! #name:Melody #mood:happy
        ->END
        
    - has_spoken_to_spirit_piano && !has_piano_key:
        Well? Did you get the key? #name:Spirit+of+Music
        ->END
         
    - has_piano_key && !has_played_piano:
        You did it! You got the key! I knew you could do it! #name:Spirit+of+Music #mood:happy
        Let me just try this key in the lock... Done! #name:Melody #timeline:PianoUnlock
        Play "Ode to Joy!" You'll see the notes on the screen. That's your dad's favorite tune. He'll hear it and remember what music is!  #name:Spirit+of+Music #mood:happy
        ~ music_player = "piano"
        Beautiful! #name:Spirit+of+Music #mood:happy 
        I... I remember that sound! That was <i>Ode to Joy!</i> #name:Father #mood:happy
        Yes! And this is a piano, not firewood. #name:Melody #mood:happy
        I can't believe I forgot! I must have been out of my mind. Hooray! # father #mood:happy
        Hooray! We saved the piano! #name:Melody #mood:happy
        We sure did. Nice work, Melody. But there's still a lot of work left to do! Will you finish finding the rest of the musical instruments and saving them? # faery 
        You can count on me! # melody #mood:happy
        /*on completion, cue the following text with "victory" animation: "Contratulations! You got the keyboard instruments: piano, and celeste!"*/
        ->END
    
    - piano_complete:
        Let's play the piano! #name:Melody #mood:happy
        ~ music_player = "piano"
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