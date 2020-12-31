==pianoquest_father==
{
    - has_piano_quest:
        The <b>scythe</b> is outside by the barn. #name:Father
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
    - else:
        Ready for your morning chores, Melody? #name:Mother # mood:happy
        Oh, as ready as I'll ever be! What's first? #name:Melody 
        We found this big pile of firewood in the living room. #name:Father
        But it's all stuck together. Can you chop it into smaller pieces? #name:Mother #mood:sad
        I'll get to it. #name:Melody #mood:happy
        Thanks, Melody! You can just use the <b>scythe</b>. #name:Father #mood:happy #quest:InstrumentPiano
        ~ tooltip = "Added to Quest Log!"
        ~ has_piano_quest = true
    ->END
}

==pianoquest_brother==
{
    - has_piano_quest:
        Aww, Father's letting you use the scythe? #name:Thomas #mood:sad
    - else:
        Are you doing chores today? I'm not! #name:Thomas # mood:happy
    ->END
}

==pianoquest_piano==
{
    - has_piano_quest && !has_scythe:
        This looks pretty weird for a "pile of lumber." And why does it have a keyhole? #name:Melody #mood:thinking
        ->END
        
    - has_scythe && !has_spoken_to_spirit_piano:
        I'm the Spirit of Music. Whatever you do, don't hurt that piano! #name:Spirit+of+Music #mood:sad
        The Spirit of Music, huh? But this is just a bunch of kindling. #name:Melody #mood:skeptical
        It most certainly is not. It's a piano. And by the looks of it, a lovely one. #name:Spirit+of+Music #mood:mad
        A piano? What's a piano? #name:Melody #mood:neutral
        A piano is a musical instrument. #name:Spirit+of+Music
        A "musical instrument?" You're talking in riddles! #name:Melody #mood:concerned
        I wish I were... oh dear! /*crying sound and animation?*/ #name:Spirit+of+Music #mood: #mood:sad
        If it's that important to you, I won't hurt this...piano. #name:Melody #mood:sad
        Really? You won't? Hooray! Maybe you can help me save the other instruments? #name:Spirit+of+Music #mood:happy
        What other instruments? #name:Melody
        The horrible Ear Worm has erased everyone's memory of music! The other instruments are in grave peril. #name:Spirit+of+Music #mood:sad
        What can I do to help? I have no special skills...#name:Melody #mood:sad
        Actually, you happen to be a brilliant composer! You've just forgotten... like everyone else. #name:Spirit+of+Music #mood:right
        Me? A composer? #name:Melody #mood:skeptical
        Yes! But in order to remember, you have to help me collect all the instruments, learn about them, and assemble them into an orchestra. Then you'll be able to hear your beautiful song! #name:Spirit+of+Music #mood:happy
        Okay! I'll do it! #name:Melody #mood:happy
        Great! Hooray! The lid of the piano is closed and locked right now. I was going to open it up, but I dropped the key in your wheat field. #name:Spirit+of+Music #mood:left
        Don't worry, I'll get it. # melody
        You'll have to hurry though. I can freeze your family for a short amount of time, but not forever. You'll need to scythe all the wheat in fifteen seconds. #name:Spirit+of+Music
        Okay. But...I haven't used the scythe before. #name:Melody # mood:sad
        It's easy, as long as you're safe. Just click the area that you'd like to scythe. #name:Spirit+of+Music #mood:happy
        Here goes nothing! #name:Melody #mood:skeptical
        One last thing: there was a book about pianos around here somewhere. Have you seen it? #name:Spirit+of+Music #mood:right
        *[Yes, I found it!]
            Good! You can find it in your Inventory and read it, to jog your memory on pianos! #name:Spirit+of+Music #mood:happy
            ->END
        *[No, I haven't seen it.]
            It should be around here on the floor. Please find it and read it, to jog your memory on pianos! #faery
            ->END
        
    - has_spoken_to_spirit_piano && !has_piano_key:
        Well? Did you get the key? #name:Spirit+of+Music
        ->END
         
    - has_piano_key && !has_played_piano:
        You did it! You got the key! I knew you could do it! #name:Spirit+of+Music #mood:happy
        Let me just try this key in the lock... Done! #name:Melody #timeline:PianoUnlock
        Play "Ode to Joy!" You'll see the notes on the screen. That's your dad's favorite tune. He'll hear it and remember what music is!  #name:Spirit+of+Music #mood:happy
        ->END
         
        
    - has_played_piano && !piano_complete:
        Beautiful! # faery #mood:happy 
        I... I remember that sound! That was <i>Ode to Joy!</i> # father #mood:happy
        Yes! And this is a piano, not firewood. #Melody #mood:happy
        I can't believe I forgot! I must have been out of my mind. Hooray! # father #mood:happy
        Hooray! We saved the piano! #name:Melody #mood:happy
        We sure did. Nice work, Melody. But there's still a lot of work left to do! Will you finish finding the rest of the musical instruments and saving them? # faery 
        You can count on me! # melody #mood:happy
        /*on completion, cue the following text with "victory" animation: "Contratulations! You got the keyboard instruments: piano, and celeste!"*/
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