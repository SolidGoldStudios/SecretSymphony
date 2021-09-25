==finalexam_earworm==
    Ah, Spirit of Music! I should have known you’d meddle with my plans. #name:Earworm #audio:earworm_speak_long_1
    Whatever he says, Melody, don’t listen! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_medium_1
    And you. Pesky kid! You’re the most tone-deaf of them all.  #name:Earworm #audio:earworm_speak_long_2
    That’s mean, Ear Worm! #name:Melody #mood:sad
    I’ll show you! #name:Earworm #audio:earworm_speak_short_1 #scene:Portal|5,-55|5,-63,-57.5|0,-1
->END

==finalexam_fairy==
    This is it, Melody - time to put your knowledge to the test! #name:Spirit+of+Music #mood:right #audio:fairy_speak_medium_1
    See those glowing spots? Walk up to each one to place an instrument. #name:Spirit+of+Music #audio:fairy_speak_long_1
    I know you can do it! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1
->END

==finalexam_worm_state_1==
    ~ has_shown_worm_state_1 = true
    What is this!? What's happening? #name:Earworm #audio:earworm_speak_short_2
    Look, Melody! The Ear Worm, he's... #name:Spirit+of+Music #mood:right #audio:fairy_speak_short_2
    He's getting smaller! Whoa! #name:Melody #mood:concerned
    You should keep going! Keep placing those instruments! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_2
->END

==finalexam_worm_state_2==
    ~ has_shown_worm_state_2 = true
    I'm... getting smaller? How? #name:Earworm #audio:earworm_speak_short_1
    You're doing it, Melody! Keep going! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_2
->END

==finalexam_worm_state_3==
    ~ has_shown_worm_state_3 = true
    No! You rotten kid! Now I'm really mad! #name:Earworm #audio:earworm_speak_short_2
    You're almost there, Melody! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1
->END

==finalexam_worm_state_4==
    ~ has_shown_worm_state_4 = true
    Now you've done it, you rotten kid! #name:Earworm #audio:earworm_speak_short_1
    Look, Melody! He's so tiny now! #name:Spirit+of+Music #mood:right #audio:fairy_speak_short_2
    He's almost kinda cute! #name:Melody #mood:happy
    You… you win! I give up! Music is too strong for me.  #name:Earworm #audio:earworm_speak_medium_1
    Hooray! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_medium_1
    Tell me, Ear Worm. Why do you hate music so much? #name:Melody #mood:concerned
    Where I’m from, we don’t have any music at all.  #name:Earworm #audio:earworm_speak_medium_2
    Then why don’t you take some music home with you? #name:Melody #mood:thinking
    But no one would understand it!  #name:Earworm #audio:earworm_speak_short_2
    Then teach them! Learning is fun. #name:Melody #mood:happy
    But it’s hard, too. #name:Earworm #audio:earworm_speak_short_1
    Sometimes the hard things are the most fun of all! #name:Melody
    …Okay! I’ll try!  #name:Earworm #audio:earworm_speak_short_2
    You did it, Melody! I knew you could! Let's go home. #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_2 #scene:TownCelebration|-2.571,-62.41|-2.571,-57,-2.25|0,-1
->END

/* Piano trivia */
==finalexam_piano==
    You think you know everything about this piano, do you? #name:Earworm #audio:earworm_speak_medium_1
    Well, then tell me this... #name:Earworm #audio:earworm_speak_short_2
    What is the name of the part of the piano where your feet are placed? #name:Earworm #audio:earworm_speak_long_1
    I know this one! They're called... #name:Melody #mood:thinking 
        + [Shoes] -> finalexam_piano_wrong
        + [Pedals] -> finalexam_piano_right
        + [Feet] -> finalexam_piano_wrong
->END

==finalexam_piano_wrong==
    Hah! Wrong! #name:Earworm #audio:earworm_speak_short_1
    -> finalexam_piano
->END

