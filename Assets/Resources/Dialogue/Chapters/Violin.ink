==violinquest_joan==

 {
	- !has_violin_quest && ready_for_violin_quest && !completed_violin_quest:
		Hello down there! #name:Joan #audio:female_speak_short_1
		Is that you, Joan? #name:Melody #mood:concerned
		Yep! It's me, Joan the Village Goof! #name:Joan #mood:happy #audio:female_speak_medium_1
        Why are you up in that tree? #name:Melody #mood:happy
        I'm comforting the apples. They're afraid to fall down. #name:Joan #mood:sad #audio:female_speak_long_1
        That's sweet of you. What's that you're holding? #name:Melody  #mood:thinking
        This? Why, it's just my friend Chucky. He's helping me. #name:Joan #mood:happy #audio:female_speak_long_2
        Chucky? It looks like a violin to me! #name:Melody  #mood:happy
        Violin? What's that? #name:Joan #mood:sad #audio:female_speak_short_2
        A violin is a musical instrument. It makes pretty sounds. #name:Melody
        Hmm, interesting. I didn't know Chucky could make pretty sounds. #name:Joan #audio:female_speak_long_1
        If you think Chucky is a "muzribble instrabob," prove it! #name:Joan  #mood:happy #audio:female_speak_medium_2
		->violinquest_trivia
	 
	- has_violin_quest && !completed_violin_quest:
		You want to talk about Chucky? #name:Joan #audio:female_speak_short_2
		->violinquest_trivia
			
	- else:
		Shhhh, you'll scare the squirrel! #name:Joan #mood:happy #audio:female_speak_medium_1
		->END
}

==violinquest_trivia==
		TRIVIA!! #name:Goat #trivia:Joan,violin,violinquest_trivia_success,violinquest_trivia_fail
		->violinquest_trivia_success
		
==violinquest_trivia_success==
	Oops! I hope that didn't hurt, Chucky! #name:Joan #mood:sad #audio:female_speak_medium_1
    He's okay! Thanks, Joan! #name:Melody #mood:happy
    You bet! Have a nice day. I'll be here comforting the remaining apples. #name:Joan #audio:female_speak_long_1
	~ tooltip = "You saved the violin!"
	~ completed_violin_quest = true
	-> END
		
==violinquest_trivia_fail==
		YOU FAILED AND I NEED DIALOG, TRY AGAIN #name:Joan #mood:sad #audio:female_speak_medium_1
		+ [Yes] Let's do it! #name:Melody #mood:happy
				-> violinquest_trivia
		+ [No] I need more time to study. #name:Melody #mood:thinking
				-> END
		->violinquest_trivia