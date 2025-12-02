**Ben's Work on Animation + Important Notes**





I'm including the snippets of code I used to connect Pan's animations to whichever player movement script we're using.

Since, I'm guessing, that all the code is still a WIP, Dan or Duncan should just be able to insert these lines into whatever player movement script you're using. 





**What's Included in This Package:**



* Formatted sprite sheet
* Animation objects for Idle, Run, and Attack
* An Animator object ("Player Anim") that ties all of Pan's animations together
* A prefab of the Pan player character I made to demonstrate the animation and what components I have in there 
* The basic script I used for player movement (under the "Placeholder Scripts" folder)





**Things to Be Aware of:**



* Attach an Animator component to the player character and select the 'Player Anim' controller for the 'Controller' field of the component
* Add the 'Sprite Renderer' component to the player character, and place "Pan Player" in the 'Sprite' field
* Bcuz of how the sprite sheet is formatted, you may have to adjust Pan's collider/character controller so that there's a hearty gap in between her feet and the bottom of the collider. You'll notice this when you start to mess around with the player character, so just adjust the collider accordingly 





**Code To Be Attached to a Player Movement Script:**

* You guys know the player movement script(s) you're working with better than me, so you can adjust any of this as you see fit, but these lines of code are generally important to get Pan's animations to function 
* Select "Pan Player" for both the Animator and Sprite Renderer fields in the player movement script (once you add some of the code below)
* I've also included comments with each code snippet for sum guidance 



----------------------------------------------------------------------------------------------------------------------------------------



**VARIABLES** 



&nbsp;	//Allows you to add an Animator object from the Inspector

&nbsp;	\[SerializeField] private Animator animator;



&nbsp;	//Allows you to add the Pan sprite sheet from the Inspector

&nbsp;	\[SerializeField] private SpriteRenderer spriteRenderer;



&nbsp;	//Variable used to track Pan's movement as to when to flip her sprite 

&nbsp;	private float xPosLastFrame;





**RUNNING/IDLE ANIMATIONS**



&nbsp;	//You may have to adjust this conditional to reflect whatever you're using to check movement,

&nbsp;	//but it essentially just checks if you're moving. If you are, the running animation is played.

&nbsp;	//If you're standing still, the idle sprite will be invoked. 

&nbsp;	if (moveDirection != Vector3.zero)

&nbsp;	{

&nbsp;	    animator.SetBool("isRunning", true);

&nbsp;	}

&nbsp;	else

&nbsp;	{

&nbsp;   		animator.SetBool("isRunning", false);

&nbsp;	}



**ATTACKING ANIMATION**



&nbsp;	//You don't really need this conditional/if-else, you just need to check that if the player attacks, then the attack

&nbsp;	//animation will play. The lines inside of the if-else are the main importance. 

&nbsp;	if(Input.GetMouseButtonDown(0))

&nbsp;	{

&nbsp;   		animator.SetBool("isAttacking", true);

&nbsp;	}

&nbsp;	else

&nbsp;	{

&nbsp;   		animator.SetBool("isAttacking", false);

&nbsp;	}





**SPRITES FLIPPING BASED ON DIRECTIONAL MOVEMENT**



&nbsp;	//Tbh I don't really know what this does exactly, but this makes it so that the sprites flip based on the direction 

&nbsp;	//of the player's movement

&nbsp;	if (transform.position.x > xPosLastFrame)

&nbsp;	{

&nbsp;   		//Moving right

&nbsp;   		spriteRenderer.flipX = true;

&nbsp;	}

&nbsp;	else if (transform.position.x < xPosLastFrame)

&nbsp;	{

&nbsp;   		//Moving left

&nbsp;   		spriteRenderer.flipX = false;

&nbsp;	}



&nbsp;	xPosLastFrame = transform.position.x;