==finalexam_piano_right==
    ~ has_placed_piano = true
    How... how did you know that?? #name:Earworm #audio:earworm_speak_medium_1
    Melody knows everything about the piano! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_2
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Harp trivia */
==finalexam_harp==
    So you're a harp expert, eh? #name:Earworm #audio:earworm_speak_medium_2
    Bet you can't tell me this! #name:Earworm #audio:earworm_speak_medium_1
    The harp and the piano are both members of what two instrument families? #name:Earworm #audio:earworm_speak_long_2
    I think I know that one... #name:Melody #mood:thinking 
        + [Strings and percussion] -> finalexam_harp_right
        + [Brass and percussion] -> finalexam_harp_wrong
        + [Woodwinds and brass] -> finalexam_harp_wrong
->END

==finalexam_harp_wrong==
    Guess again, kid! #name:Earworm #audio:earworm_speak_short_1
    -> finalexam_harp
->END

==finalexam_harp_right==
    ~ has_placed_harp = true
    Ugh! How could you know? #name:Earworm #audio:earworm_speak_medium_1
    Take that, Ear Worm! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Marimba trivia */
==finalexam_marimba==
    I bet you don't know what that thing is! #name:Earworm #audio:earworm_speak_medium_2
    It's a... #name:Melody #mood:thinking 
        + [Decorative fruit table] -> finalexam_marimba_wrong
        + [Post-modern artwork] -> finalexam_marimba_wrong
        + [Marimba] -> finalexam_marimba_right
->END

==finalexam_marimba_wrong==
    Hah! Nope. #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_marimba
->END

==finalexam_marimba_right==
    ~ has_placed_marimba = true
    I was just going easy on you! #name:Earworm #audio:earworm_speak_short_1
    Yeah, right... #name:Spirit+of+Music #mood:mad #audio:fairy_speak_short_2
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Bass drum trivia */
==finalexam_bass_drum==
    What could a twerp like you know about a bass drum? #name:Earworm #audio:earworm_speak_medium_1
    Try me! #name:Melody #mood:skeptical
    To which family does the bass drum belong? #name:Earworm #audio:earworm_speak_medium_2
    I know! It's... #name:Melody #mood:thinking 
        + [Percussion] -> finalexam_bass_drum_right
        + [Wind] -> finalexam_bass_drum_wrong
        + [Brass] -> finalexam_bass_drum_wrong
->END

==finalexam_bass_drum_wrong==
    Wrong, as I expected! #name:Earworm #audio:earworm_speak_short_1
    -> finalexam_bass_drum
->END

==finalexam_bass_drum_right==
    ~ has_placed_bass_drum = true
    That can't be! #name:Earworm #audio:earworm_speak_short_2
    I know my instruments, Ear Worm! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Snare drum trivia */
==finalexam_snare_drum==
    Ever seen a snare drum, smarty pants? #name:Earworm #audio:earworm_speak_medium_1
    Of course I have! #name:Melody #mood:concerned 
    Well then, what part of it are you supposed to hit? #name:Earworm #audio:earworm_speak_medium_2
    Um, it's the... #name:Melody #mood:thinking
        + [Arm] -> finalexam_snare_drum_wrong
        + [Foot] -> finalexam_snare_drum_wrong
        + [Head] -> finalexam_snare_drum_right
->END

==finalexam_snare_drum_wrong==
    Incorrect! Ha, ha. #name:Earworm #audio:earworm_speak_short_1
    -> finalexam_snare_drum
->END

==finalexam_snare_drum_right==
    ~ has_placed_snare_drum = true
    Hmmph. I guess you do know a little bit. But it won't save your precious music! #name:Earworm #audio:earworm_speak_long_1
    That's enough out of you, Ear Worm! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_short_1
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* French horn trivia */
==finalexam_french_horn==
    A French horn! #name:Melody #mood:happy
    Don't try to act so smart! Do you even know what instrument family the French horn is in? #name:Earworm #audio:earworm_speak_long_2
    It's, well... #name:Melody #mood:thinking 
        + [Brass] -> finalexam_french_horn_right
        + [Percussion] -> finalexam_french_horn_wrong
        + [Woodwind] -> finalexam_french_horn_wrong
