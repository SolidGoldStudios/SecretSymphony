INCLUDE Chapters/FaeryAppears.ink
INCLUDE Chapters/Piano.ink
INCLUDE Chapters/Trombone.ink
INCLUDE Chapters/Trumpet.ink
INCLUDE Chapters/Flute.ink
INCLUDE Chapters/Violin.ink
INCLUDE Chapters/Drum.ink
INCLUDE Chapters/Items.ink
INCLUDE Chapters/FrenchHorn.ink
INCLUDE Chapters/Tuba.ink
INCLUDE Chapters/Oboe.ink
INCLUDE Chapters/SnareDrum.ink
INCLUDE Chapters/Bass.ink
INCLUDE Chapters/Viola.ink
INCLUDE Chapters/Clarinet.ink
INCLUDE Chapters/Harp.ink
INCLUDE Chapters/Marimba.ink
INCLUDE Chapters/FortuneTeller.ink


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
VAR has_bass = false
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

/* Bass quest */
VAR ready_for_bass_quest = true // Always true!
VAR has_bass_quest = false
VAR completed_bass_quest = false

/* Bass drum quest */
VAR ready_for_bass_drum_quest = true // Always true!
VAR has_bass_drum_quest = false
VAR completed_bass_drum_quest = false

/* Clarinet quest */
VAR ready_for_clarinet_quest = true // Always true!
VAR has_clarinet_quest = false
VAR completed_clarinet_quest = false

/* Flute quest */
VAR ready_for_flute_quest = true // Always true!
VAR has_flute_quest = false
VAR completed_flute_quest = false

/* French horn quest */
VAR ready_for_french_horn_quest = false
VAR has_french_horn_quest = false
VAR completed_french_horn_quest = false
VAR has_fished_french_horn = false

/* Harp quest */
VAR ready_for_harp_quest = true // Always true!
VAR has_harp_quest = false
VAR completed_harp_quest = false

/* Marimba quest */
VAR ready_for_marimba_quest = true // Always true!
VAR has_marimba_quest = false
VAR completed_marimba_quest = false

/* Oboe quest */
VAR ready_for_oboe_quest = true // Always true!
VAR has_oboe_quest = false
VAR completed_oboe_quest = false

/* Piano quest */
VAR ready_for_piano_quest = true // Always true!
VAR has_piano_quest = false
VAR completed_piano_quest = false
VAR has_hit_piano = false
VAR has_spoken_to_spirit_piano = false
VAR has_read_piano_book = false
VAR ready_for_scarecrow_piano_quest = true // Always true!
VAR has_scarecrow_piano_quest = false
VAR has_piano_key = false
VAR has_played_piano = false

/* Snare drum quest */
VAR ready_for_snare_drum_quest = true // Always true!
VAR has_snare_drum_quest = false
VAR completed_snare_drum_quest = false

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

/* Tuba quest */
VAR ready_for_tuba_quest = false
VAR has_tuba_quest = false
VAR completed_tuba_quest = false

/* Violin quest */
VAR ready_for_violin_quest = true // Always true!
VAR has_violin_quest = false
VAR completed_violin_quest = false

/* Viola quest */
VAR ready_for_viola_quest = true // Always true!
VAR has_viola_quest = false
VAR completed_viola_quest = false
VAR bard_stop_crying = false

/* Cow quest */
VAR ready_for_cow_quest = false
VAR has_cow_quest = false
VAR completed_cow_quest = false

