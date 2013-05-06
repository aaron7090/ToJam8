using UnityEngine;
using System.Collections;

public class PlayerOneResource : MonoBehaviour {

	public float maxResource 	= 25.0f;
	public float regenRatePerSecond	=  2.0f;
	public float resource 		= 0.0f;
	bool unlimitedResource		= false;
	float regenTime				= 0;

	void Update () {
		if(resource < maxResource)
    	{
        	if (Time.time > regenTime + 1.0)
			{
				resource += regenRatePerSecond;
				regenTime = Time.time;
			}
   		}
    	if(resource >= maxResource)
    	{
    		resource = maxResource;
    	} 
		
	}

	public bool HasResource( float resourceCost)
	{
		if (!unlimitedResource)
		{
			if (resource >= resourceCost)
			{
				ConsumeResource(resourceCost);
				return true;
			}
			if (resource < resourceCost)
			{
				print ("Insufficient Resource!");
				GUI.Label(new Rect((Screen.width/2),((Screen.height)/2), 156, 20), "Insufficient Resource!");
				return false;
			}
		}
		return true;
	}	

	public void ConsumeResource (float resourceCost)
	{
		resource -= resourceCost; 
	}
}