->END

==finalexam_french_horn_wrong==
    I knew it! No kid could know so much about instruments. #name:Earworm #audio:earworm_speak_medium_2
    -> finalexam_french_horn
->END

==finalexam_french_horn_right==
    ~ has_placed_french_horn = true
    You're... right? But how? #name:Earworm #audio:earworm_speak_short_2
    I did my homework, Ear Worm, just like you should have! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Trumpet trivia */
==finalexam_trumpet==
    I bet you don't know anything about this trumpet, little kid! #name:Earworm #audio:earworm_speak_medium_2
    I bet I do! #name:Melody #mood:skeptical
    Then what is the word for the big, wide end piece of a trumpet, where the sound comes out? #name:Earworm #audio:earworm_speak_long_2
        + [Cone] -> finalexam_trumpet_wrong
        + [Bell] -> finalexam_trumpet_right
        + [Hat] -> finalexam_trumpet_wrong
->END

==finalexam_trumpet_wrong==
    I knew you'd get that wrong! #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_trumpet
->END

==finalexam_trumpet_right==
    ~ has_placed_trumpet = true
    How could you know that? You must have cheated! #name:Earworm #audio:earworm_speak_medium_1
    Melody never cheats, you rude worm! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_short_1
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Trombone trivia */
==finalexam_trombone==
    I've had enough of you acting like you know about musical instruments! #name:Earworm #audio:earworm_speak_medium_2
    You probably don't even know what part of this trombone you move to make sound! #name:Earworm #audio:earworm_speak_long_2
    I do! It's the... #name:Melody #mood:thinking 
        + [Slide] -> finalexam_trombone_right
        + [Swing] -> finalexam_trombone_wrong
        + [Monkey bar] -> finalexam_trombone_wrong
->END

==finalexam_trombone_wrong==
    Wrong, just as I predicted! #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_trombone
->END

==finalexam_trombone_right==
    ~ has_placed_trombone = true
    That was a lucky guess! #name:Earworm #audio:earworm_speak_short_1
    I guess I'll keep being lucky, then! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Tuba trivia */
==finalexam_tuba==
    This instrument is bigger than you are! Aren't you scared, little kid? #name:Earworm #audio:earworm_speak_medium_2
    Of course not! #name:Melody #mood:happy
    Well then, what is it called? I bet you don't know! #name:Earworm #audio:earworm_speak_medium_1
    Easy! That's a... #name:Melody #mood:thinking 
        + [SCUBA] -> finalexam_tuba_wrong
        + [Tuba] -> finalexam_tuba_right
        + [Roomba] -> finalexam_tuba_wrong
->END

==finalexam_tuba_wrong==
    I knew you didn't know it! #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_tuba
->END

==finalexam_tuba_right==
    ~ has_placed_tuba = true
    You got that right? How did you know? #name:Earworm #audio:earworm_speak_short_1
    Melody knows all about these instruments! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_2
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Bass trivia */
==finalexam_bass==
    Think you're smart, eh? Well, what's this instrument, then? #name:Earworm #audio:earworm_speak_medium_2
    I know, it's a... #name:Melody #mood:thinking 
        + [Vase] -> finalexam_bass_wrong
        + [Lace] -> finalexam_bass_wrong
        + [Bass] -> finalexam_bass_right
->END

==finalexam_bass_wrong==
    And here I thought you knew so much! #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_bass
->END

==finalexam_bass_right==
    ~ has_placed_bass = true
    How could you know all this? #name:Earworm #audio:earworm_speak_short_1
    I love these instruments, Ear Worm! You shouldn't have stolen them! #name:Melody #mood:skeptical
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Viola trivia */
==finalexam_viola==
    Tell me this, smarty: What do you call the stick you use to play this viola? #name:Earworm #audio:earworm_speak_long_1
    Piece of cake! That's called a... #name:Melody #mood:thinking 
        + [Bow] -> finalexam_viola_right
        + [Baton] -> finalexam_viola_wrong
        + [Rod] -> finalexam_viola_wrong
