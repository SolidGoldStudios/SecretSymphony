==celebration_mayor==
{
    - has_talked_to_mayor:
        Well, Melody, are you ready to wrap it up? #name:Mayor #audio:male_speak_short_1
        Hmm... #name:Melody #mood:thinking
        + [I'm not quite ready yet.] -> celebration_mayor_not_yet
        + [I'm tired. Time to go!] -> celebration_mayor_thanks
    - else:
        It's our hero! Say goodbye to your friends here and when you're done, come talk to me! #name:Mayor #audio:male_speak_long_1
        ~ has_talked_to_mayor = true
    ->DONE
}
->DONE

==celebration_mayor_not_yet==
    Say your goodbyes, and let me know when you're ready to go. #name:Mayor #audio:male_speak_medium_1
->END

==celebration_mayor_thanks==
    Thanks for everything you did today, Melody. We'll never forget music again! #name:Mayor #audio:male_speak_medium_2
    You did it, Melody! Let's go home. #name:Spirit+of+Music #mood:happy #audio:fairy_speak_short_1 #scene:Credits|0,0|-0,0,-10|0,-1
->END