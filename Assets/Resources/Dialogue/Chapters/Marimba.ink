==marimbaquest_wayne==
{
    - !completed_marimba_quest:
        Grocer Wayne, how are you today? #name:Melody
        ~ has_marimba_quest = true
        I feel strange, truth be told. Like something's missing... #name:Grocer+Wayne #audio:male_speak_medium_1
        Psst! Look behind him - that's a marimba! #name:Spirit+of+Music #mood:left #audio:fairy_speak_medium_2
        Why do you have all those fruits piled on that marimba? #name:Melody #mood:thinking
        Marimba? Ah, that must be a fancy name for my new produce table! #name:Grocer+Wayne #audio:male_speak_long_1
        That's no table – that's a musical instrument! #name:Melody #mood:concerned
        Here, I'll play you a song! #name:Melody #mood:happy #play:piano|Funky+Town|GGFGDDGBAG|funkytown|marimbaquest_played_song
    - completed_marimba_quest:
        A good song is like a juicy fresh fruit, don't you think? #name:Grocer+Wayne #audio:male_speak_medium_1
    ->END
}
->END

==marimbaquest_played_song==
What is this feeling? How'd you do that? #name:Grocer+Wayne #audio:male_speak_medium_2
That feeling is joy - that's the magic of music! #name:Melody #mood:happy
~ has_marimba = true
I don't need this for fruits! Here, you take it. #name:Grocer+Wayne #audio:male_speak_medium_2 #victory:scroll-instruments_marimba
Thanks, Grocer Wayne! #name:Melody #mood:happy
~ tooltip = "You saved the marimba!"
~ completed_marimba_quest = true
->END