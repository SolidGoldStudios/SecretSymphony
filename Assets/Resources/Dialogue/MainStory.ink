INCLUDE Chapters/FaeryAppears.ink
INCLUDE Chapters/Piano.ink
INCLUDE Chapters/Trombone.ink
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
 **/
 
/* Items */
VAR has_scythe = true

/* Instruments */
VAR has_piano = true
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
VAR has_piano_quest = true
VAR completed_piano_quest = true
VAR has_hit_piano = true
VAR has_spoken_to_spirit_piano = true
VAR has_read_piano_book = false
VAR ready_for_scarecrow_piano_quest = true
VAR has_scarecrow_piano_quest = true
VAR has_piano_key = true
VAR has_played_piano = true

/* Trombone quest */
VAR ready_for_talk_to_uncle_quest = true
VAR has_talk_to_uncle_quest = true
VAR ready_for_trombone_quest = true
VAR has_trombone_quest = false
VAR completed_trombone_quest = false
VAR has_played_trombone_song = false

/* Flute quest */
VAR ready_for_flute_quest = true
VAR has_flute_quest = false
VAR completed_flute_quest = false

/* Violin quest */
VAR ready_for_violin_quest = true
VAR has_violin_quest = false
VAR completed_violin_quest = false

/* Drum quest */
VAR ready_for_drum_quest = true
VAR has_drum_quest = false
VAR completed_drum_quest = false

/* Cow quest */
VAR ready_for_cow_quest = false
VAR has_cow_quest = false
VAR completed_cow_quest = false

/* Fishing quest */
VAR ready_for_fishing_quest = false
VAR has_fishing_quest = false
VAR completed_fishing_quest = false 