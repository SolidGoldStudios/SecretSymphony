==trumpetquest_brother==
{
    - has_piano_quest && !completed_piano_quest:
        Aww, Father let you use the scythe? #name:Thomas #mood:sad  #audio:female_speak_medium_1
        ->END
    - completed_piano_quest && !has_trumpet_quest:
        Could you catch a trumpetfish from the pond? Let's have fish for dinner tonight! #name:Thomas #mood:happy  #audio:female_speak_long_2
        ~ has_trumpet_quest = true
        ->END
    - completed_piano_quest && has_trumpet_quest && !has_fished_trumpet:
        Well? Did you get the trumpetfish? #name:Thomas #mood:sad  #audio:female_speak_short_1
        ->END
    - has_trumpet_quest && has_fished_trumpet && !completed_trumpet_quest:
        I'm so hungry! Did you bring a trumpetfish? It's my favorite! #name:Thomas #mood:mad #audio:female_speak_medium_2
        No fish – but I did bring your trumpet back! It's a musical instrument! #name:Melody #mood:happy
        My... trumpet? Musical... what? #name:Thomas #mood:sad #audio:female_speak_short_2
        Maybe if you play something, he'll remember! #name:Spirit+of+Music #mood:right #audio:fairy_speak_short_2 #play:piano|Funky+Town|GGFGDDGBAG|funkytown|trumpetquest_played_song
        -> END
    - completed_trumpet_quest:
        I'm still hungry for fish... #name:Thomas #mood:sad
        ->END
    - else:
        Hey Sis... I feel like there's something important that I'm forgetting to do... #name:Thomas #mood:sad #audio:female_speak_long_2
        ->END
}

==trumpetquest_pole==
My fishing pole! Maybe I can use it on that sparkly spot over there... #name:Melody #mood:happy
~ has_pole = true
->END

==trumpetquest_fished==
This doesn't look like a fish... #name:Melody #mood:thinking 
That's your brother's trumpet! He's quite a talented player! #name:Spirit+of+Music #mood:happy #victory:scroll-instruments_trumpet
Really? I had better take it back to him! #name:Melody #mood:happy #scene:LivingRoom|-5.9,-15.48|-4.6,-11.68,-10|0,1
~ has_fished_trumpet = true
->END

==trumpetquest_played_song==
I love that song! #name:Thomas #mood:happy #audio:female_speak_short_1
Wait, song?! Did I forget about music? #name:Thomas #mood:sad #audio:female_speak_short_1
You sure did, silly! #name:Melody #mood:happy
Will you help me fix things? I need to borrow your trumpet to beat a monster. #name:Melody
Yes! Stealing music is bad - teach that monster a lesson! #name:Thomas #mood:mad #audio:female_speak_medium_1 #victory:scroll-instruments_trumpet
~ tooltip = "You saved the trumpet!"
~ has_trumpet = true
~ completed_trumpet_quest = true
->END