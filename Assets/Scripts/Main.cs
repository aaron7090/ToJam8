using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject unit;
	
	
	public static ArrayList[,] UnitArrays;
	
	public RadialControl BaseRadialControl;
	
	private RadialControl playerOneRadialControl;
	private RadialControl playerTwoRadialControl;
	
	private int playerOneRadialSelection;
	private int playerTwoRadialSelection;
	
	private Player player1;
	private Player player2;
	
	static public int winningPlayer = -1;
	
	public float[] ENERGY_COSTS = {2.0f, 3.0f, 5.0f, 8.0f, 12.0f, 6.0f, 5.0f, 6.0f, 8.0f};
	
	void Start () 
	{		
		winningPlayer	=	-1;
		
		player1 = new Player();
		player2 = new Player();
		
		player1.AssignPlayerUnits(0);
		player2.AssignPlayerUnits(1);
		
		playerOneRadialSelection = 1;
		playerTwoRadialSelection = 1;
		
		playerOneRadialControl = (RadialControl)Instantiate(BaseRadialControl, GameObject.Find("SpawnLeftMid").transform.position, Quaternion.identity);
		playerTwoRadialControl = (RadialControl)Instantiate(BaseRadialControl, GameObject.Find("SpawnRightMid").transform.position, Quaternion.identity);
		
		
		for (int i = 0; i < 5; i++)
		{
			playerOneRadialControl.AssignRadialUnit(i, player1.units[i]);	
			playerTwoRadialControl.AssignRadialUnit(i, player2.units[i]);
		}
		
		
		
		// To access: ((ArrayList)Main.UnitArrays[team,lane])
		UnitArrays = new ArrayList[2,3] 
		{ 
			{ new ArrayList(), new ArrayList(), new ArrayList() }, 
			{ new ArrayList(), new ArrayList(), new ArrayList() }
		};
		
		
		
		SpawnUnit (0, 0, 7);
		
		SpawnUnit (1, 0, 5);
	}
	
	void Update () 
	{
		if (Input.GetKeyDown ("p"))
			StartKey();
		
		// PLAYER 1 CONTROLS
			if (Input.GetKeyDown ("a"))
				P1Left();
			if (Input.GetKeyDown ("d"))
				P1Right();
			
			if (Input.GetKeyDown ("w"))
				P1Up();
			if (Input.GetKeyDown ("s"))
				P1Down();
			
			if (Input.GetKeyDown ("space"))
				P1Confirm();
			if (Input.GetKeyDown ("b"))
				P1Back();
		
		// PLAYER 2 CONTROLS
			if (Input.GetKeyDown ("[1]"))
				P2Left();
			if (Input.GetKeyDown ("[3]"))
				P2Right();
			
			if (Input.GetKeyDown ("[5]"))
				P2Up();
			if (Input.GetKeyDown ("[2]"))
				P2Down();
			
			if (Input.GetKeyDown (KeyCode.KeypadEnter))
				P2Confirm();
			if (Input.GetKeyDown ("[+]"))
				P2Back();
		
	}
	
	public void SpawnUnit (int team, int lane, int unit_number) 
	{
		float temp_coord_x;
		float temp_coord_y;
		float temp_coord_z;
		
		switch (team) 
		{
			case 0:
				switch (lane)
				{
				    case 0:
						temp_coord_x = GameObject.Find("SpawnLeftTop").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnLeftTop").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnLeftTop").transform.position.z;
				        break;
				    case 1: 
				        temp_coord_x = GameObject.Find("SpawnLeftMid").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnLeftMid").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnLeftMid").transform.position.z;
				        break;
					default:
				        temp_coord_x = GameObject.Find("SpawnLeftBot").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnLeftBot").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnLeftBot").transform.position.z;
				        break;
				}
				break;
			default:
				switch (lane)
				{
				    case 0:
						temp_coord_x = GameObject.Find("SpawnRightTop").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnRightTop").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnRightTop").transform.position.z;
				        break;
				    case 1:
				        temp_coord_x = GameObject.Find("SpawnRightMid").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnRightMid").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnRightMid").transform.position.z;
				        break;
					default:
				        temp_coord_x = GameObject.Find("SpawnRightBot").transform.position.x;
						temp_coord_y = GameObject.Find("SpawnRightBot").transform.position.y;
						temp_coord_z = GameObject.Find("SpawnRightBot").transform.position.z;
				        break;
				}
				break;
		}
		
		GameObject test = (GameObject)Instantiate(unit, new Vector3 (temp_coord_x, temp_coord_y, temp_coord_z), Quaternion.identity);
		
		if (team == 0)
			test.renderer.material.color = Color.red;
		else
		{
			test.renderer.material.color = Color.green;
			((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).scale = new Vector3(-6, 6, 1);
		}
		Unit testunit = new Unit();
			
		switch (unit_number)
		{
			case 0:
				testunit = (LightFastUnit)test.AddComponent("LightFastUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("ScoutMove");
				testunit.unittype = "Scout";
				break;
			case 1:
				testunit = (LightMeleeUnit)test.AddComponent("LightMeleeUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("MarineMove");
				testunit.unittype = "Marine";
				break;
			case 2:
				testunit = (MediumMeleeUnit)test.AddComponent("MediumMeleeUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("MarauderMove");
				testunit.unittype = "Marauder";
				break;
			case 3:
				testunit = (HeavyTankUnit)test.AddComponent("HeavyTankUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("TankMove");
				testunit.unittype = "Tank";
				break;
			case 4:
				testunit = (HeavyBruiserUnit)test.AddComponent("HeavyBruiserUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("BeserkerMove");
				testunit.unittype = "Beserker";
				break;
			case 5:
				testunit = (HealerUnit)test.AddComponent("HealerUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("HealerMove");
				testunit.unittype = "Healer";
				break;
			case 6:
				testunit = (LightRangeUnit)test.AddComponent("LightRangeUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("ShooterMove");
				testunit.unittype = "Shooter";
				break;
			case 7:
				testunit = (MediumRangeUnit)test.AddComponent("MediumRangeUnit");
				((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("RangerMove");
				testunit.unittype = "Ranger";
				break;
			case 8:
				testunit = (HeavyRangeUnit)test.AddComponent("HeavyRangeUnit");
			((tk2dAnimatedSprite)test.GetComponent("tk2dAnimatedSprite")).Play("ShotgunMove");
				testunit.unittype = "Shotgun";
				break;
		}
		
		((ArrayList)UnitArrays[team,lane]).Add(test);
		
		testunit.team = team;
		testunit.lane = lane;
		testunit.type = unit_number;
		testunit.self = test;
		testunit.UnitSpawned();
	}
	
void StartKey () 
	{
		Debug.Log ("Button Start");	
	}
	
	// PLAYER 1 CONTROL FUNCTIONS
		void P1Right () {
			//PlayerOneRadial
			playerOneRadialControl.RadialGotoSelectionRight();
		}
		void P1Left () {
			playerOneRadialControl.RadialGoToSelectionLeft();
		}
		
		void P1Up () 
		{
			if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftTop").transform.position)
			{
				playerOneRadialSelection = 2;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftBot").transform.position);
			}
			else if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftMid").transform.position)
			{
				playerOneRadialSelection = 0;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftTop").transform.position);
			}
			else if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftBot").transform.position)
			{
				playerOneRadialSelection = 1;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftMid").transform.position);
			}
		}
		void P1Down () 
		{
			if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftTop").transform.position)
			{
				playerOneRadialSelection = 1;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftMid").transform.position);
			}
			else if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftMid").transform.position)
			{
				playerOneRadialSelection = 2;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftBot").transform.position);
			}
			else if (playerOneRadialControl.transform.position == GameObject.Find("SpawnLeftBot").transform.position)
			{
				playerOneRadialSelection = 0;
				playerOneRadialControl.MoveRadial(GameObject.Find("SpawnLeftTop").transform.position);
			}
		}
	
		void P1Confirm () {
			if (((PlayerOneResource)GameObject.Find("Main Camera").GetComponent("PlayerOneResource")).HasResource(ENERGY_COSTS[player1.units[playerOneRadialControl.index]]))
			{
				Debug.Log ("Spawn 0 " + playerOneRadialSelection + " " + player1.units[playerOneRadialControl.index]);
				SpawnUnit(0, playerOneRadialSelection, player1.units[playerOneRadialControl.index]);
			}
		}

		void P1Back () {
			Debug.Log ("Button Back");	
		}
	
	// PLAYER 2 CONTROLS
		void P2Right () {
			playerTwoRadialControl.RadialGotoSelectionRight();
		}
		void P2Left () {
			playerTwoRadialControl.RadialGoToSelectionLeft();
		}
		
		void P2Up () {
			if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightTop").transform.position)
			{
				playerTwoRadialSelection = 2;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightBot").transform.position);
			}
			else if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightMid").transform.position)
			{
				playerTwoRadialSelection = 0;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightTop").transform.position);
			}
			else if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightBot").transform.position)
			{
				playerTwoRadialSelection = 1;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightMid").transform.position);
			}
		}
		void P2Down () {
		
			if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightTop").transform.position)
			{
				playerTwoRadialSelection = 1;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightMid").transform.position);
			}
			else if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightMid").transform.position)
			{
				playerTwoRadialSelection = 2;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightBot").transform.position);
			}
			else if (playerTwoRadialControl.transform.position == GameObject.Find("SpawnRightBot").transform.position)
			{
				playerTwoRadialSelection = 0;
				playerTwoRadialControl.MoveRadial(GameObject.Find("SpawnRightTop").transform.position);
			}
		}
	
		void P2Confirm () {
			if (((PlayerTwoResource)GameObject.Find("Main Camera").GetComponent("PlayerTwoResource")).HasResource(ENERGY_COSTS[player2.units[playerTwoRadialControl.index]]))
			{
				Debug.Log ("Spawn 1 " + playerTwoRadialSelection + " " + player2.units[playerTwoRadialControl.index]);	
				SpawnUnit(1, playerTwoRadialSelection, player2.units[playerTwoRadialControl.index]);
			}
		}
		void P2Back () {
			Debug.Log ("Button Back");	
		}
	
}