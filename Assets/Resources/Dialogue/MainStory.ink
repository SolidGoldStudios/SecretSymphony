INCLUDE Chapters/FaeryAppears.ink
INCLUDE Chapters/Piano.ink
INCLUDE Chapters/Trombone.ink
INCLUDE Chapters/Items


/** 
 * Triggers
 **/
VAR tooltip = ""


/**
 * States
 **/

/* Piano quest */
VAR ready_for_piano_quest = true
VAR has_piano_quest = false
VAR completed_piano_quest = false

VAR has_scythe = false
VAR has_hit_piano = false
VAR has_spoken_to_spirit_piano = false
VAR has_read_piano_book = false
VAR has_piano_key = false
VAR has_played_piano = false

/* Trombone quest */
VAR ready_for_trombone_quest = false
VAR has_trombone_quest = false
VAR completed_trombone_quest = false

VAR has_played_trombone_song = false

/* Cow quest */
VAR ready_for_cow_quest = false
VAR has_cow_quest = false
VAR completed_cow_quest = false

/* Fishing quest */
VAR ready_for_fishing_quest = false
VAR has_fishing_quest = false
VAR completed_fishing_quest = false