INCLUDE Chapters/FaeryAppears.ink
INCLUDE Chapters/Piano.ink
INCLUDE Chapters/Trombone.ink
INCLUDE Chapters/Trumpet.ink
INCLUDE Chapters/Flute.ink
INCLUDE Chapters/Violin.ink
INCLUDE Chapters/Drum.ink
INCLUDE Chapters/Items.ink


/** 
 * Triggers
 **/
VAR tooltip = ""


/**
 * States
 * Everything in here should start out false,
 * except ready_for_piano_quest
 * (and the three town quests, for the time being)
 **/
 
/* Items */
VAR has_scythe = false
VAR has_pole = false

/* Instruments */
VAR has_piano = false
VAR has_violin = false
VAR has_viola = false
VAR has_harp = false
VAR has_bass_drum = false
VAR has_snare_drum = false
VAR has_marimba = false
VAR has_tuba = false
VAR has_trombone = false
VAR has_french_horn = false
VAR has_trumpet = false
VAR has_oboe = false
VAR has_clarinet = false
VAR has_flute = false

/* Piano quest */
VAR ready_for_piano_quest = true
VAR has_piano_quest = false
VAR completed_piano_quest = false
VAR has_hit_piano = false
VAR has_spoken_to_spirit_piano = false
VAR has_read_piano_book = false
VAR ready_for_scarecrow_piano_quest = false
VAR has_scarecrow_piano_quest = false
VAR has_piano_key = false
VAR has_played_piano = false

/* Trombone quest */
VAR ready_for_talk_to_uncle_quest = false
VAR has_talk_to_uncle_quest = false
VAR ready_for_trombone_quest = false
VAR has_trombone_quest = false
VAR completed_trombone_quest = false
VAR has_played_trombone_song = false

/* Trumpet quest */
VAR ready_for_trumpet_quest = false
VAR has_trumpet_quest = false
VAR completed_trumpet_quest = false 
VAR has_fished_trumpet = false

/* Flute quest */
VAR ready_for_flute_quest = false
VAR has_flute_quest = false
VAR completed_flute_quest = false

/* Violin quest */
VAR ready_for_violin_quest = false
VAR has_violin_quest = false
VAR completed_violin_quest = false

/* Drum quest */
VAR ready_for_drum_quest = false
VAR has_drum_quest = false
VAR completed_drum_quest = false

/* Cow quest */
VAR ready_for_cow_quest = false
VAR has_cow_quest = false
VAR completed_cow_quest = false

