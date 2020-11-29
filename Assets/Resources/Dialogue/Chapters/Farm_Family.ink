==start_farm_family_father==
{
    - has_played_piano:
        Do you know what this device is? #name:Father
        It makes pretty sounds, I like it! #name:Kay #mood:happy
        Are you off your rocker? I don't hear a thing! #name:Father
        -> END
    - else:
        WTF is this thing? We've never seen it before. #name:Father
        -> END
}

==start_farm_family_mother==
That strange device has buttons to press, but it doesn't do anything. #name:Mother #mood:sad
-> END

==start_farm_family_brother==
Have you pet the chickens yet today? #name:Brother #mood:happy
-> END