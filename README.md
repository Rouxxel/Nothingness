# Nothingness
 I try to improve the player movement and obstacle spawning

It was supposed to be a project to improve the movement of the player object and obstacle spawning but the project 
went a little too far in the sense that more logic was implemented than just that. 

i tried the implementation of a very simple and cranky buff-debuff system that barely holds itself together, a 
movement system that includes not only movement in X and Y axis but also a combination of both at the same time for 
diagonal movement, for the spawners i tried to implement a decrease system so they would spawn objects more often as 
time goes on, added animation to all sprites for gameobjects and tried to implement several scenes for different 
points of the game but failed miserably and scrapped the idea itself.

Overall i feel an improvement but still, the playerscript has too many things and too many other scripts depend on it, 
maybe the implementation of another gameobject with just a script could have been better, idk

Edit 03/05/2024 (european date): I decided to add a save file to save the amount of time the player has survived and also make the game correspond, for instance, if the player has survived for 90 seconds, enemies will spawn as quick as intended at that time instead of spawning as if a new game has started, although i am still missing a reset function because deleting the Json file is not a good solution
