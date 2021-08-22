==fortune_teller==
You look lost, would you like the crystal ball to tell your future? #name:Fortune+Teller #audio:female_speak_medium_1
Well... I guess it can't hurt! #name:Melody #mood:concerned
Look deep into my crystal ball... #name:Fortune+Teller #audio:female_speak_short_1
{
    -!has_harp:
        A baby cries out beneath a tree... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_snare_drum:
        A great man stands among marble columns... #name:Fortune+Teller #audio:female_speak_medium_2
        ->fortune_weird
    -!has_marimba:
        The object you seek lies below the pineapple... #name:Fortune+Teller #audio:female_speak_medium_1
        ->fortune_weird
    -!has_bass_drum:
        Look for the flames of the forge... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_tuba:
        The sounds of a fountain beckon you... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_violin:
        I see strings, nestled among the apples... #name:Fortune+Teller #audio:female_speak_medium_1
        ->fortune_weird
    -!has_bass:
        A shiny bearded head appears to me from the orb... #name:Fortune+Teller #audio:female_speak_medium_2
        ->fortune_weird
    -!has_clarinet:
        A wise woman to the north has the object you seek. #name:Fortune+Teller #audio:female_speak_medium_2
        ->fortune_weird
    -!has_viola:
        Tears fall near a flickering fireplace... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_flute:
        Seek the house of learning... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_french_horn:
        A loaf of bread floats down a rushing river... #name:Fortune+Teller #audio:female_speak_short_2
        ->fortune_weird
    -!has_oboe:
        A small bird gazes at his beloved... #name:Fortune+Teller #audio:female_speak_medium_1
        ->fortune_weird
    -else:
        The portal beckons you. Go to it. #name:Fortune+Teller #audio:female_speak_medium_1
    ->END
}
->END

==fortune_weird==
    Well, that's weird! #name:Fortune+Teller #audio:female_speak_short_1
    Usually the crystal ball has more to say. #name:Fortune+Teller #audio:female_speak_medium_2
    This is giving me the creeps! Let's get out of here! #name:Spirit+of+Music #mood:mad #audio:fairy_speak_medium_1
->END