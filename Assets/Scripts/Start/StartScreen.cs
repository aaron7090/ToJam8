using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public void OnGUI() 
	{
		GUI.color = Color.white;
		
//		Debug.Log ("Screen width is " + Screen.width + " and Screen height is " + Screen.height);   /// 1724 and 798
		GUI.Box(new Rect(Screen.width/2 - 200,100,400, 40), "");
   		GUI.Label(new Rect(Screen.width/2 - 70,110,140, 39), "GAME NAME HERE");
  	 	GUI.Box(new Rect(Screen.width/2 - 200,Screen.height - 100,400, 40), "");
   		GUI.Label(new Rect(Screen.width/2 - 90,Screen.height - 90,180, 39), "PRESS ANY KEY TO START");

		
		if (Input.anyKeyDown)
		{
			Application.LoadLevel("Selection");
		}
	}
}


		