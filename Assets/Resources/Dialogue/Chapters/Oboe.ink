==oboequest_gucci==
{
    - completed_oboe_quest:
        You've done a great service for my lady! Thank you! #name:Gucci
    -> END
    - !completed_oboe_quest: 
        My lady won't stop crying. Look at how sad she is! #name:Gucci
        ~ has_oboe_quest = true
        I just look at this magic wand, and it makes me so upset! #name:Lady+Alley #mood:sad #audio:female_speak_medium_1
        That's not a magic wand! It's an oboe, a musical instrument! #name:Melody
        I wish I knew what any of that meant! #name:Lady+Alley #audio:female_speak_short_2
        See what I mean? Can you help my lady sing with me again? #name:Gucci #play:piano|Clair+de+lune|CCAGAG|birdlady_oboe|oboequest_played_song
}
->END

==oboequest_played_song==
I felt like something was missing, but you gave it back to me! #name:Lady+Alley #mood:happy #audio:female_speak_medium_2
I just played you a song! #name:Melody #mood:happy
~ has_oboe = true
Why don't you keep that... oboe, was it? I only need my voice to sing with Gucci! #name:Lady+Alley #audio:female_speak_long_2 #victory:scroll-instruments_oboe
Thank you, Lady Alley! #name:Melody #mood:happy
Lady Alley and Gucci look so happy now!
~ tooltip = "You saved the oboe!"
~ completed_oboe_quest = true
->END

==oboequest_lady_alley==
{
    - !completed_oboe_quest:
        Why am I so sad today? #name:Lady+Alley #mood:sad #audio:female_speak_short_1
    -> END
    - completed_oboe_quest: 
        My heart is full of music! #name:Lady+Alley #mood:happy #audio:female_speak_medium_1
}
->END