using UnityEngine;
using System.Collections;

public class Dashboard : MonoBehaviour {
	
	public Texture healthTexture;
	float maxHealth = 25.0f;	
	public PlayerOneHealth playerOneHealth;
	public PlayerTwoHealth playerTwoHealth;
	
	public Texture resourceTexture;
	float maxResource = 25.0f;
	public PlayerOneResource playerOneResource;
	public PlayerTwoResource playerTwoResource;

	void OnGUI ()
	{
		float pOneHealth 	= playerOneHealth.health;
		float pTwoHealth	= playerTwoHealth.health;
		float pOneResource	= playerOneResource.resource;
		float pTwoResource 	= playerTwoResource.resource;
		Color tempColour 	= GUI.color;
  		
		if(!healthTexture || !resourceTexture)
		{
        	Debug.LogError("Assign a Texture in the inspector.");
    	}
		
		//PLAYER1 HEALTH DISPLAY
		
		GUI.Box(new Rect(80,Screen.height - 90,400, 40), "");
   		GUI.Label(new Rect(102,Screen.height - 85,400, 39), "Health ");
  	 	GUI.color = tempColour;
    	GUI.Button (new Rect(150,Screen.height - 90,330, 39), "");
		
		if (healthTexture)    
  		{
	    	if(pOneHealth > maxHealth || pOneHealth == maxHealth)
	    	{
	    		GUI.DrawTexture(new Rect(151,Screen.height - 89,(maxHealth/maxHealth * 328), 38), healthTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
	    	else if (pOneHealth < maxHealth && pOneHealth > 0)
	    	{
	    		GUI.DrawTexture(new Rect(151,Screen.height - 89,(pOneHealth/maxHealth) * 328, 38), healthTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
		} 
		
		//PLAYER2 HEALTH DISPLAY

		GUI.color = Color.white;
		GUI.Box(new Rect(630,Screen.height - 90,400, 40), "");
   		GUI.Label(new Rect(1047,Screen.height - 85,70, 39), "Health");
  	 	GUI.color = tempColour;
    	GUI.Button (new Rect(700,Screen.height - 90,330, 39), "");
		
		if (healthTexture)    
  		{
	    	if(pTwoHealth > maxHealth || pTwoHealth == maxHealth)
	    	{
	    		GUI.DrawTexture(new Rect(1029,Screen.height - 89,(maxHealth/maxHealth * -328), 38), healthTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
	    	else if (pTwoHealth < maxHealth && pTwoHealth > 0)
	    	{
	    		GUI.DrawTexture(new Rect(1029,Screen.height - 89,(pTwoHealth/maxHealth) * -328, 38), healthTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
		} 
		//PLAYER1 RESOURCE DISPLAY
		
		GUI.color = Color.white;
		GUI.Box(new Rect(80,Screen.height - 50,400, 40), "");
   		GUI.Label(new Rect(87,Screen.height - 45,400, 39), "Resource ");
  	 	GUI.color = tempColour;
    	GUI.Button (new Rect(150,Screen.height - 50,330, 39), "");
 	 	
		if (resourceTexture)    
  		{
	    	if(pOneResource > maxResource || pOneResource == maxResource)
	    	{
	    		GUI.DrawTexture(new Rect(151,Screen.height - 49,(maxResource/maxResource * 328), 38), resourceTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
	    
	    	else if (pOneResource < maxResource && pOneResource > 0)
	    	{
	    		GUI.DrawTexture(new Rect(151,Screen.height - 49,(pOneResource/maxResource) * 328, 38), resourceTexture, ScaleMode.StretchToFill, true, 10.0f);
			}			
		}
		
		//PLAYER2 RESOURCE DISPLAY
		
		GUI.color = Color.white;
		GUI.Box(new Rect(630,Screen.height - 50,400, 40), "");
   		GUI.Label(new Rect(1047,Screen.height - 45,70, 39), "Resource");
  	 	GUI.color = tempColour;
    	GUI.Button (new Rect(700,Screen.height - 50,330, 39), "");
 	 	if (resourceTexture)    
  		{
	    	if(pTwoResource > maxResource || pTwoResource == maxResource)
	    	{
	    		GUI.DrawTexture(new Rect(1029,Screen.height - 49,(maxResource/maxResource * -328), 38), resourceTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	}
	    
	    	else if (pTwoResource < maxResource && pTwoResource > 0)
	    	{
	    		GUI.DrawTexture(new Rect(1029,Screen.height - 49,(pTwoResource/maxResource) * -328, 38), resourceTexture, ScaleMode.StretchToFill, true, 10.0f);
	    	
			}
		}
	}
}











