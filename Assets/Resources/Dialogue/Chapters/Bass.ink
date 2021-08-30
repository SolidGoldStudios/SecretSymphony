==bass_innkeeper==
{
    - !completed_bass_quest:
        Melody! Come look! Check out this huge dustpan I found! #name:Innkeeper+Theophilius #mood:happy #audio:male_speak_medium_2
        ~ has_bass_quest = true
        Here we go again... #name:Spirit+of+Music #mood:right #audio:fairy_speak_short_1 #showSparkles
        Innkeeper Theophilus, doesn't that seem pretty heavy for a dustpan? #name:Melody #mood:skeptical #hideSparkles
        Well, what else could it be? #name:Innkeeper+Theophilius #mood:sad #audio:male_speak_short_1
        It's a musical instrument – it makes a beautiful sound! #name:Melody #mood:happy
        Now you're talking nonsense! I have to get back to my cleaning. #name:Innkeeper+Theophilius  #audio:male_speak_long_1
        I'll prove it to you! #name:Melody #play:piano|Funky+Town|GGFGDDGBAG|funkytown|bassquest_played_song
    - completed_bass_quest:
        Melody! Can I get you some apple cider? #name:Innkeeper+Theophilius #mood:happy #audio:male_speak_medium_2
    ->END
}
->END

==bassquest_played_song==
You're right, that is a beautiful sound! #name:Innkeeper+Theophilius #mood:happy #audio:male_speak_medium_1
It's music! An evil worm stole it from us, and I intend to get it back! #name:Melody #mood:happy
Could I borrow your bass? I promise I'll return it! #name:Melody 
~ has_bass = true
A "bass," you say? Well, sure – take it! #name:Innkeeper+Theophilius #mood:happy #audio:male_speak_medium_2 #victory:scroll-instruments_bass
We've almost got them all! #name:Spirit+of+music #mood:happy #showSparkles #audio:fairy_speak_short_2
~ tooltip = "You saved the bass!"
~ completed_bass_quest = true
->END