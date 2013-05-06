using UnityEngine;
using System.Collections;

public class PlayerSelection : MonoBehaviour 
{
	public int[] Units = {1,2,3,4,5,6,7,8,9};
	float[] Row = {2.56f,1.81f,1.06f};
	float[] Column = {-0.125f, 0.625f, 1.375f};
	int P1CurrentSelection;
	int P2CurrentSelection;
    public GameObject P1Selector;
    public GameObject P2Selector;
	public GameObject P1UnitInfo;
	public GameObject P2UnitInfo;
	public Material[] UnitInfoMat;
	public Material[] UnitPortMat;	
	public static int[] POneRoster = new int[5];
    public static int[] PTwoRoster = new int[5];
	int p1index = 0;
	int p2index = 0;
//	Roster Selection
	
	public GameObject[] P1Roster;
	public GameObject[] P2Roster;
		
	
	
	void Start()
	{
		P1CurrentSelection = 1;
		P2CurrentSelection = 3;
		P1MovetoLoc();
		P2MovetoLoc();
		
		for (int i=0; i<5; i++)
		{
			POneRoster[i] = 0;
			PTwoRoster[i] = 0;
		}
		
		for (int j=0; j<5; j++)
		{
			P1Roster[j].gameObject.renderer.material = UnitPortMat[9];
			P2Roster[j].gameObject.renderer.material = UnitPortMat[9];
		}
				
	}
	
	void Update()
	{
		PlayerOneController();
		PlayerTwoController();
		P1MovetoLoc();
		P2MovetoLoc();
		if (p1index == 5 & p2index == 5)
			Application.LoadLevel("Game");
	}
	
	void PlayerOneController()
	{
		if(p1index < 5)
		{
		
			if (Input.GetKeyDown("w"))
			{
				if (P1CurrentSelection != 1 && P1CurrentSelection != 2 && P1CurrentSelection != 3)
					P1CurrentSelection = P1CurrentSelection - 3;
				else
					Debug.Log("Cannot move further up!");			
			}
			if (Input.GetKeyDown("a"))
			{
				if (P1CurrentSelection != 1 && P1CurrentSelection != 4 && P1CurrentSelection != 7)
					P1CurrentSelection--;
				else
					Debug.Log("Cannot move further left!");			
			}
			if (Input.GetKeyDown("s"))
			{
				if (P1CurrentSelection != 7 && P1CurrentSelection != 8 && P1CurrentSelection != 9)
					P1CurrentSelection = P1CurrentSelection + 3;
				else
					Debug.Log("Cannot move further down!");			
			}
			if (Input.GetKeyDown("d"))
			{
				if (P1CurrentSelection != 3 && P1CurrentSelection != 6 && P1CurrentSelection != 9)
					P1CurrentSelection++;
				else
					Debug.Log("Cannot move further right!");			
			}
		
			if (Input.GetKeyDown("space"))
			{
				POneRoster[p1index] = P1CurrentSelection;
				P1Roster[p1index].gameObject.renderer.material = UnitPortMat[P1CurrentSelection-1];
				p1index++;
			}
		}
		else
				Debug.Log("All players selected for P1");
	}
	
	void PlayerTwoController()
	{
		if(p2index < 5)
		{
			if (Input.GetKeyDown("[5]"))
			{
				if (P2CurrentSelection != 1 && P2CurrentSelection != 2 && P2CurrentSelection != 3)
					P2CurrentSelection = P2CurrentSelection - 3;
				else
					Debug.Log("Cannot move further up!");			
			}
			if (Input.GetKeyDown("[1]"))
			{
				if (P2CurrentSelection != 1 && P2CurrentSelection != 4 && P2CurrentSelection != 7)
					P2CurrentSelection--;
				else
					Debug.Log("Cannot move further left!");			
			}
			if (Input.GetKeyDown("[2]"))
			{
				if (P2CurrentSelection != 7 && P2CurrentSelection != 8 && P2CurrentSelection != 9)
					P2CurrentSelection = P2CurrentSelection + 3;
				else
					Debug.Log("Cannot move further down!");			
			}
			if (Input.GetKeyDown("[3]"))
			{
				if (P2CurrentSelection != 3 && P2CurrentSelection != 6 && P2CurrentSelection != 9)
					P2CurrentSelection++;
				else
					Debug.Log("Cannot move further right!");			
			}
			
			if (Input.GetKeyDown("[8]"))
			{
				PTwoRoster[p2index] = P2CurrentSelection;
				P2Roster[p2index].gameObject.renderer.material = UnitPortMat[P2CurrentSelection-1];
				p2index++;
				
				
			}
		}
		else
				Debug.Log("All players selected for P2");
	}
	void P1MovetoLoc()
	{
		float newRow = 0f;
		float newCol = 0f;
		
		if (P1CurrentSelection == 1 || P1CurrentSelection == 2 || P1CurrentSelection == 3)
			newRow = Row[0];
		if (P1CurrentSelection == 4 || P1CurrentSelection == 5 || P1CurrentSelection == 6)
			newRow = Row[1];
		if (P1CurrentSelection == 7 || P1CurrentSelection == 8 || P1CurrentSelection == 9)
			newRow = Row[2];
		if (P1CurrentSelection == 1 || P1CurrentSelection == 4 || P1CurrentSelection == 7)
			newCol = Column[0];
		if (P1CurrentSelection == 2 || P1CurrentSelection == 5 || P1CurrentSelection == 8)
			newCol = Column[1];
		if (P1CurrentSelection == 3 || P1CurrentSelection == 6 || P1CurrentSelection == 9)
			newCol = Column[2];
		
		
		P1Selector.gameObject.transform.position = new Vector3 (newCol, newRow, 1.7f);
		P1UnitInfo.gameObject.renderer.material = UnitInfoMat[P1CurrentSelection-1];
	}
	
	void P2MovetoLoc()
	{
		float newRow = 0f;
		float newCol = 0f;
		
		
		if (P2CurrentSelection == 1 || P2CurrentSelection == 2 || P2CurrentSelection == 3)
			newRow = Row[0];
		if (P2CurrentSelection == 4 || P2CurrentSelection == 5 || P2CurrentSelection == 6)
			newRow = Row[1];
		if (P2CurrentSelection == 7 || P2CurrentSelection == 8 || P2CurrentSelection == 9)
			newRow = Row[2];
		if (P2CurrentSelection == 1 || P2CurrentSelection == 4 || P2CurrentSelection == 7)
			newCol = Column[0];
		if (P2CurrentSelection == 2 || P2CurrentSelection == 5 || P2CurrentSelection == 8)
			newCol = Column[1];
		if (P2CurrentSelection == 3 || P2CurrentSelection == 6 || P2CurrentSelection == 9)
			newCol = Column[2];
		P2Selector.gameObject.transform.position = new Vector3 (newCol, newRow, 1.6f);
		P2UnitInfo.gameObject.renderer.material = UnitInfoMat[P2CurrentSelection-1];
		
	}
		
	public void OnGUI() 
	{
		GUI.color = Color.white;
		
//		Debug.Log ("Screen width is " + Screen.width + " and Screen height is " + Screen.height);   /// 1724 and 798
		GUI.Box(new Rect(Screen.width/2 - 200,30,400, 40), "");
   		GUI.Label(new Rect(Screen.width/2 - 97,40,194, 39), "SELECT YOUR COMBATANTS");

	}
}