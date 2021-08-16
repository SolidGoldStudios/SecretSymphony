==tubaquest_fished==
I think I see something in the fountain... #name:Melody #mood:skeptical #audio:fishing_throw
Whoa, that's a huge horn! #name:Melody #mood:happy #audio:fishing_reel #victory:scroll-instruments_tuba
~ ready_for_tuba_quest = true
It's a tuba! Doesn't its sad sound make you think of someone? #name:Spirit+of+Music #mood:sad #audio:fairy_speak_medium_1
Maybe that cranky coach driver Philip knows something about it... #name:Melody #mood:thinking
~ has_fished_french_horn = true
->END

==tubaquest_philip==
{
    - !ready_for_tuba_quest:
        You don't have any money to rent a carriage, go away! #name:Coach+Driver+Philip #audio:male_speak_medium_1
    -> END
    - ready_for_tuba_quest: 
        Put that big metal thing away, you'll scare the horses! #name:Coach+Driver+Philip #audio:male_speak_medium_2
        ~ has_tuba_quest = true
        Philip, don't you remember this? It's a tuba! #name:Melody #mood:concerned
        A tube of what? Get out of here! #name:Coach+Driver+Philip #audio:male_speak_short_1
        I just know this tuba belongs to him! Can you convince him with music? #name:Spirit+of+Music #audio:fairy_speak_long_1 #play:piano|Funky+Town|GGFGDDGBAG|funkytown|tubaquest_played_song
}
->END

==tubaquest_played_song==
That sad song! It makes me so happy! #name:Coach+Driver+Philip #audio:male_speak_short_2
Philip, you're so strange! But you've been such a big help. #name:Melody #mood:happy
May I borrow your tuba? I need to make sure nobody else forgets! #name:Melody
I'm in such a good mood, I'll let you hang on to it! #name:Coach+Driver+Philip #audio:male_speak_short_2 #victory:scroll-instruments_tuba
He's not so cranky after all! #name:Spirit+of+music #mood:happy
~ tooltip = "You saved the tuba!"
~ has_tuba = true
~ completed_tuba_quest = true
->END

==tubaquest_horse==
{
    - !completed_tuba_quest:
        Mr. Philip isn't usually this grumpy, but today he woke up on the wrong side of the bed. Can you help? #name:Philip's+Horse
    -> END
    - completed_tuba_quest: 
        Mr. Philip is in such a good mood! What did you do?! #name:Philip's+Horse
}
->END