==hornquest_fished==
Is that something sparkling in the river? #name:Melody #mood:skeptical #audio:fishing_throw
Another instrument!... #name:Melody #mood:thinking #audio:fishing_reel #victory:scroll-instruments_french_horn
~ ready_for_french_horn_quest = true
That's a French horn! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1 
Better hang on to it until you find out who it belongs to... #name:Spirit+of+Music #mood:left  #audio:fairy_speak_medium_1
~ has_fished_french_horn = true
->END

==hornquest_ezekiel==
{
    - !ready_for_french_horn_quest:
        Fresh bread, straight outta the oven! #name:Ezekiel #audio:male_speak_short_1
    -> END
    - ready_for_french_horn_quest: 
        Fresh bread, straight outta the oven! #name:Ezekiel #audio:male_speak_short_1
        ~ has_french_horn_quest = true
        Hello, Ezekiel! #name:Melody #mood:happy
        Say now, what's that shiny squiggle you've got there? #name:Ezekiel #audio:male_speak_medium_1
        You recognize this French horn? #name:Melody #mood:thinking
        French bread? That's no French bread I ever saw! #name:Ezekiel #audio:male_speak_medium_2
        You know the drill – play a song he'll like! #name:Spirit+of+Music #mood:right #audio:fairy_speak_medium_1 #play:piano|Funky+Town|GGFGDDGBAG|funkytown|hornquest_played_song
}
->END

==hornquest_played_song==
Why, my old mum used to play me that song, on that very horn! #name:Ezekiel #audio:male_speak_medium_2
I knew it was his! He's a great horn player! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_medium_2
Ezekiel, can I borrow your horn? I need to share music with everyone! #name:Melody
Sure thing! Keep the songs alive! #name:Ezekiel #audio:male_speak_short_2 #victory:scroll-instruments_french_horn
Ezekiel starts humming his favorite song...
~ tooltip = "You saved the French horn!"
~ has_french_horn = true
~ completed_french_horn_quest = true
->END