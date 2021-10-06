==violaquest_bard==
{
    - !completed_viola_quest:
        I feel like a piece of me has been ripped away! #name:Guilhem #mood:sad #audio:male_speak_medium_1
        ~ has_viola_quest = true
        But... I can't remember exactly why. #name:Guilhem #mood:sad #audio:male_speak_short_1
        I saw the Earm Worm steal his beloved lute last night... #name:Spirit+of+Music #mood:sad #audio:fairy_speak_medium_1
        Maybe that viola on the shelf would make him feel better! #name:Spirit+of+Music #mood:right #audio:fairy_speak_medium_2
        Why don't you play a song with that viola over there? #name:Melody #mood:thinking
        "Play"? A... "song"? #name:Guilhem #audio:male_speak_short_1
        Here, I'll show you! #name:Melody #mood:happy #play:piano|The+Elephant|CFFFEFG|bard_viola|violaquest_played_song
    -completed_viola_quest:
        I shall put on a musical concert, oui oui! #name:Guilhem #mood:happy #audio:male_speak_medium_2
    ->END
}
->END

==violaquest_played_song==
~ bard_stop_crying = true
Yes! This... "song" – it lifts my very soul! #name:Guilhem #mood:happy #audio:male_speak_short_2
I remember now - the evil Ear Worm took my joy from me. #name:Guilhem #mood:sad #audio:male_speak_medium_1
We're going to defeat him – and we need that viola to do it! #name:Melody
~ has_viola = true
Take it, and use it to teach that foul worm a lesson! #name:Guilhem  #audio:male_speak_medium_2 #victory:scroll-instruments_viola
I won't let you down, Guilhem! #name:Melody #mood:happy
~ tooltip = "You saved the viola"
~ completed_viola_quest = true
->END