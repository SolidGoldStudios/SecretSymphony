==snarequest_mayor==
{
    - completed_snare_drum_quest:
        Tempo Town – what a great name I came up with! #name:Gucci
    -> END
    - !completed_snare_drum_quest: 
        Melody, it's you! Maybe you can help me with something. #name:Mayor #audio:male_speak_medium_2
        ~ has_snare_drum_quest = true
        What is it, Mayor? #name:Melody
        I'm embarrassed to say that I've forgotten the name of our town!  #name:Mayor #audio:male_speak_long_1
        I just remember that it had something to do with this noisy object here...  #name:Mayor #audio:male_speak_long_2
        That "object" is a snare drum! It's used to keep the time of a song. #name:Spirit+of+Music #mood:right #audio:fairy_speak_long_2
        -> snarequest_question
}
->END

==snarequest_question==
    I think our town is called... #name:Melody #mood:thinking 
        + [Silly City] -> snarequest_wrong
        + [Tempo Town] -> snarequest_right
        + [Smelly Village] -> snarequest_wrong
->END

==snarequest_wrong==
    That doesn't sound right... #name:Mayor #audio:male_speak_short_2
    -> snarequest_question
->END

==snarequest_right==
    That's it! Tempo Town! #name:Mayor #audio:male_speak_short_2
    And this is a snare drum - we use that to keep a tempo! #name:Mayor #audio:male_speak_medium_1
    Yes! "Tempo" is another word for "time." #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_2
    ~ has_snare_drum = true
    Melody, I want you to have my snare drum! I think you helped me get my memory back. #name:Mayor #audio:male_speak_long_1 #victory:scroll-instruments_snare_drum
    I promise to make sure everyone remembers the name of our town! #name:Melody #mood:happy
    You're one step closer to defeating the Ear Worm! #name:Spirit+of+Music #audio:fairy_speak_medium_1
    ~ tooltip = "You saved the snare drum!"
    ~ completed_snare_drum_quest = true
->END

