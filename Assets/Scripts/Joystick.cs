using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

	private string currentButton;
	private string currentAxis;
	private float axisInput;
	
	void Start () {
	
	}
	
	void Update () 
	{
		/* PS3 Controller stuff - too glitchy
		// Horizontal Axis
		if (Input.GetAxis("Horizontal") > 0.5)
			Right();
		if (Input.GetAxis("Horizontal") < -0.5)
			Left();
		
		// Vertical Axis
		if (Input.GetAxis("Vertical") > 0.5)
			Up();
		if (Input.GetAxis("Vertical") < -0.5)
			Down();
		
		// Horizontal Axis D-pad
		if (Input.GetAxis("Horizontal Dpad") == 1)
			Right();
		if (Input.GetAxis("Horizontal Dpad") == -1)
			Left();
		
		// Vertical Axis D-pad
		if (Input.GetAxis("Vertical Dpad") == 1)
			Up();
		if (Input.GetAxis("Vertical Dpad") == -1)
			Down();
		
		// Buttons
		if(Input.Getn("Button Confirm"))
			nConfirm();
		if(Input.Getn("Button Back"))
			nBack();
		if(Input.Getn("Button Start"))
			nStart();
		*/
		
		
	}
	
	
}