->END

==finalexam_viola_wrong==
    Hmph, as expected – you don't know! #name:Earworm #audio:earworm_speak_medium_2
    -> finalexam_viola
->END

==finalexam_viola_right==
    ~ has_placed_viola = true
    You knew? But you're just a kid! #name:Earworm #audio:earworm_speak_short_1
    Even kids can learn about music, Ear Worm! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Violin trivia */
==finalexam_violin==
    You'll never be able to answer my super-tough violin question! #name:Earworm #audio:earworm_speak_medium_2
    Oh yeah? We'll see about that! #name:Melody #mood:skeptical
    To what instrument family does the violin belong, hmm? #name:Earworm #audio:earworm_speak_medium_1
        + [Brass] -> finalexam_violin_wrong
        + [Strings] -> finalexam_violin_right
        + [Woodwind] -> finalexam_violin_wrong
->END

==finalexam_violin_wrong==
    Wrong, as I predicted. Hmmph. #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_violin
->END

==finalexam_violin_right==
    ~ has_placed_violin = true
    No! You can't know all of this! #name:Earworm #audio:earworm_speak_short_1
    She can, and she does! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Oboe trivia */
==finalexam_oboe==
    Smart one, eh? Well then, to what instrument family does this oboe belong? #name:Earworm #audio:earworm_speak_medium_2
    I know that – it's... #name:Melody #mood:thinking 
        + [Woodwind] -> finalexam_oboe_right
        + [Percussion] -> finalexam_oboe_wrong
        + [Bass] -> finalexam_oboe_wrong
->END

==finalexam_oboe_wrong==
    Silly kid! I guess you don't know as much as you claim! #name:Earworm #audio:earworm_speak_medium_2
    -> finalexam_oboe
->END

==finalexam_oboe_right==
    ~ has_placed_oboe = true
    But, but... how could you know? #name:Earworm #audio:earworm_speak_short_1
    That's my Melody! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_2
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Flute trivia */
==finalexam_flute==
    You probably don't even know what this instrument is, kid! #name:Earworm #audio:earworm_speak_medium_2
    I sure do know – it's a... #name:Melody #mood:thinking 
        + [Fruit] -> finalexam_flute_wrong
        + [Flute] -> finalexam_flute_right
        + [Newt] -> finalexam_flute_wrong
->END

==finalexam_flute_wrong==
    Ha, ha - that was the wrong answer! #name:Earworm #audio:earworm_speak_medium_2
    -> finalexam_flute
->END

==finalexam_flute_right==
    ~ has_placed_flute = true
    Hmmph! Beginner's luck. #name:Earworm #audio:earworm_speak_short_1
    You just can't admit that Melody knows all about these instruments! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_medium_2
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END

/* Clarinet trivia */
==finalexam_clarinet==
    If you know so much, tell me this... #name:Earworm #audio:earworm_speak_medium_2
    The "buttons" you use to change the sound of this clarinet are called what? #name:Earworm #audio:earworm_speak_long_1
    Oh, I know this! They're called... #name:Melody #mood:thinking 
        + [Switches] -> finalexam_clarinet_wrong
        + [Clickers] -> finalexam_clarinet_wrong
        + [Keys] -> finalexam_clarinet_right
->END

==finalexam_clarinet_wrong==
    Wrong, naturally! Ha! #name:Earworm #audio:earworm_speak_short_2
    -> finalexam_clarinet
->END

==finalexam_clarinet_right==
    ~ has_placed_clarinet = true
    You.. you... you punk! How could you know that? #name:Earworm #audio:earworm_speak_medium_1
    I studied up! #name:Melody #mood:happy
    {
        - worm_state_1 && !has_shown_worm_state_1:
            -> finalexam_worm_state_1
        - worm_state_2 && !has_shown_worm_state_2:
            -> finalexam_worm_state_2
        - worm_state_3 && !has_shown_worm_state_3:
            -> finalexam_worm_state_3
        - worm_state_4 && !has_shown_worm_state_4:
            -> finalexam_worm_state_4
    }
->END


