==start_farm_family_father==
{
    - has_played_piano:
        Do you know what this device is? #name:Father
        It makes pretty sounds, I like it! #name:Kay #mood:happy
        Are you off your rocker? I don't hear a thing! #name:Father
        -> END
    - else:
        WTF is this thing? We've never seen it before. #name:Father
        + [Lol.]
            Lol. #name:Kay
            Be serious! #name:Father
            ->END
        + [What?]
            What? #name:Kay
            The giant thing right there! #name:Father
            -> END
}

==start_farm_family_mother==
That strange device has buttons to press, but it doesn't do anything. #name:Mother #mood:sad
-> END

==start_farm_family_brother==
Have you pet the chickens yet today? #name:Thomas #mood:happy
-> END