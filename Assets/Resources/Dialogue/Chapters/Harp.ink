==harpquest_couple==
{
    - !completed_harp_quest:
        Melody! Good to see you. I wish we could catch up, but... #name:Winifred #audio:female_speak_medium_1
        ~ has_harp_quest = true
        ...baby Wendy won't stop crying! #name:Wallie #mood:angry #audio:male_speak_short_2
        Oh no! What will you do? #name:Melody #mood:concerned
        If she won't take a nap, I can't hang laundry on my shiny new rack! #name:Wallie #mood:angry #audio:male_speak_long_2
        He seriously thinks that harp is a laundry rack? Now I've heard it all! #name:Spirit+of+Music #mood:happy #audio:fairy_speak_long_2
        I think I have an idea... #name:Melody #mood:thinking
        We'll try anything! #name:Winifred #audio:female_speak_short_1 #play:piano|Brahm's Lullaby|EEGEEG|brahms_lullaby|harpquest_played_song
    - completed_harp_quest:
        Baby Wendy is finally asleep. Thank you! #name:Winifred #audio:female_speak_medium_2
        But now where will we dry our laundry? #name:Wallie #mood:angry #audio:male_speak_medium_1
    ->END
}
->END

==harpquest_played_song==
That peaceful sound... Wendy is falling asleep! #name:Winifred #audio:female_speak_medium_2
That was Brahm's Lullaby! #name:Melody #mood:happy
May I borrow your harp to bring music to the town? #name:Melody
~ has_harp = true
Well, alright. I was going to dry laundry on it but... #name:Wallie #mood:angry #audio:male_speak_medium_2 #victory:scroll-instruments_harp
...but of course, we're in your debt! Take it! #name:Winifred #audio:female_speak_medium_1
~ tooltip = "You saved the harp!"
~ completed_harp_quest = true
->END