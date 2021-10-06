==clarinetquest_healer==
{
    - !completed_clarinet_quest:
        Hello, Healer Leonora! #name:Melody #mood:happy
        ~ has_clarinet_quest = true
        Why, hello to you, my dear Melody! #name:Healer+Leonora #mood:happy #audio:female_speak_short_1
        Melody, look! That clarinet over there! #name:Spirit+of+Music #mood:left #audio:fairy_speak_medium_2
        Healer Leonora, do you play the clarinet? #name:Melody #mood:thinking
        Play? I don't play, dear, I have too much work to do mixing healing potions! #name:Healer+Leonora #mood:sad #audio:female_speak_long_1
        At least this new stirring-stick I found helps me mix faster! #name:Healer+Leonora #mood:happy #audio:female_speak_long_2
        That's no stirring-stick – that's a musical instrument! #name:Melody #mood:happy
        May I show you how it works? #name:Melody
        Well, I suppose. But don't take too long with your game, I'm very busy! #name:Healer+Leonora #audio:female_speak_long_1 #play:piano|Rhapsody+in+Blue|FGACDEFG|apothecary_clarinet|clarinetquest_played_song
    - completed_clarinet_quest: 
        Can I interest you in a tincture of some sort? #name:Healer+Leonora #mood:happy #audio:female_speak_medium_1
    ->END
}
->END

==clarinetquest_played_song==
My goodness, that was beautiful! #name:Healer+Leonora #mood:happy #audio:female_speak_short_2
That was music! Everyone forgot about it, but I'm going to fix that. #name:Melody #mood:happy
I couldn't possibly use such a fine thing to stir potions. #name:Healer+Leonora #mood:sad #audio:female_speak_medium_1
~ has_clarinet = true
You should have it, Melody! #name:Healer+Leonora #mood:happy #audio:female_speak_short_2 #victory:scroll-instruments_clarinet
You're getting so good at this, Melody! #name:Spirit+of+music #mood:happy #audio:fairy_speak_medium_1
~ tooltip = "You saved the clarinet!"
~ completed_clarinet_quest = true
->END

==clarinetquest_cat==
{
    - !completed_clarinet_quest:
        Healer Leonora has been acting so strangely lately... #name:Kitty
    - completed_clarinet_quest:
        Healer Leonora is back to normal! Thank you! #name:Kitty
    ->END
    
}
->END