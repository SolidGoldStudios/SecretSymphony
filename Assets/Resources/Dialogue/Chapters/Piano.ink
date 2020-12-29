==goodmorningchores_father==
{
    - has_piano_quest:
        The <b>scythe</b> is outside by the barn. #name:Father
    - else:
        Good morning, Melody! #name:Father #mood:happy
        Good morning, father! #name:Melody #mood:happy
        How are you? #name:Melody
        Very well. #name:Father
    ->END
}
        
==goodmorningchores_mother==
{
    - has_piano_quest:
        Please do something about this unsightly lump of lumber! #name:Mother # mood:sad
    - else:
        Ready for your morning chores, Melody? #name:Mother # mood:happy
        Oh, as ready as I'll ever be! What's first? #name:Melody 
        We found this big pile of firewood in the living room. #name:Father
        But it's all stuck together. Can you chop it into smaller pieces? #name:Mother #mood:sad
        I'll get to it. #name:Melody #mood:happy
        Thanks, Melody! You can just use the <b>scythe</b>. #name:Father #mood:happy #quest:InstrumentPiano
        ~ tooltip = "Added to Quest Log!"
        ~ has_piano_quest = true
    ->END
}

==goodmorningchores_brother==
{
    - has_piano_quest:
        Aww, Father's letting you use the scythe? #name:Thomas #mood:sad
    - else:
        Are you doing chores today? I'm not! #name:Thomas # mood:happy
    ->END
}